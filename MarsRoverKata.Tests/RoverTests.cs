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
}