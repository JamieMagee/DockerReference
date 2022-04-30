namespace JamieMagee.DockerReference.Exceptions;

public class ReferenceInvalidFormatException : DockerReferenceException
{
    public ReferenceInvalidFormatException()
    {
    }

    public ReferenceInvalidFormatException(string message)
        : base(message)
    {
    }

    public ReferenceInvalidFormatException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
