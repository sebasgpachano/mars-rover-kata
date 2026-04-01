using MarsRoverKata;

namespace MarsRoverKata.Tests;

public class DirectionStateTests
{
    [Theory]
    [InlineData(typeof(NorthState), 0, 0, 0, 1)]
    [InlineData(typeof(EastState),  0, 0, 1, 0)]
    [InlineData(typeof(SouthState), 0, 0, 0, -1)]
    [InlineData(typeof(WestState),  0, 0, -1, 0)]
    public void MoveForward_returns_correct_position(Type stateType, int x, int y, int expectedX, int expectedY)
    {
        var state = (IDirectionState)Activator.CreateInstance(stateType)!;
        var result = state.MoveForward(new Position(x, y));
        Assert.Equal(new Position(expectedX, expectedY), result);
    }

    [Theory]
    [InlineData(typeof(NorthState), 0, 0, 0, -1)]
    [InlineData(typeof(EastState),  0, 0, -1, 0)]
    [InlineData(typeof(SouthState), 0, 0, 0, 1)]
    [InlineData(typeof(WestState),  0, 0, 1, 0)]
    public void MoveBackward_returns_correct_position(Type stateType, int x, int y, int expectedX, int expectedY)
    {
        var state = (IDirectionState)Activator.CreateInstance(stateType)!;
        var result = state.MoveBackward(new Position(x, y));
        Assert.Equal(new Position(expectedX, expectedY), result);
    }

    [Theory]
    [InlineData(typeof(NorthState), typeof(WestState))]
    [InlineData(typeof(WestState),  typeof(SouthState))]
    [InlineData(typeof(SouthState), typeof(EastState))]
    [InlineData(typeof(EastState),  typeof(NorthState))]
    public void TurnLeft_returns_correct_state(Type initialType, Type expectedType)
    {
        var state = (IDirectionState)Activator.CreateInstance(initialType)!;
        Assert.IsType(expectedType, state.TurnLeft());
    }

    [Theory]
    [InlineData(typeof(NorthState), typeof(EastState))]
    [InlineData(typeof(EastState),  typeof(SouthState))]
    [InlineData(typeof(SouthState), typeof(WestState))]
    [InlineData(typeof(WestState),  typeof(NorthState))]
    public void TurnRight_returns_correct_state(Type initialType, Type expectedType)
    {
        var state = (IDirectionState)Activator.CreateInstance(initialType)!;
        Assert.IsType(expectedType, state.TurnRight());
    }
}