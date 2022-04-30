namespace JamieMagee.DockerReference.Test;

using FluentAssertions;
using JamieMagee.DockerReference.Exceptions;
using JamieMagee.DockerReference.Test.Data;
using Xunit;

public class DigestUtilityTests
{
    [Theory]
    [ClassData(typeof(ValidateDigestTestData))]
    public void ShouldValidateDigest(string input)
    {
        var result = DigestUtility.CheckDigest(input);
        result.Should().Be(true);
    }

    [Theory]
    [ClassData(typeof(ValidateDigestExceptionData))]
    public void ShouldThrowValidateDigest(string input, Type expectedException)
    {
        var result = () => DigestUtility.CheckDigest(input);
        result.Should().Throw<DockerReferenceException>()
            .Where(ex => ex.GetType() == expectedException);
    }
}
