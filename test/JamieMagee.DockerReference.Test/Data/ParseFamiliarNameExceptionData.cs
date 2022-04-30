namespace JamieMagee.DockerReference.Test.Data;

using System.Collections;
using JamieMagee.DockerReference.Exceptions;

public class ParseFamiliarNameExceptionData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            "https://github.com/docker/docker", typeof(ReferenceInvalidFormatException),
        };
        yield return new object[]
        {
            "docker/Docker", typeof(ReferenceNameContainsUppercaseException),
        };
        yield return new object[]
        {
            "-docker", typeof(ReferenceInvalidFormatException),
        };
        yield return new object[]
        {
            "-docker/docker", typeof(ReferenceInvalidFormatException),
        };
        yield return new object[]
        {
            "-docker.io/docker/docker", typeof(ReferenceInvalidFormatException),
        };
        yield return new object[]
        {
            "docker///docker", typeof(ReferenceInvalidFormatException),
        };
        yield return new object[]
        {
            "docker.io/docker/Docker", typeof(ReferenceNameContainsUppercaseException),
        };
        yield return new object[]
        {
            "docker.io/docker///docker", typeof(ReferenceInvalidFormatException),
        };
        yield return new object[]
        {
            "1a3f5e7d9c1b3a5f7e9d1c3b5a7f9e1d3c5b7a9f1e3d5d7c9b1a3f5e7d9c1b3a", typeof(ReferenceNameNotCanonicalException),
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
