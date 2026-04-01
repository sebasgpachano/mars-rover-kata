namespace MarsRoverKata;

public class MoveForwardCommand : ICommand
{
    public static readonly MoveForwardCommand Instance = new();
    private MoveForwardCommand() { }

    public void Execute(Rover rover) => rover.MoveForward();
}