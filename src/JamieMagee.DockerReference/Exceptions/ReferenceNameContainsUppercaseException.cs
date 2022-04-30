namespace JamieMagee.DockerReference.Exceptions;

public class ReferenceNameContainsUppercaseException : DockerReferenceException
{
    public ReferenceNameContainsUppercaseException()
    {
    }

    public ReferenceNameContainsUppercaseException(string message)
        : base(message)
    {
    }

    public ReferenceNameContainsUppercaseException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
