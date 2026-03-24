namespace MarsRoverKata;

public class TurnLeftCommand : ICommand
{
    public void Execute(Rover rover)
    {
        rover.TurnLeft();
    }
}