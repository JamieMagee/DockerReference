namespace JamieMagee.DockerReference.Exceptions;

public class InvalidDigestFormatException : DockerReferenceException
{
    public InvalidDigestFormatException()
    {
    }

    public InvalidDigestFormatException(string message)
        : base(message)
    {
    }

    public InvalidDigestFormatException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
