namespace JamieMagee.DockerReference.Models;

public class TaggedReference : IReference
{
    public TaggedReference(string domain, string repository, string tag)
    {
        this.Domain = domain;
        this.Repository = repository;
        this.Tag = tag;
    }

    public ReferenceType Type => ReferenceType.Tagged;

    public string Domain { get; }

    public string Repository { get; }

    public string Tag { get; }

    public override string ToString() => $"{this.Domain}/{this.Repository}:{this.Tag}";
}
