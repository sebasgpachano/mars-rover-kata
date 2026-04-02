namespace MarsRoverKata.Tests;

public class DirectionStateTests
{
    [Theory]
    [MemberData(nameof(MoveForwardCases))]
    public void MoveForward_returns_correct_position(IDirectionState state, int x, int y, int expectedX, int expectedY)
    {
        var result = state.MoveForward(new Position(x, y));
        Assert.Equal(new Position(expectedX, expectedY), result);
    }

    public static IEnumerable<object[]> MoveForwardCases =>
        new List<object[]>
        {
            new object[] { NorthState.Instance, 0, 0, 0, 1 },
            new object[] { EastState.Instance,  0, 0, 1, 0 },
            new object[] { SouthState.Instance, 0, 0, 0, -1 },
            new object[] { WestState.Instance,  0, 0, -1, 0 }
        };

    [Theory]
    [MemberData(nameof(MoveBackwardCases))]
    public void MoveBackward_returns_correct_position(IDirectionState state, int x, int y, int expectedX, int expectedY)
    {
        var result = state.MoveBackward(new Position(x, y));
        Assert.Equal(new Position(expectedX, expectedY), result);
    }

    public static IEnumerable<object[]> MoveBackwardCases =>
        new List<object[]>
        {
            new object[] { NorthState.Instance, 0, 0, 0, -1 },
            new object[] { EastState.Instance,  0, 0, -1, 0 },
            new object[] { SouthState.Instance, 0, 0, 0, 1 },
            new object[] { WestState.Instance,  0, 0, 1, 0 }
        };

    [Theory]
    [MemberData(nameof(TurnLeftCases))]
    public void TurnLeft_returns_correct_state(IDirectionState initial, Type expectedType)
    {
        Assert.IsType(expectedType, initial.TurnLeft());
    }

    public static IEnumerable<object[]> TurnLeftCases =>
        new List<object[]>
        {
            new object[] { NorthState.Instance, typeof(WestState) },
            new object[] { WestState.Instance, typeof(SouthState) },
            new object[] { SouthState.Instance, typeof(EastState) },
            new object[] { EastState.Instance, typeof(NorthState) }
        };

    [Theory]
    [MemberData(nameof(TurnRightCases))]
    public void TurnRight_returns_correct_state(IDirectionState initial, Type expectedType)
    {
        Assert.IsType(expectedType, initial.TurnRight());
    }

    public static IEnumerable<object[]> TurnRightCases =>
        new List<object[]>
        {
            new object[] { NorthState.Instance, typeof(EastState) },
            new object[] { EastState.Instance, typeof(SouthState) },
            new object[] { SouthState.Instance, typeof(WestState) },
            new object[] { WestState.Instance, typeof(NorthState) }
        };
}