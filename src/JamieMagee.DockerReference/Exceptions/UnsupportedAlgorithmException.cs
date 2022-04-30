namespace JamieMagee.DockerReference.Exceptions;

public class UnsupportedAlgorithmException : DockerReferenceException
{
    public UnsupportedAlgorithmException()
    {
    }

    public UnsupportedAlgorithmException(string message)
        : base(message)
    {
    }

    public UnsupportedAlgorithmException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
