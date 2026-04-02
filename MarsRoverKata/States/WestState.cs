namespace MarsRoverKata;

public class WestState : IDirectionState
{
    public static readonly WestState Instance = new();
    private WestState() { }

    public Position MoveForward(Position current) => current with { X = current.X - 1 };
    public Position MoveBackward(Position current) => current with { X = current.X + 1 };
    public IDirectionState TurnLeft() => SouthState.Instance;
    public IDirectionState TurnRight() => NorthState.Instance;
}