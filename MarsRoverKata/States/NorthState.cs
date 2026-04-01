namespace MarsRoverKata;

public class NorthState : IDirectionState
{
    public Position MoveForward(Position current)
    {
        return new Position(current.X, current.Y + 1);
    }

    public Position MoveBackward(Position current)
    {
        return new Position(current.X, current.Y - 1);
    }

    public IDirectionState TurnLeft()
    {
        return new WestState();
    }

    public IDirectionState TurnRight()
    {
        return new EastState();
    }
}