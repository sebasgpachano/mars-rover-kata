namespace MarsRoverKata;   

public class EastState : IDirectionState
{
    public static readonly EastState Instance = new();
    private EastState() { }

    public Position MoveForward(Position current)  => current with { X = current.X + 1 };
    public Position MoveBackward(Position current) => current with { X = current.X - 1 };
    public IDirectionState TurnLeft()  => NorthState.Instance;
    public IDirectionState TurnRight() => SouthState.Instance;
}