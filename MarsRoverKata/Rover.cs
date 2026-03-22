namespace MarsRoverKata;

public class Rover
{
    public Position Position { get; private set; }
    public Direction Direction { get; private set; }

    public Rover(Position position, Direction direction)
    {
        Position = position;
        Direction = direction;
    }

    public void MoveForward()
    {
        Position = Direction switch
        {
            Direction.North => new Position(Position.X, Position.Y + 1),
        Direction.South => new Position(Position.X, Position.Y - 1),
        Direction.East  => new Position(Position.X + 1, Position.Y),
        Direction.West  => new Position(Position.X - 1, Position.Y),
        _ => Position
        };
    }

    public void MoveBackward()
    {
        Position = Direction switch
        {
            Direction.North => new Position(Position.X, Position.Y - 1),
            Direction.South => new Position(Position.X, Position.Y + 1),
            Direction.East  => new Position(Position.X - 1, Position.Y),
            Direction.West  => new Position(Position.X + 1, Position.Y),
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
        foreach (var command in commands)
        {
            switch (command)
            {
                case 'f': MoveForward(); break;
                case 'b': MoveBackward(); break;
                case 'l': TurnLeft(); break;
                case 'r': TurnRight(); break;
                default: throw new ArgumentException($"Invalid command '{command}'");
            }
        }
    }
}