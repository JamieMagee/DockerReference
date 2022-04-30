namespace JamieMagee.DockerReference.Test.Data;

using System.Collections;
using JamieMagee.DockerReference.Exceptions;

public class ValidateDigestExceptionData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            "sha256:", typeof(InvalidDigestFormatException),
        };
        yield return new object[]
        {
            string.Empty, typeof(InvalidDigestFormatException),
        };
        yield return new object[]
        {
            "d41d8cd98f00b204e9800998ecf8427e", typeof(InvalidDigestFormatException),
        };
        yield return new object[]
        {
            "sha256:d41d8cd98f00b204e9800m98ecf8427e", typeof(InvalidDigestFormatException),
        };
        yield return new object[]
        {
            "sha256:abcdef0123456789", typeof(InvalidDigestFormatException),
        };
        yield return new object[]
        {
            "sha512:abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789", typeof(InvalidDigestLengthException),
        };
        yield return new object[]
        {
            "foo:d41d8cd98f00b204e9800998ecf8427e", typeof(UnsupportedAlgorithmException),
        };
        yield return new object[]
        {
            "sha384__foo+bar:d3fc7881460b7e22e3d172954463dddd7866d17597e7248453c48b3e9d26d9596bf9c4a9cf8072c9d5bad76e19af801d", typeof(InvalidDigestFormatException),
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
