namespace MarsRoverKata;

public interface IDirectionState
{
    Position MoveForward(Position current);
    Position MoveBackward(Position current);
    IDirectionState TurnLeft();
    IDirectionState TurnRight();
}