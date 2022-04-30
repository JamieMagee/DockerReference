namespace JamieMagee.DockerReference.Models;

public class CanonicalReference : IReference
{
    public CanonicalReference(string domain, string repository, string digest)
    {
        this.Domain = domain;
        this.Repository = repository;
        this.Digest = digest;
    }

    public ReferenceType Type => ReferenceType.Canonical;

    public string Domain { get; }

    public string Digest { get; }

    public string Repository { get; }

    public override string ToString() => $"{this.Domain}/{this.Repository}:{this.Digest}";
}
