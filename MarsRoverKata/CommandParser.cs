namespace MarsRoverKata;

public class CommandParser
{
    private static readonly Dictionary<char, ICommand> DefaultCommands = new()
    {
        { 'f', MoveForwardCommand.Instance },
        { 'b', MoveBackwardCommand.Instance },
        { 'l', TurnLeftCommand.Instance },
        { 'r', TurnRightCommand.Instance }
    };

    private readonly Dictionary<char, ICommand> _commands;

    public CommandParser(Dictionary<char, ICommand>? commands = null)
    {
        _commands = commands ?? DefaultCommands;
    }

    public IEnumerable<ICommand> Parse(char[] input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        return ParseCommands(input);
    }

    private IEnumerable<ICommand> ParseCommands(char[] input)
    {
        foreach (var c in input)
        {
            if (!_commands.TryGetValue(c, out var command))
                throw new ArgumentException($"Invalid command '{c}'");

            yield return command;
        }
    }
}