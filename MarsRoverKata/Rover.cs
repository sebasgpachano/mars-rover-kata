namespace MarsRoverKata;

public class Rover
{
    public Position Position { get; }
    public Direction Direction { get; }

    public Rover(Position position, Direction direction)
    {
        Position = position;
        Direction = direction;
    }
}