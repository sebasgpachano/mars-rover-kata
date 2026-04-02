namespace MarsRoverKata;

public class Rover
{
    public Position Position { get; private set; }
    public IDirectionState State { get; private set; }

    public Rover(Position position, IDirectionState initialState)
    {
        if (position == null) throw new ArgumentNullException(nameof(position));
        if (initialState == null) throw new ArgumentNullException(nameof(initialState));

        Position = position;
        State = initialState;
    }

    public void MoveForward() => Position = State.MoveForward(Position);
    public void MoveBackward() => Position = State.MoveBackward(Position);
    public void TurnLeft() => State = State.TurnLeft();
    public void TurnRight() => State = State.TurnRight();

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