namespace JamieMagee.DockerReference;

using JamieMagee.DockerReference.Exceptions;

public static class DigestUtility
{
    private static readonly Dictionary<string, int> AlgorithmsSizes = new()
    {
        {
            "sha256",
            32
        },
        {
            "sha384",
            48
        },
        {
            "sha512",
            64
        },
    };

    public static bool CheckDigest(string digest, bool throwError = true)
    {
        var indexOfColon = digest.IndexOf(':');
        if (indexOfColon < 0 ||
            indexOfColon + 1 == digest.Length ||
            !ReferenceRegex.AnchoredDigest.IsMatch(digest))
        {
            if (throwError)
            {
                throw new InvalidDigestFormatException(digest);
            }

            return false;
        }

        var algorithm = digest.Substring(0, indexOfColon);

        if (!AlgorithmsSizes.ContainsKey(algorithm))
        {
            if (throwError)
            {
                throw new UnsupportedAlgorithmException(digest);
            }

            return false;
        }

        if (AlgorithmsSizes[algorithm] * 2 != digest.Length - indexOfColon - 1)
        {
            if (throwError)
            {
                throw new InvalidDigestLengthException(digest);
            }

            return false;
        }

        return true;
    }
}
