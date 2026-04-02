namespace MarsRoverKata.Tests;

public class CommandParserTests
{
    [Fact]
    public void Parse_maps_each_char_to_correct_command_type()
    {
        var parser = new CommandParser();

        var commands = parser.Parse(new[] { 'f', 'b', 'l', 'r' }).ToList();

        Assert.IsType<MoveForwardCommand>(commands[0]);
        Assert.IsType<MoveBackwardCommand>(commands[1]);
        Assert.IsType<TurnLeftCommand>(commands[2]);
        Assert.IsType<TurnRightCommand>(commands[3]);
    }

    [Fact]
    public void Parse_reuses_singleton_instances()
    {
        var parser = new CommandParser();

        var first = parser.Parse(new[] { 'f' }).ToList();
        var second = parser.Parse(new[] { 'f' }).ToList();

        Assert.Same(first[0], second[0]);
    }

    [Fact]
    public void Parse_accepts_custom_command_dictionary()
    {
        var customCommands = new Dictionary<char, ICommand>
        {
            { 'x', MoveForwardCommand.Instance }
        };
        var parser = new CommandParser(customCommands);

        var commands = parser.Parse(new[] { 'x' }).ToList();

        Assert.IsType<MoveForwardCommand>(commands[0]);
    }

    [Fact]
    public void Parse_throws_when_input_is_null()
    {
        var parser = new CommandParser();

        Assert.Throws<ArgumentNullException>(() => parser.Parse(null!));
    }

    [Fact]
    public void Parse_throws_on_invalid_command()
    {
        var parser = new CommandParser();

        Assert.Throws<ArgumentException>(() => parser.Parse(new[] { 'z' }).ToList());
    }
}