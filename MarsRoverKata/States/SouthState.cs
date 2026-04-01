namespace MarsRoverKata;

public class SouthState : IDirectionState
{
    public Position MoveForward(Position current)
    {
        return new Position(current.X, current.Y - 1);
    }

    public Position MoveBackward(Position current)
    {
        return new Position(current.X, current.Y + 1);
    }

    public IDirectionState TurnLeft()
    {
        return new EastState();
    }

    public IDirectionState TurnRight()
    {
        return new WestState();
    }
}