namespace JamieMagee.DockerReference.Exceptions;

public class InvalidDigestLengthException : DockerReferenceException
{
    public InvalidDigestLengthException()
    {
    }

    public InvalidDigestLengthException(string message)
        : base(message)
    {
    }

    public InvalidDigestLengthException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
