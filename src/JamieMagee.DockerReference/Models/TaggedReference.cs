namespace JamieMagee.DockerReference.Models;

/// <summary>
/// Contains: domain, repository, and tag.
/// For example: <code>docker.io/library/hello-world:latest</code>.
/// </summary>
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
