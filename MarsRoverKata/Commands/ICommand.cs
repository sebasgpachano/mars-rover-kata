namespace MarsRoverKata;

public interface ICommand
{
    void Execute(Rover rover);
}