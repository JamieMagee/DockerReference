namespace JamieMagee.DockerReference.Models;

/// <summary>
/// Contains: domain and repository.
/// For example: <code>docker.io/library/hello-world</code>.
/// </summary>
public class RepositoryReference : IReference
{
    public RepositoryReference(string domain, string repository)
    {
        this.Domain = domain;
        this.Repository = repository;
    }

    public ReferenceType Type => ReferenceType.Repository;

    public string Domain { get; }

    public string Repository { get; }

    public override string ToString() => $"{this.Domain}/{this.Repository}";
}
