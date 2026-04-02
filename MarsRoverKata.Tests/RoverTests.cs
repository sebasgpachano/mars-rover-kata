namespace MarsRoverKata.Tests;

public class RoverTests
{
    [Fact]
    public void Rover_starts_with_initial_position_and_state()
    {
        var rover = new Rover(new Position(0, 0), NorthState.Instance);

        Assert.Equal(new Position(0, 0), rover.Position);
        Assert.IsType<NorthState>(rover.State);
    }

    [Fact]
    public void Moves_forward_when_facing_north()
    {
        var rover = new Rover(new Position(0, 0), NorthState.Instance);

        rover.MoveForward();

        Assert.Equal(new Position(0, 1), rover.Position);
    }

    [Fact]
    public void Moves_backward_when_facing_north()
    {
        var rover = new Rover(new Position(0, 0), NorthState.Instance);

        rover.MoveBackward();

        Assert.Equal(new Position(0, -1), rover.Position);
    }

    [Theory]
    [MemberData(nameof(TurnLeftCases))]
    public void TurnLeft_cycles_through_all_states(IDirectionState initial, Type expectedType)
    {
        var rover = new Rover(new Position(0, 0), initial);

        rover.TurnLeft();

        Assert.IsType(expectedType, rover.State);
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
    public void TurnRight_cycles_through_all_states(IDirectionState initial, Type expectedType)
    {
        var rover = new Rover(new Position(0, 0), initial);

        rover.TurnRight();

        Assert.IsType(expectedType, rover.State);
    }

    public static IEnumerable<object[]> TurnRightCases =>
        new List<object[]>
        {
            new object[] { NorthState.Instance, typeof(EastState) },
            new object[] { EastState.Instance, typeof(SouthState) },
            new object[] { SouthState.Instance, typeof(WestState) },
            new object[] { WestState.Instance, typeof(NorthState) }
        };

    [Fact]
    public void Executes_forward_command_with_parser()
    {
        var rover = new Rover(new Position(0, 0), NorthState.Instance);
        var parser = new CommandParser();
        var commands = parser.Parse(new char[] { 'f' });

        rover.Execute(commands);

        Assert.Equal(new Position(0, 1), rover.Position);
    }

    [Fact]
    public void Executes_backward_command_with_parser()
    {
        var rover = new Rover(new Position(0, 0), NorthState.Instance);
        var parser = new CommandParser();
        var commands = parser.Parse(new char[] { 'b' });

        rover.Execute(commands);

        Assert.Equal(new Position(0, -1), rover.Position);
    }

    [Fact]
    public void Executes_turn_left_command_with_parser()
    {
        var rover = new Rover(new Position(0, 0), NorthState.Instance);
        var parser = new CommandParser();
        var commands = parser.Parse(new char[] { 'l' });

        rover.Execute(commands);

        Assert.IsType<WestState>(rover.State);
    }

    [Fact]
    public void Executes_turn_right_command_with_parser()
    {
        var rover = new Rover(new Position(0, 0), NorthState.Instance);
        var parser = new CommandParser();
        var commands = parser.Parse(new char[] { 'r' });

        rover.Execute(commands);

        Assert.IsType<EastState>(rover.State);
    }

    [Fact]
    public void Executes_multiple_commands_in_order()
    {
        var rover = new Rover(new Position(0, 0), NorthState.Instance);
        var parser = new CommandParser();
        var commands = parser.Parse(new char[] { 'f', 'r', 'l', 'b' });

        rover.Execute(commands);

        Assert.Equal(new Position(0, 0), rover.Position);
        Assert.IsType<NorthState>(rover.State);
    }

    [Fact]
    public void Execute_throws_when_commands_is_null()
    {
        var rover = new Rover(new Position(0, 0), NorthState.Instance);

        Assert.Throws<ArgumentNullException>(() => rover.Execute(null!));
    }
}