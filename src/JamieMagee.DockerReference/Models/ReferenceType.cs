namespace JamieMagee.DockerReference.Models;

public enum ReferenceType
{
    /// <summary>
    /// docker.io/library/ubuntu@sha256:abc123
    /// </summary>
    Canonical,

    /// <summary>
    /// sha256:abc123
    /// </summary>
    Digest,

    /// <summary>
    /// docker.io/library/ubuntu:latest@sha256:abc123
    /// </summary>
    Dual,

    /// <summary>
    /// docker.io/library/ubuntu
    /// </summary>
    Repository,

    /// <summary>
    /// docker.io/library/ubuntu:latest
    /// </summary>
    Tagged,
}
