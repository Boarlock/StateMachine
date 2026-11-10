# SMachine

> **Status: Experimental.** This started as a learning project for practicing delegates and events. There is no automated test suite yet, so expect rough around the edges.

## Features

- Named states with `OnEnter`, `OnUpdate` and `OnExit` events
- Nested substates (any depth), each with its own events and its own current substate
- Predicate transitions that are safe to poll every frame
- Optional context objects passed to handlers on enter, update and exit
- Per-state `Enabled` flag and per-substate update propagation
- `IndependentUpdate` to tick a specific substate by name or path, e.g. `"Combat/Aiming"`
- Transitions requested from inside callbacks are queued and run after the current pass, so handlers can request transitions without breaking the machine

## Requirements

.NET 10 (C# 14 by default). The source uses C# 12 features, including collection expressions. Nullable reference types and implicit usings should be enabled.

## Quick start

```csharp
using SMachine;

var machine = new StateMachine();

State idle = machine.CreateState("Idle")!;
State combat = machine.CreateState("Combat")!;

// Substates belong to a state
SubState aiming = combat.CreateSubState("Aiming")!;
SubState firing = combat.CreateSubState("Firing")!;
combat.StartSubState(aiming);   // the substate that is current when Combat is entered

// Handlers are plain delegates
int ticks = 0;
idle.OnUpdate += () => ticks++;
idle.OnExit += () => Console.WriteLine("Leaving Idle");
combat.OnEnter += () => Console.WriteLine("Entering Combat");
aiming.OnEnter += () => Console.WriteLine("Aiming");
aiming.OnUpdate += () => combat.TransitionSubState(firing);   // queued, runs after this update pass
firing.OnEnter += () => Console.WriteLine("Firing");

machine.StartState(idle);

// Game loop
for (int frame = 0; frame < 5; frame++)
{
    machine.Update();
    machine.TransitionState(combat, () => ticks >= 3);   // safe to poll every frame
}
```

Output:

```
Leaving Idle
Entering Combat
Aiming
Firing
```

### Passing context

```csharp
combat.OnEnterContext += ctx =>
{
    var hit = (Context<string, int>)ctx;
    Console.WriteLine($"{hit.Data1} hit for {hit.Data2}");
};

machine.TransitionState(combat, new Context<string, int>("Goblin", 12));
```

When a context is passed, the `...Context` events fire instead of the plain ones (`OnEnterContext` instead of `OnEnter`, and so on). Handlers receive a `BaseContext`, so cast it to the context type you passed.

## Update Propagation

Each substate has an `UpdatePropagation` property, which determines whether it forwards normal `Update` calls to its children.

When propagation is disabled, the substate still receives its own Update call, but does not forward that update to its children. This does not affect its `Enabled` property or its ability to receive independent updates.

### Independent Updates

`IndependentUpdate` bypasses normal parent-to-child update propagation and can target a substate by name or nested path, regardless of whether it is the current substate.

```csharp
SubState cooldown = combat.CreateSubState("Cooldown", propagation: false)!;
cooldown.OnIndependentUpdate += () => Console.WriteLine("cooldown tick");

machine.IndependentUpdate("Cooldown");            // a substate of the current state
machine.IndependentUpdate("Cooldown/Recharge");   // nested path, '/'-separated
```

## How It Works

- **Enter order:** The state's `OnEnter` fires first, then its current substate's, recursively.
- **Exit order:** The current substate exits first, then the state's own `OnExit` fires. Teardown mirrors setup.
- **Update order:** The state's `OnUpdate` fires first, followed by its current substate's `OnUpdate`. Updates continue recursively through the hierarchy as long as each parent substate has propagation enabled.
- **Enabled:** A disabled state/substate skips its own update events, but Enter and Exit callbacks still execute. Transitioning into a disabled state is allowed.
- **Propagation:** Controls whether this substate forwards `Update` calls to its children.
- **Callbacks that request transitions:** `TransitionState` / `TransitionSubState` calls made from inside an enter, update or exit callback are queued and executed in order after the current pass finishes. A request for the state that is already current is ignored.
- **Stopping:** `StopState` / `StopSubState` call the active state's `Exit` lifecycle before clearing it. Any outstanding transitions are discarded. This ends the active state lifetime rather than simply disabling updates. Use `SetEnabled(false)` to pause updates without ending the state lifetime.

## API Reference

### `StateMachine`

| Member | Description |
|---|---|
| `State? CurrentState` | The active state, or `null` if none has been started. |
| `State? CreateState(string name)` | Registers a state. Returns `null` if the name is empty/whitespace or already used. |
| `bool StartState(State state, bool enabled = true)` | Sets the initial state. Returns `false` if a state is already active. Throws `ArgumentException` if the state belongs to another machine. |
| `bool StartState(string name, bool enabled = true)` | Same, by name. Returns `false` for an unknown name or if already started. |
| `void StopState()` | Calls `Exit` immediately, clears the active state and clears any outstanding transitions. |
| `void TransitionState(State next, BaseContext? data = null)` | Exits the current state and enters `next`. Ignored if `next` is already current. Throws `InvalidOperationException` if no state is active and `ArgumentException` for a state from another machine. |
| `void TransitionState(State next, Func<bool> predicate, BaseContext? data = null)` | Transitions only when the predicate returns `true`. |
| `bool TryGetState(string name, out State? state)` | Looks up a state by name. |
| `State GetState(string name)` | Looks up a state by name. Throws `KeyNotFoundException` if missing. |
| `void Update(BaseContext? data = null)` | Updates the current state and its current substates. |
| `void IndependentUpdate(string name, BaseContext? data = null)` | Updates a substate of the current state by name or /-separated path, bypassing normal parent-to-child propagation for the targeted substate. |

### `State`

| Member | Description |
|---|---|
| `bool Enabled` | Gets whether this state/substate is enabled. |
| `void SetEnabled(bool)` | Sets whether this state/substate can execute its own update callbacks. |
| `StateMachine Machine` | The owning machine. |
| `SubState? CurrentSub` | The active substate, if any. |
| `event Action OnEnter` / `OnUpdate` / `OnExit` | Fired when no context is passed. |
| `event Action<BaseContext> OnEnterContext` / `OnUpdateContext` / `OnExitContext` | Fired when a context is passed. |
| `SubState? CreateSubState(string name, bool propagation = true)` | Registers a substate. Returns `null` if the name is empty/whitespace, contains `/`, or is already used. |
| `bool StartSubState(SubState sub, bool enabled = true)` | Sets the initial substate. Returns `false` if one is already set. Throws `ArgumentException` if the substate has a different parent. |
| `bool StartSubState(string name, bool enabled = true)` | Same, by name. |
| `void StopSubState()` | Calls `Exit` immediately, clears the active substate and clears any outstanding transitions. |
| `void TransitionSubState(SubState next, BaseContext? data = null)` | Switches the current substate. Ignored if `next` is already current. Throws `InvalidOperationException` if no substate is active and `ArgumentException` for a substate with a different parent. |
| `void TransitionSubState(SubState next, Func<bool> predicate, BaseContext? data = null)` | Transitions only when the predicate returns `true`. |
| `bool TryGetSub(string name, out SubState? sub)` | Looks up a substate by name. |
| `SubState GetSub(string name)` | Looks up a substate by name. Throws `KeyNotFoundException` if missing. |

### `SubState : State`

| Member | Description |
|---|---|
| `State Parent` | The state/substate that owns this substate. |
| `bool UpdatePropagation` | Whether this substate forwards normal `Update` calls to its children. |
| `event Action OnIndependentUpdate` | Fired by `IndependentUpdate` when no context is passed. |
| `event Action<BaseContext> OnIndependentUpdateContext` | Fired by `IndependentUpdate` when a context is passed. |

### Context

`BaseContext` is the abstract base. `Context<T1>` through `Context<T1, ..., T10>` expose `Data1` through `Data10`. A `Context<A, B>` is also a `Context<A>`. Context values can be nullable, depending on the generic types supplied.

## Known limitations

- **Not thread-safe** Call everything from one thread.
- **Context casting** Context handlers receive `BaseContext`, so the developer is responsible for casting to the expected generic context type. A wrong cast throws `InvalidCastException`.
- **Substate names cannot contain `/`**, because it is the path separator for `IndependentUpdate`.
