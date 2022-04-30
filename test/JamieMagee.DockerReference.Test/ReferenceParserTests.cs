namespace JamieMagee.DockerReference.Test;

using System.Reflection;
using FluentAssertions;
using JamieMagee.DockerReference.Exceptions;
using JamieMagee.DockerReference.Models;
using JamieMagee.DockerReference.Test.Data;
using Xunit;

public class ReferenceParserTests
{
    [Theory]
    [ClassData(typeof(ParseAllTestData))]
    public void ShouldParseAll(string input, IReference reference)
    {
        var result = ReferenceParser.ParseAll(input);
        result.Should().BeEquivalentTo(reference, options => options.RespectingRuntimeTypes());
    }

    [Theory]
    [ClassData(typeof(ParseFamiliarNameTestData))]
    public void ShouldParseFamiliarName(string input, IReference reference)
    {
        var result = ReferenceParser.ParseFamiliarName(input);
        result.Should().BeEquivalentTo(reference, options => options.RespectingRuntimeTypes());
    }

    [Theory]
    [ClassData(typeof(ParseFamiliarNameExceptionData))]
    public void ShouldThrowParseFamiliarName(string input, Type expectedException)
    {
        var result = () => ReferenceParser.ParseFamiliarName(input);
        result.Should().Throw<DockerReferenceException>()
            .Where(ex => ex.GetType() == expectedException);
    }

    [Theory]
    [ClassData(typeof(ParseQualifiedNameTestData))]
    public void ShouldParseQualifiedName(string input, IReference reference)
    {
        var result = ReferenceParser.ParseQualifiedName(input);
        result.Should().BeEquivalentTo(reference, options => options.RespectingRuntimeTypes());
    }

    [Theory]
    [ClassData(typeof(ParseQualifiedNameExceptionData))]
    public void ShouldThrowParseQualifiedName(string input, Type expectedException)
    {
        var result = () => ReferenceParser.ParseQualifiedName(input);
        result.Should().Throw<DockerReferenceException>()
            .Where(ex => ex.GetType() == expectedException);
    }
}
