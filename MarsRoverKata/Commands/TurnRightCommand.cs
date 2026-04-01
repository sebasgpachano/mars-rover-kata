namespace MarsRoverKata;

public class TurnRightCommand : ICommand
{
    public static readonly TurnRightCommand Instance = new();
    private TurnRightCommand() { }

    public void Execute(Rover rover) => rover.TurnRight();
}