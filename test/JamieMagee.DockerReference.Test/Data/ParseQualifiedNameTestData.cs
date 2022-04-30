namespace JamieMagee.DockerReference.Test;

using System.Collections;
using JamieMagee.DockerReference.Models;

public class ParseQualifiedNameTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            "test_com", new RepositoryReference(string.Empty, "test_com"),
        };
        yield return new object[]
        {
            "test.com:tag", new TaggedReference(string.Empty, "test.com", "tag"),
        };
        yield return new object[]
        {
            "test.com:5000", new TaggedReference(string.Empty, "test.com", "5000"),
        };
        yield return new object[]
        {
            "test.com/repo:tag", new TaggedReference("test.com", "repo", "tag"),
        };
        yield return new object[]
        {
            "test.com:5000/repo", new RepositoryReference("test.com:5000", "repo"),
        };
        yield return new object[]
        {
            "test:5000/repo:tag", new TaggedReference("test:5000", "repo", "tag"),
        };
        yield return new object[]
        {
            "test:5000/repo@sha256:ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff",
            new CanonicalReference("test:5000", "repo", "sha256:ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff"),
        };
        yield return new object[]
        {
            "test:5000/repo:tag@sha256:ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff",
            new DualReference("test:5000", "repo", "tag", "sha256:ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff"),
        };
        yield return new object[]
        {
            "lowercase:Uppercase",
            new TaggedReference(string.Empty, "lowercase", "Uppercase"),
        };
        yield return new object[]
        {
            $"{string.Concat(Enumerable.Repeat("a/", 127))}a:tag-puts-this-over-max",
            new TaggedReference("a", $"{string.Concat(Enumerable.Repeat("a/", 126))}a", "tag-puts-this-over-max"),
        };
        yield return new object[]
        {
            "sub-dom1.foo.com/bar/baz/quux",
            new RepositoryReference("sub-dom1.foo.com", "bar/baz/quux"),
        };
        yield return new object[]
        {
            "sub-dom1.foo.com/bar/baz/quux:some-long-tag",
            new TaggedReference("sub-dom1.foo.com", "bar/baz/quux", "some-long-tag"),
        };
        yield return new object[]
        {
            "b.gcr.io/test.example.com/my-app:test.example.com",
            new TaggedReference("b.gcr.io", "test.example.com/my-app", "test.example.com"),
        };
        yield return new object[]
        {
            "xn--n3h.com/myimage:xn--n3h.com",
            new TaggedReference("xn--n3h.com", "myimage", "xn--n3h.com"),
        };
        yield return new object[]
        {
            "xn--7o8h.com/myimage:xn--7o8h.com@sha512:ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff",
            new DualReference("xn--7o8h.com", "myimage", "xn--7o8h.com", "sha512:ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff"),
        };
        yield return new object[]
        {
            "foo_bar.com:8080",
            new TaggedReference(string.Empty, "foo_bar.com", "8080"),
        };
        yield return new object[]
        {
            "foo/foo_bar.com:8080",
            new TaggedReference("foo", "foo_bar.com", "8080"),
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
