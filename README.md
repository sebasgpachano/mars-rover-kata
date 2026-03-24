# Mars Rover Kata

## Overview
Implementation of the Mars Rover Kata in C# using .NET.  
The rover moves on a grid, executing commands to move forward/backward and rotate left/right.

## Approach
The solution was developed incrementally following a TDD approach, introducing behavior step by step without anticipating future requirements.

## Design
- `Rover` handles movement and command execution  
- Commands are mapped to actions for clarity and extensibility  
- `Position` is a value object (record)

## Run tests
```bash
dotnet test
