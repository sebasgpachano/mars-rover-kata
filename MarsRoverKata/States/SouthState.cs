namespace MarsRoverKata;

public class SouthState : IDirectionState
{
    public static readonly SouthState Instance = new();
    private SouthState() { }

    public Position MoveForward(Position current)  => current with { Y = current.Y - 1 };
    public Position MoveBackward(Position current) => current with { Y = current.Y + 1 };
    public IDirectionState TurnLeft()  => EastState.Instance;
    public IDirectionState TurnRight() => WestState.Instance;
}