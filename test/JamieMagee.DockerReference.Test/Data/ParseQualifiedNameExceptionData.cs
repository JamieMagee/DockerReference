namespace JamieMagee.DockerReference.Test.Data;

using System.Collections;
using JamieMagee.DockerReference.Exceptions;

public class ParseQualifiedNameExceptionData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            string.Empty, typeof(ReferenceNameEmptyException),
        };
        yield return new object[]
        {
            ":justtag", typeof(ReferenceInvalidFormatException),
        };
        yield return new object[]
        {
            "@sha256:ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff",
            typeof(ReferenceInvalidFormatException),
        };
        yield return new object[]
        {
            "repo@sha256:ffffffffffffffffffffffffffffffffff",
            typeof(InvalidDigestLengthException),
        };
        yield return new object[]
        {
            "validname@invaliddigest:ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff",
            typeof(UnsupportedAlgorithmException),
        };
        yield return new object[]
        {
            "Uppercase:tag",
            typeof(ReferenceNameContainsUppercaseException),
        };
        yield return new object[]
        {
            "test:5000/Uppercase/lowercase:tag",
            typeof(ReferenceNameContainsUppercaseException),
        };
        yield return new object[]
        {
            $"{string.Concat(Enumerable.Repeat("a/", 1279))}a:tag",
            typeof(ReferenceNameTooLongException),
        };
        yield return new object[]
        {
            "aa/asdf$$^/aa",
            typeof(ReferenceInvalidFormatException),
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
