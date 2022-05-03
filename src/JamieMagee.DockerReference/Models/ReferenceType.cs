namespace JamieMagee.DockerReference.Models;

public enum ReferenceType
{
    /// <summary>
    /// <code>docker.io/library/ubuntu@sha256:abc123</code>.
    /// </summary>
    Canonical,

    /// <summary>
    /// <code>sha256:abc123</code>.
    /// </summary>
    Digest,

    /// <summary>
    /// <code>docker.io/library/ubuntu:latest@sha256:abc123</code>.
    /// </summary>
    Dual,

    /// <summary>
    /// <code>docker.io/library/ubuntu</code>.
    /// </summary>
    Repository,

    /// <summary>
    /// <code>docker.io/library/ubuntu:latest</code>.
    /// </summary>
    Tagged,
}
