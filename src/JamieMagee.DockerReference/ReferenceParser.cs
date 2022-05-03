namespace JamieMagee.DockerReference;

using System.Globalization;
using JamieMagee.DockerReference.Exceptions;
using JamieMagee.DockerReference.Models;

public sealed class ReferenceParser
{
    // NameTotalLengthMax is the maximum total number of characters in a repository name.
    private const int NameTotalLengthMax = 255;
    private const string DefaultDomain = "docker.io";
    private const string LegacyDefaultDomain = "index.docker.io";
    private const string OfficialRepositoryName = "library";

    public static IReference ParseQualifiedName(string qualifiedName)
    {
        var regexp = ReferenceRegex.Reference;
        if (!regexp.IsMatch(qualifiedName))
        {
            if (string.IsNullOrWhiteSpace(qualifiedName))
            {
                throw new ReferenceNameEmptyException(qualifiedName);
            }

            if (regexp.IsMatch(qualifiedName.ToLower(CultureInfo.InvariantCulture)))
            {
                throw new ReferenceNameContainsUppercaseException(qualifiedName);
            }

            throw new ReferenceInvalidFormatException(qualifiedName);
        }

        var matches = regexp.Match(qualifiedName).Groups;

        var name = matches[1].Value;
        if (name.Length > NameTotalLengthMax)
        {
            throw new ReferenceNameTooLongException(name);
        }

        string? domain = null;
        string? repository = null;
        string? tag = null;
        string? digest = null;

        var nameMatch = ReferenceRegex.AnchoredName.Match(name).Groups;
        if (nameMatch.Count == 3)
        {
            domain = nameMatch[1].Value;
            repository = nameMatch[2].Value;
        }
        else
        {
            repository = matches[1].Value;
        }

        tag = matches[2].Value;

        if (matches.Count > 3 && !string.IsNullOrWhiteSpace(matches[3].Value))
        {
            DigestUtility.CheckDigest(matches[3].Value, true);
            digest = matches[3].Value;
        }

        return CreateDockerReference(domain, repository, tag, digest);
    }

    public static IReference ParseFamiliarName(string name)
    {
        if (ReferenceRegex.AnchoredIdentifierRegexp.IsMatch(name))
        {
            throw new ReferenceNameNotCanonicalException(name);
        }

        var (domain, remainder) = SplitDockerDomain(name);

        var remoteName = remainder.Contains(':')
            ? remainder.Substring(0, remainder.IndexOf(':'))
            : remainder;

        if (remoteName.ToLower(CultureInfo.InvariantCulture) != remoteName)
        {
            throw new ReferenceNameContainsUppercaseException(name);
        }

        return ParseQualifiedName($"{domain}/{remainder}");
    }

    public static IReference ParseAll(string name)
    {
        if (ReferenceRegex.AnchoredIdentifierRegexp.IsMatch(name))
        {
            return CreateDockerReference(null, null, null, $"sha256:{name}");
        }

        if (DigestUtility.CheckDigest(name, false))
        {
            return CreateDockerReference(null, null, null, name);
        }

        return ParseFamiliarName(name);
    }

    private static (string Domain, string Remainder) SplitDockerDomain(string name)
    {
        string domain;
        string reminder;

        var indexOfSlash = name.IndexOf('/');
        if (indexOfSlash == -1 || !(
                name.LastIndexOf('.', indexOfSlash) != -1 ||
                name.LastIndexOf(':', indexOfSlash) != -1 ||
                name.StartsWith("localhost/", StringComparison.InvariantCulture)))
        {
            domain = DefaultDomain;
            reminder = name;
        }
        else
        {
            domain = name.Substring(0, indexOfSlash);
            reminder = name.Substring(indexOfSlash + 1);
        }

        if (domain == LegacyDefaultDomain)
        {
            domain = DefaultDomain;
        }

        if (domain == DefaultDomain && !reminder.Contains('/'))
        {
            reminder = $"{OfficialRepositoryName}/{reminder}";
        }

        return (domain, reminder);
    }

    private static IReference CreateDockerReference(string? domain, string? repository, string? tag, string? digest)
    {
        if (string.IsNullOrWhiteSpace(repository) && string.IsNullOrWhiteSpace(domain))
        {
            if (!string.IsNullOrWhiteSpace(digest))
            {
                return new DigestReference(digest!);
            }

            throw new ReferenceNameEmptyException();
        }

        if (string.IsNullOrWhiteSpace(tag))
        {
            if (!string.IsNullOrWhiteSpace(digest))
            {
                return new CanonicalReference(domain!, repository!, digest!);
            }

            return new RepositoryReference(domain!, repository!);
        }

        if (string.IsNullOrWhiteSpace(digest))
        {
            return new TaggedReference(domain!, repository!, tag!);
        }

        return new DualReference(domain!, repository!, tag!, digest!);
    }
}
