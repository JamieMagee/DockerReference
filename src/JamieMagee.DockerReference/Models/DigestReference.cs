namespace JamieMagee.DockerReference.Models;

// sha256:abc123...
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
