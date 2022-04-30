namespace JamieMagee.DockerReference.Exceptions;

public class ReferenceNameTooLongException : DockerReferenceException
{
    public ReferenceNameTooLongException()
    {
    }

    public ReferenceNameTooLongException(string message)
        : base(message)
    {
    }

    public ReferenceNameTooLongException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
