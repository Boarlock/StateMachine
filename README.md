# SMachine

> **Status: Experimental.** This started as a learning project for practicing delegates and events. There is no automated test suite yet, so expect rough around the edges.

## Features

- Enum-keyed states, using a non-boxing key internally, the underlying value and the enum's type are packed into a struct, so no enum ever gets boxed
- Nested substates (any depth), each with its own events and its own current substate
- Predicate transitions that are safe to poll every frame
- Optional context objects passed to handlers on enter, update and exit; sealed record types with value equality and built-in deconstruction, up to 10 values
- Per-state `Enabled` flag and per-substate update propagation
- `IndependentUpdate` to tick a specific substate by a path of enum keys, mixing enum types freely across levels
- Transitions requested from inside callbacks are queued and run after the current pass, so handlers can request transitions without breaking the machine
- `TryCreateState`, `TryGetState` and `StartState` return `false` instead of throwing for common mistakes

## Requirements

.NET 10 (C# 14 by default). The source uses C# 12 features, including collection expressions. Nullable reference types and implicit usings should be enabled.

## Quick start

```csharp
using SMachine;

public enum States { Idle, Combat }
public enum CombatSubs { Melee }

private string Name;
private int HeroAttack;

public void Initialize()
{
    var machine = new StateMachine();

    // States belong to the machine
    State idle = machine.CreateState(States.Idle);
    State combat = machine.CreateState(States.Combat);

    // Substates belong to a state
    SubState melee = combat.CreateState(CombatSubs.Melee);

    // Create a context object to pass to your handlers (optional)
    var ctx = new Context<string, int>("Hero", 10);

    // Subscribe to the events
    combat.OnEnter += () => Console.WriteLine("Combat has begun!");

    melee.OnEnterContext += (ctx) => {
        
        // I recommend using pattern matching for ease of use and safety
        if (ctx is Context<string, int>(string name, int attack))
        {
            Name = name;
            HeroAttack = attack;
        }
    };

    // Start your states
    machine.StartState(States.Combat); // This fires OnEnter
    combat.StartState(CombatSubs.Melee, ctx); // This fires OnEnterContext

    // Subscribe to the OnUpdateContext event
    melee.OnUpdateContext += HeroAttack;

    // Call Update on our machine for Combat state to update, then Melee
    machine.Update(ctx);
}

public void HeroAttack(BaseContext ctx)
{
    // We can also access context directly after casting
    var typed = (Context<string, int>)ctx;
    Console.WriteLine($"{typed.Data1} hits Goblin for {typed.Data2} damage!");
}
```

Output:

```
Combat has begun!
Hero hits Goblin for 10 damage!
```

### Passing context

A context handler receives `BaseContext`, so you need to get back to the concrete `Context<...>` type it actually is. Three common ways:

```csharp
void HandleCombatEnter(BaseContext ctx)
{
    // 1. Pattern match: checks the type and destructures in one step.
    //    Safe, if ctx isn't a Context<string,int>, the block is simply skipped.
    if (ctx is Context<string, int>(string attacker, int damage)) {
		
        Console.WriteLine($"{attacker} hit for {damage}");
    }
}

void HandleCombatEnterAlt(BaseContext ctx)
{
    // 2. Cast, then deconstruct.
    //    Throws InvalidCastException if ctx isn't a Context<string,int>.
    var (attacker, damage) = (Context<string, int>)ctx;
    Console.WriteLine($"{attacker} hit for {damage}");
}

void HandleCombatEnterAlt2(BaseContext ctx)
{
    // 3. Cast, then access properties directly.
    //    Also throws InvalidCastException if ctx isn't a Context<string,int>.
    var typed = (Context<string, int>)ctx;
    Console.WriteLine($"{typed.Data1} hit for {typed.Data2}");
}
```

Option 1 is the one to reach for by default, it's both the safest (no exception on a mismatch) and the shortest to write. Use 2 or 3 only when you're certain of the shape and would rather fail loudly than silently skip.

### Update Propagation

Each substate has an `UpdatePropagation` property, which determines whether it forwards normal `Update` calls to its children.

When propagation is disabled, the substate still receives its own Update call, but does not forward that update to its children. This does not affect its `Enabled` property or its ability to receive independent updates.

### Independent Updates

`IndependentUpdate` ticks one substate, identified by a path of keys starting at the machine's current state. Only the targeted substate receives the update; its ancestors are not updated, and only the target's own `Enabled` flag is checked — a disabled ancestor along the path does not block it. Each key in the path can be a different enum type.

```csharp
enum Combat { Cooldown }
enum CooldownSub { Recharge }

SubState cooldown = combat.CreateState(Combat.Cooldown, propagation: false);
SubState recharge = cooldown.CreateState(CooldownSub.Recharge);
cooldown.OnIndependentUpdate += () => Console.WriteLine("cooldown tick");

machine.IndependentUpdate(Combat.Cooldown);                        // a substate of the current state
machine.IndependentUpdate(Combat.Cooldown, CooldownSub.Recharge);  // nested path, mixed enum types
```

`IndependentUpdate` is overloaded for paths of 1 to 18 keys.

### How It Works

- **Starting:** `StartState` now fires `Enter` immediately (`OnEnter` or `OnEnterContext`, depending on whether a context is passed), unlike earlier versions where starting was silent.
- **Enter order:** The state's `OnEnter` fires first, then its current substate's, recursively.
- **Exit order:** The current substate exits first, then the state's own `OnExit` fires. Teardown mirrors setup.
- **Update order:** The state's `OnUpdate` fires first, followed by its current substate's `OnUpdate`. Updates continue recursively through the hierarchy as long as each parent substate has propagation enabled.
- **Enabled:** A disabled state/substate skips its own update events, but Enter and Exit callbacks still execute. Transitioning into a disabled state is allowed.
- **Propagation:** Controls whether this substate forwards `Update` calls to its children.
- **Callbacks that request transitions:** `TransitionState` / `TransitionSubState` calls made from inside an enter, update or exit callback are queued and executed in order after the current pass finishes. A request for the state that is already current is ignored.
- **Stopping:** `StopState` / `StopSubState` call the active state's `Exit` lifecycle before clearing it. Any outstanding transitions are discarded. This ends the active state lifetime rather than simply disabling updates. Use `SetEnabled(false)` to pause updates without ending the state lifetime.

### API Reference

#### `StateMachine`

| Member | Description |
|---|---|
| `State? CurrentState` | The active state, or `null` if none has been started. |
| `State CreateState<TKey>(TKey key)` | Registers a top-level state. Throws `InvalidOperationException` if the key is already used. |
| `bool TryCreateState<TKey>(TKey key, out State? state)` | Same as `CreateState`, but returns `false` instead of throwing if the key is already used. |
| `bool StartState(State next, BaseContext? ctx = null, bool enabled = true)` | Sets the initial state and fires `Enter`. Returns `false` if a state is already active. Throws `ArgumentException` for a state from another machine. |
| `bool StartState<TKey>(TKey key, BaseContext? ctx = null, bool enabled = true)` | Same, by key. Returns `false` for an unknown key or if a state is already active. |
| `void StopState()` | Calls `Exit`, clears the active state and discards queued transitions. |
| `bool TransitionState(State next, BaseContext? data = null)` | Exits the current state and enters `next`. Returns `false` if `next` is already current. Throws `ArgumentNullException` if no state is active and `ArgumentException` for a state from another machine. |
| `void TransitionState(State next, Func<bool> predicate, BaseContext? data = null)` | Transitions only when the predicate returns `true`. |
| `bool TryGetState<TKey>(TKey key, out State? state)` | Looks up a top-level state by key. |
| `State GetState<TKey>(TKey key)` | Looks up a top-level state by key. Throws `KeyNotFoundException` if missing. |
| `void Update(BaseContext? data = null)` | Updates the current state and its current substates. Does nothing if no state is active. |
| `void IndependentUpdate<T1, T2, ...>(T1 k1, T2 k2, ..., BaseContext? data = null)` | Updates the substate found by following the keys from the current state. Overloaded for 1 to 18 keys, each independently typed. Throws `ArgumentNullException` if no state is active, `ArgumentException` for an unknown key at any depth.

#### `State`

| Member | Description |
|---|---|
| `bool Enabled` | Whether this state or substate runs its own update events. |
| `void SetEnabled(bool enabled)` | Sets `Enabled`. |
| `StateMachine Machine` | The owning machine. |
| `SubState? CurrentSub` | The active substate, if any. |
| `SubState CreateState<TKey>(TKey key, bool propagation = true)` | Registers a substate. Throws `InvalidOperationException` if the key is already used. |
| `bool TryCreateState<TKey>(TKey key, out SubState? state)` | Same, but returns `false` instead of throwing. |
| `bool TryGetState<TKey>(TKey key, out SubState? state)` | Looks up a substate by key. |
| `SubState GetState<TKey>(TKey key)` | Looks up a substate by key. Throws `KeyNotFoundException` if missing. |
| `bool StartState(SubState next, BaseContext? ctx = null, bool enabled = true)` | Sets the initial substate and fires `Enter`. Returns false if one is already set. Throws `ArgumentException` for a substate with a different parent. |
| `bool StartState<TKey>(TKey key, BaseContext? ctx = null, bool enabled = true)` | Same, by key. |
| `void StopState()` | Calls `Exit` on the current substate, clears it and discards queued transitions. |
| `bool TransitionState(SubState next, BaseContext? data = null)` | Switches the current substate. Same return and exception behavior as the machine’s `TransitionState`. |
| `void TransitionState(SubState next, Func<bool> predicate, BaseContext? data = null)` | Transitions only when the predicate returns `true`. |
| `event Action OnEnter / OnUpdate / OnExit` | Fired when no context is passed. |
| `event Action<BaseContext> OnEnterContext / OnUpdateContext / OnExitContext` | Fired when a context is passed. |

#### `SubState : State`

| Member | Description |
|---|---|
| `State Parent` | The state/substate that owns this substate. |
| `bool UpdatePropagation` | Whether this substate forwards normal `Update` calls to its children. |
| `event Action OnIndependentUpdate` | Fired by `IndependentUpdate` when no context is passed. |
| `event Action<BaseContext> OnIndependentUpdateContext` | Fired by `IndependentUpdate` when a context is passed. |

### Context

`BaseContext` is the abstract base. `Context<T1>` through `Context<T1, ..., T10>` each inherit directly from `BaseContext` and are `sealed` — a `Context<A, B>` is not a `Context<A>`. Being records, they get value equality and a `Deconstruct` for free, which is what makes the positional pattern matching in the previous section work.

### Known limitations

- **Not thread-safe** Call everything from one thread.
- **Context casting.** Context handlers receive `BaseContext`. Pattern matching (see "Passing context") avoids an exception on a mismatch; a direct cast throws `InvalidCastException`.
- **Path and context ceilings.** `IndependentUpdate` supports paths of up to 18 keys; `Context` supports up to 10 values. Both are generated, fixed-arity overload sets.
- **`IndependentUpdate` only checks the target's `Enabled` flag.** A disabled ancestor along the path does not stop the update from reaching the target.
- **Keys must be unique per state.** Reusing a key within the same state throws `InvalidOperationException`.
