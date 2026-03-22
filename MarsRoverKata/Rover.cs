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
}