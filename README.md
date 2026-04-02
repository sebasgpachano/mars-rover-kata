# Mars Rover Kata

## Overview
Implementation of the Mars Rover Kata in C# using .NET.  
The rover moves on a grid, executing commands to move forward/backward and rotate left/right.

## Approach
The solution was developed incrementally following a TDD approach, introducing behavior 
step by step without anticipating future requirements.

## Design

### Patterns
- **State Pattern** — each direction (`NorthState`, `EastState`, `SouthState`, `WestState`) 
  encapsulates its own movement and rotation logic. Adding a new direction requires no changes 
  to existing classes.
- **Command Pattern** — each command (`MoveForwardCommand`, `MoveBackwardCommand`, 
  `TurnLeftCommand`, `TurnRightCommand`) implements `ICommand`. Adding a new command 
  requires no changes to `Rover` or `CommandParser`.
- **Singleton** — command instances are reused across executions since they hold no state.

### SOLID
- **SRP** — each class has a single responsibility
- **OCP** — new commands and directions can be added without modifying existing classes
- **LSP** — any `IDirectionState` or `ICommand` implementation is interchangeable
- **ISP** — interfaces are minimal and focused
- **DIP** — `Rover` depends on abstractions, not concrete implementations

### Key classes
- `Rover` — manages position and state, executes commands
- `IDirectionState` — abstraction for direction behavior
- `ICommand` — abstraction for rover commands
- `CommandParser` — translates `char[]` to `ICommand` instances, supports custom command dictionaries
- `Position` — value object (record) for coordinates

## Run tests
```bash
dotnet test
```
