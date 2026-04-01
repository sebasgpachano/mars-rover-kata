namespace MarsRoverKata;

public class TurnRightCommand : ICommand
{
    public void Execute(Rover rover)
    {
        rover.TurnRight();
    }
}