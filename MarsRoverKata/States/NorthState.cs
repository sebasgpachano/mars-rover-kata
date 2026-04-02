namespace MarsRoverKata;

public class NorthState : IDirectionState
{
    public static readonly NorthState Instance = new();
    private NorthState() { }

    public Position MoveForward(Position current)  => current with { Y = current.Y + 1 };
    public Position MoveBackward(Position current) => current with { Y = current.Y - 1 };
    public IDirectionState TurnLeft()  => WestState.Instance;
    public IDirectionState TurnRight() => EastState.Instance;
}