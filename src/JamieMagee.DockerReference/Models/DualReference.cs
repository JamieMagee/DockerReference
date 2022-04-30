namespace JamieMagee.DockerReference.Models;

public class DualReference : IReference
{
    public DualReference(string domain, string repository, string tag, string digest)
    {
        this.Domain = domain;
        this.Repository = repository;
        this.Tag = tag;
        this.Digest = digest;
    }

    public ReferenceType Type => ReferenceType.Tagged;

    public string Domain { get; }

    public string Repository { get; }

    public string Tag { get; }

    public string Digest { get; }

    public override string ToString() => $"{this.Domain}/{this.Repository}:${this.Tag}@${this.Digest}";
}
