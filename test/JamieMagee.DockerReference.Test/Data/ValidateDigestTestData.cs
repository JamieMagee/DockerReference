namespace JamieMagee.DockerReference.Test.Data;

using System.Collections;

public class ValidateDigestTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            "sha256:e58fcf7418d4390dec8e8fb69d88c06ec07039d651fedd3aa72af9972e7d046b",
        };
        yield return new object[]
        {
            "sha384:d3fc7881460b7e22e3d172954463dddd7866d17597e7248453c48b3e9d26d9596bf9c4a9cf8072c9d5bad76e19af801d",
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
