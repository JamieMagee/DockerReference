namespace JamieMagee.DockerReference.Models;

/// <summary>
/// Contains: domain, repository, tag, and digest.
/// For example: <code>docker.io/library/hello-world:latest@sha256:10d7d58d5ebd2a652f4d93fdd86da8f265f5318c6a73cc5b6a9798ff6d2b2e67</code>.
/// </summary>
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
