namespace MangaIrusu.ValueObjects.Exceptions;

public class ValueObjectException : Exception
{
    public ValueObjectException()
    {
    }

    public ValueObjectException(string message)
        : base(message)
    {
    }

    public ValueObjectException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
} 