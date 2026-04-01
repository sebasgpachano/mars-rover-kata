namespace MarsRoverKata;

public class WestState : IDirectionState
{
    public Position MoveForward(Position current)
    {
        return new Position(current.X - 1, current.Y);
    }

    public Position MoveBackward(Position current)
    {
        return new Position(current.X + 1, current.Y);
    }

    public IDirectionState TurnLeft()
    {
        return new SouthState();
    }

    public IDirectionState TurnRight()
    {
        return new NorthState();
    }
}