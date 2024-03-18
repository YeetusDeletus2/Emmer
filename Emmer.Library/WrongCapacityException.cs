namespace Emmer.Library;

public class WrongCapacityException : ArgumentException
{
    public WrongCapacityException(string paramName, string message)
        : base(message, paramName)
    {
    }
}