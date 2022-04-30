namespace JamieMagee.DockerReference.Test.Data;

using System.Collections;
using JamieMagee.DockerReference.Models;

public class ParseFamiliarNameTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            "docker/docker", new RepositoryReference("docker.io", "docker/docker"),
        };
        yield return new object[]
        {
            "library/debian", new RepositoryReference("docker.io", "library/debian"),
        };
        yield return new object[]
        {
            "debian", new RepositoryReference("docker.io", "library/debian"),
        };
        yield return new object[]
        {
            "docker.io/docker/docker", new RepositoryReference("docker.io", "docker/docker"),
        };
        yield return new object[]
        {
            "docker.io/library/debian", new RepositoryReference("docker.io", "library/debian"),
        };
        yield return new object[]
        {
            "docker.io/debian", new RepositoryReference("docker.io", "library/debian"),
        };
        yield return new object[]
        {
            "index.docker.io/docker/docker", new RepositoryReference("docker.io", "docker/docker"),
        };
        yield return new object[]
        {
            "index.docker.io/library/debian", new RepositoryReference("docker.io", "library/debian"),
        };
        yield return new object[]
        {
            "index.docker.io/debian", new RepositoryReference("docker.io", "library/debian"),
        };
        yield return new object[]
        {
            "127.0.0.1:5000/docker/docker", new RepositoryReference("127.0.0.1:5000", "docker/docker"),
        };
        yield return new object[]
        {
            "127.0.0.1:5000/library/debian", new RepositoryReference("127.0.0.1:5000", "library/debian"),
        };
        yield return new object[]
        {
            "127.0.0.1:5000/debian", new RepositoryReference("127.0.0.1:5000", "debian"),
        };
        yield return new object[]
        {
            "thisisthesongthatneverendsitgoesonandonandonthisisthesongthatnev",
            new RepositoryReference("docker.io", "library/thisisthesongthatneverendsitgoesonandonandonthisisthesongthatnev"),
        };
        yield return new object[]
        {
            "docker.io/1a3f5e7d9c1b3a5f7e9d1c3b5a7f9e1d3c5b7a9f1e3d5d7c9b1a3f5e7d9c1b3aw",
            new RepositoryReference("docker.io", "library/1a3f5e7d9c1b3a5f7e9d1c3b5a7f9e1d3c5b7a9f1e3d5d7c9b1a3f5e7d9c1b3aw"),
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
