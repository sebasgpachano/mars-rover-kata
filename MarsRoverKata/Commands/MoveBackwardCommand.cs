namespace MarsRoverKata;

public class MoveBackwardCommand : ICommand
{
    public void Execute(Rover rover)
    {
        rover.MoveBackward();
    }
}