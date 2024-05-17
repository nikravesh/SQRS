namespace SQRSSample.Domain.Framework.Exceptions;

public class InvalidEntityStateException : DomainStateException
{
    public InvalidEntityStateException(string message, params string[] parameters)
        : base(message)
    {
        Parameters = parameters;
    }
}
