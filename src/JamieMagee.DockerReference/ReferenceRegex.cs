namespace JamieMagee.DockerReference;

using System.Text.RegularExpressions;

internal static class ReferenceRegex
{
    private static readonly Regex AlphaNumeric = new("[a-z0-9]+");
    private static readonly Regex Separator = new("(?:[._]|__|[-]*)");

    private static readonly Regex DomainComponent = new("(?:[a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9-]*[a-zA-Z0-9])");
    private static readonly Regex Tag = new(@"[\w][\w.-]{0,127}");
    private static readonly Regex Digest = new("[a-zA-Z][a-zA-Z0-9]*(?:[-_+.][a-zA-Z][a-zA-Z0-9]*)*[:][a-fA-F0-9]{32,}");
    private static readonly Regex Identifier = new("[a-f0-9]{64}");

    private static readonly Regex NameComponent = Expression(
        AlphaNumeric,
        Optional(Repeated(Separator, AlphaNumeric)));

    private static readonly Regex Domain = Expression(
        DomainComponent,
        Optional(
            Repeated(
                new Regex(@"\."),
                DomainComponent)),
        Optional(
            new Regex(":"),
            new Regex("[0-9]+")));

    public static readonly Regex AnchoredDigest = Anchored(Digest);

    private static readonly Regex NameRegexp = Expression(
        Optional(
            Domain,
            new Regex(@"\/")),
        NameComponent,
        Optional(
                Repeated(
                    new Regex(@"\/"),
                    NameComponent)));

    internal static readonly Regex AnchoredName = Anchored(
        Optional(
            Capture(Domain),
            new Regex(@"\/")),
        Capture(
            NameComponent,
            Optional(
                Repeated(
                    new Regex(@"\/"),
                    NameComponent))));

    public static readonly Regex Reference = Anchored(
        Capture(NameRegexp),
        Optional(new Regex(":"), Capture(Tag)),
        Optional(new Regex("@"), Capture(Digest)));

    public static readonly Regex AnchoredIdentifierRegexp = Anchored(Identifier);

    private static Regex Expression(params Regex[] regexps) => new(string.Join(string.Empty, regexps.Select(re => re.ToString())));

    /**
         * group wraps the regexp in a non-capturing group.
         */
    private static Regex Group(params Regex[] regexps) => new($"(?:{Expression(regexps)})");

    /**
         * repeated wraps the regexp in a non-capturing group to get one or more matches.
         */
    private static Regex Optional(params Regex[] regexps) => new($"{Group(regexps)}?");

    /**
         * repeated wraps the regexp in a non-capturing group to get one or more matches.
         */
    private static Regex Repeated(params Regex[] regexps) => new($"{Group(regexps)}+");

    /**
         * anchored anchors the regular expression by adding start and end delimiters.
         */
    private static Regex Anchored(params Regex[] regexps) => new($"^{Expression(regexps)}$");

    /**
         * capture wraps the expression in a capturing group.
         */
    private static Regex Capture(params Regex[] regexps) => new($"({Expression(regexps)})");
}
