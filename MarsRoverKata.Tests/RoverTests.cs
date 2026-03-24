using MarsRoverKata;

namespace MarsRoverKata.Tests;

public class RoverTests
{
    [Fact]
    public void Rover_starts_with_initial_position_and_direction()
    {
        var rover = new Rover(new Position(0, 0), Direction.North);

        Assert.Equal(new Position(0, 0), rover.Position);
        Assert.Equal(Direction.North, rover.Direction);
    }

    [Fact]
    public void Moves_forward_when_facing_north()
    {
        var rover = new Rover(new Position(0, 0), Direction.North);

        rover.MoveForward();

        Assert.Equal(new Position(0, 1), rover.Position);
    }

    [Fact]
    public void Moves_backward_when_facing_north()
    {
        var rover = new Rover(new Position(0, 0), Direction.North);

        rover.MoveBackward();

        Assert.Equal(new Position(0, -1), rover.Position);
    }

    [Fact]
    public void Turns_left_from_north_to_west()
    {
        var rover = new Rover(new Position(0, 0), Direction.North);

        rover.TurnLeft();

        Assert.Equal(Direction.West, rover.Direction);
    }

    [Fact]
    public void Turns_left_from_west_to_south()
    {
        var rover = new Rover(new Position(0, 0), Direction.West);

        rover.TurnLeft();

        Assert.Equal(Direction.South, rover.Direction);
    }

    [Fact]
    public void Turns_right_from_north_to_east()
    {
        var rover = new Rover(new Position(0, 0), Direction.North);

        rover.TurnRight();

        Assert.Equal(Direction.East, rover.Direction);
    }

    [Fact]
    public void Turns_right_from_east_to_south()
    {
        var rover = new Rover(new Position(0, 0), Direction.East);

        rover.TurnRight();

        Assert.Equal(Direction.South, rover.Direction);
    }

    [Fact]
    public void Executes_forward_command_with_parser()
    {
        var rover = new Rover(new Position(0, 0), Direction.North);
        var parser = new CommandParser();
        var commands = parser.Parse(new char[] { 'f' });

        rover.Execute(commands);

        Assert.Equal(new Position(0, 1), rover.Position);
    }

    [Fact]
    public void Executes_backward_command_with_parser()
    {
        var rover = new Rover(new Position(0, 0), Direction.North);
        var parser = new CommandParser();
        var commands = parser.Parse(new char[] { 'b' });

        rover.Execute(commands);

        Assert.Equal(new Position(0, -1), rover.Position);
    }

    [Fact]
    public void Executes_turn_left_command_with_parser()
    {
        var rover = new Rover(new Position(0, 0), Direction.North);
        var parser = new CommandParser();
        var commands = parser.Parse(new char[] { 'l' });
    
        rover.Execute(commands);

        Assert.Equal(Direction.West, rover.Direction);
    }

    [Fact]
    public void Executes_turn_right_command_with_parser()
    {
        var rover = new Rover(new Position(0, 0), Direction.North);
        var parser = new CommandParser();
        var commands = parser.Parse(new char[] { 'r' });

        rover.Execute(commands);

        Assert.Equal(Direction.East, rover.Direction);
    }

    [Fact]
    public void Executes_multiple_commands_in_order_with_parser()
    {
        var rover = new Rover(new Position(0, 0), Direction.North);
        var parser = new CommandParser();
        var commands = parser.Parse(new char[] { 'f', 'r', 'l', 'b' });

        rover.Execute(commands);

        Assert.Equal(new Position(1, 0), rover.Position);
        Assert.Equal(Direction.North, rover.Direction);
    }

    [Fact]
    public void Parse_returns_correct_commands()
    {
        var parser = new CommandParser();
        var commands = parser.Parse(new char[] { 'f', 'l', 'r', 'b' }).ToList();
        var rover = new Rover(new Position(0, 0), Direction.North);

        foreach (var cmd in commands)
        {
            cmd.Execute(rover);
        }

        Assert.Equal(new Position(0, 0), rover.Position);
        Assert.Equal(Direction.North, rover.Direction);
    }
}