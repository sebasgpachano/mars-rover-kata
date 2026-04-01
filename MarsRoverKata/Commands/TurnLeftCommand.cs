namespace MarsRoverKata;

public class TurnLeftCommand : ICommand
{
    public static readonly TurnLeftCommand Instance = new();
    private TurnLeftCommand() { }

    public void Execute(Rover rover) => rover.TurnLeft();
}