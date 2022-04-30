namespace JamieMagee.DockerReference.Exceptions;

public class ReferenceNameEmptyException : DockerReferenceException
{
    public ReferenceNameEmptyException()
    {
    }

    public ReferenceNameEmptyException(string message)
        : base(message)
    {
    }

    public ReferenceNameEmptyException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
