namespace MarsRoverKata;

public class Rover
{
    public Position Position { get; private set; }
    public Direction Direction { get; private set; }

    public Rover(Position position, Direction direction)
    {
        if (position == null) throw new ArgumentNullException(nameof(position));
        
        Position = position;
        Direction = direction;
    }

    public void MoveForward()
    {
        Position = GetNextPosition(1);
    }

    public void MoveBackward()
    {
        Position = GetNextPosition(-1);
    }

    private Position GetNextPosition(int step)
    {
        return Direction switch
        {
            Direction.North => new Position(Position.X, Position.Y + step),
            Direction.South => new Position(Position.X, Position.Y - step),
            Direction.East  => new Position(Position.X + step, Position.Y),
            Direction.West  => new Position(Position.X - step, Position.Y),
            _ => Position
        };
    }

    public void TurnLeft()
    {
        Direction = Direction switch
        {
            Direction.North => Direction.West,
            Direction.West  => Direction.South,
            Direction.South => Direction.East,
            Direction.East  => Direction.North,
            _ => Direction
        };
    }

    public void TurnRight()
    {
        Direction = Direction switch
        {
            Direction.North => Direction.East,
            Direction.East  => Direction.South,
            Direction.South => Direction.West,
            Direction.West  => Direction.North,
            _ => Direction
        };
    }

    public void Execute(char[] commands)
    {
        if (commands == null) throw new ArgumentNullException(nameof(commands));

        foreach (var command in commands)
        {
            switch (char.ToLower(command))
            {
                case 'f': MoveForward(); break;
                case 'b': MoveBackward(); break;
                case 'l': TurnLeft(); break;
                case 'r': TurnRight(); break;
                default: throw new ArgumentException($"Invalid command '{command}'");
            }
        }
    }

    public void Execute(IEnumerable<ICommand> commands)
{
    if (commands == null)
        throw new ArgumentNullException(nameof(commands));

    foreach (var command in commands)
    {
        if (command == null)
            throw new ArgumentException("Command cannot be null", nameof(commands));

        command.Execute(this);
    }
}
}