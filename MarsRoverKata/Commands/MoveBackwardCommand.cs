namespace MarsRoverKata;

public class MoveBackwardCommand : ICommand
{
    public static readonly MoveBackwardCommand Instance = new();
    private MoveBackwardCommand() { }

    public void Execute(Rover rover) => rover.MoveBackward();
}