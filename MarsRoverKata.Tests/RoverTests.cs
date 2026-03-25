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

    [Theory]
    [InlineData(Direction.North, Direction.West)]
    [InlineData(Direction.West,  Direction.South)]
    [InlineData(Direction.South, Direction.East)]
    [InlineData(Direction.East,  Direction.North)]
    public void TurnLeft_cycles_through_all_directions(Direction initial, Direction expected)
    {
        var rover = new Rover(new Position(0, 0), initial);

        rover.TurnLeft();

        Assert.Equal(expected, rover.Direction);
    }

    [Theory]
    [InlineData(Direction.North, Direction.East)]
    [InlineData(Direction.East,  Direction.South)]
    [InlineData(Direction.South, Direction.West)]
    [InlineData(Direction.West,  Direction.North)]
    public void TurnRight_cycles_through_all_directions(Direction initial, Direction expected)
    {
        var rover = new Rover(new Position(0, 0), initial);

        rover.TurnRight();

        Assert.Equal(expected, rover.Direction);
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
    public void Execute_throws_when_commands_is_null()
    {
        var rover = new Rover(new Position(0, 0), Direction.North);

        Assert.Throws<ArgumentNullException>(() => rover.Execute(null!));
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

    [Fact]
    public void Parse_throws_when_input_is_null()
    {
        var parser = new CommandParser();

        Assert.Throws<ArgumentNullException>(() => parser.Parse(null!));
    }

    [Fact]
    public void Parse_throws_on_invalid_command()
    {
        var parser = new CommandParser();

        Assert.Throws<ArgumentException>(() => parser.Parse(new[] { 'z' }).ToList());
    }
}