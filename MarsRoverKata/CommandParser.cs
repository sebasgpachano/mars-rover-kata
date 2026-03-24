namespace MarsRoverKata;

public class CommandParser
{
    public IEnumerable<ICommand> Parse(char[] commands)
    {
        if (commands == null) throw new ArgumentNullException(nameof(commands));

        foreach (var command in commands)
        {
            yield return command switch
        {
            'f' => new MoveForwardCommand(),
            'b' => new MoveBackwardCommand(),
            'l' => new TurnLeftCommand(),
            'r' => new TurnRightCommand(),
            _ => throw new ArgumentException($"Invalid command '{command}' in command string.")
        };
        }
    }
}