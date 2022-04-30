namespace JamieMagee.DockerReference.Test.Data;

using System.Collections;
using JamieMagee.DockerReference.Models;

public class ParseAllTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            "redis", new RepositoryReference("docker.io", "library/redis"),
        };
        yield return new object[]
        {
            "redis:latest", new TaggedReference("docker.io", "library/redis", "latest"),
        };
        yield return new object[]
        {
            "docker.io/library/redis:latest", new TaggedReference("docker.io", "library/redis", "latest"),
        };
        yield return new object[]
        {
            "redis@sha256:dbcc1c35ac38df41fd2f5e4130b32ffdb93ebae8b3dbe638c23575912276fc9c",
            new CanonicalReference("docker.io", "library/redis", "sha256:dbcc1c35ac38df41fd2f5e4130b32ffdb93ebae8b3dbe638c23575912276fc9c"),
        };
        yield return new object[]
        {
            "docker.io/library/redis@sha256:dbcc1c35ac38df41fd2f5e4130b32ffdb93ebae8b3dbe638c23575912276fc9c",
            new CanonicalReference("docker.io", "library/redis", "sha256:dbcc1c35ac38df41fd2f5e4130b32ffdb93ebae8b3dbe638c23575912276fc9c"),
        };
        yield return new object[]
        {
            "dmcgowan/myapp", new RepositoryReference("docker.io", "dmcgowan/myapp"),
        };
        yield return new object[]
        {
            "dmcgowan/myapp:latest", new TaggedReference("docker.io", "dmcgowan/myapp", "latest"),
        };
        yield return new object[]
        {
            "docker.io/dmcgowan/myapp:latest", new TaggedReference("docker.io", "dmcgowan/myapp", "latest"),
        };
        yield return new object[]
        {
            "dmcgowan/myapp@sha256:dbcc1c35ac38df41fd2f5e4130b32ffdb93ebae8b3dbe638c23575912276fc9c",
            new CanonicalReference("docker.io", "dmcgowan/myapp", "sha256:dbcc1c35ac38df41fd2f5e4130b32ffdb93ebae8b3dbe638c23575912276fc9c"),
        };
        yield return new object[]
        {
            "docker.io/dmcgowan/myapp@sha256:dbcc1c35ac38df41fd2f5e4130b32ffdb93ebae8b3dbe638c23575912276fc9c",
            new CanonicalReference("docker.io", "dmcgowan/myapp", "sha256:dbcc1c35ac38df41fd2f5e4130b32ffdb93ebae8b3dbe638c23575912276fc9c"),
        };
        yield return new object[]
        {
            "dbcc1c35ac38df41fd2f5e4130b32ffdb93ebae8b3dbe638c23575912276fc9c",
            new DigestReference("sha256:dbcc1c35ac38df41fd2f5e4130b32ffdb93ebae8b3dbe638c23575912276fc9c"),
        };
        yield return new object[]
        {
            "sha256:dbcc1c35ac38df41fd2f5e4130b32ffdb93ebae8b3dbe638c23575912276fc9c",
            new DigestReference("sha256:dbcc1c35ac38df41fd2f5e4130b32ffdb93ebae8b3dbe638c23575912276fc9c"),
        };
        yield return new object[]
        {
            "dbcc1c35ac38df41fd2f5e4130b32ffdb93ebae8b3dbe638c23575912276fc9",
            new RepositoryReference("docker.io", "library/dbcc1c35ac38df41fd2f5e4130b32ffdb93ebae8b3dbe638c23575912276fc9"),
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
