namespace JamieMagee.DockerReference.Exceptions;

public class ReferenceNameNotCanonicalException : DockerReferenceException
{
    public ReferenceNameNotCanonicalException()
    {
    }

    public ReferenceNameNotCanonicalException(string message)
        : base(message)
    {
    }

    public ReferenceNameNotCanonicalException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
