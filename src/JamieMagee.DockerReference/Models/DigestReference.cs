namespace JamieMagee.DockerReference.Models;

/// <summary>
/// Contains: digest.
/// For example: <code>sha256:10d7d58d5ebd2a652f4d93fdd86da8f265f5318c6a73cc5b6a9798ff6d2b2e67</code>.
/// </summary>
public class DigestReference : IReference
{
    public DigestReference(string digest)
    {
        this.Digest = digest;
    }

    public ReferenceType Type => ReferenceType.Digest;

    public string Digest { get; }

    public override string ToString() => $"{this.Digest}";
}
