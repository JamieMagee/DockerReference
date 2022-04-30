namespace JamieMagee.DockerReference.Exceptions;

public class DockerReferenceException : Exception
{
    public DockerReferenceException()
    {
    }

    public DockerReferenceException(string message)
        : base(message)
    {
    }

    public DockerReferenceException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
