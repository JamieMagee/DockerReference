# JamieMagee.DockerReference

[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/JamieMagee/DockerReference/build.yml?branch=main&style=for-the-badge)](https://github.com/JamieMagee/DockerReference/actions/workflows/build.yml?query=branch%3Amain)
[![JamieMagee.DockerReference NuGet Package Version](https://img.shields.io/nuget/v/JamieMagee.DockerReference?style=for-the-badge)](https://www.nuget.org/packages/JamieMagee.DockerReference/)

`JamieMagee.DockerReference` is a .NET port of [Docker's image reference](https://github.com/distribution/distribution/tree/main/reference) library.

## Getting Started

`dotnet add package JamieMagee.DockerReference`

### Types

There are five different reference types:

1. [CanonicalReference](https://github.com/JamieMagee/DockerReference/blob/main/src/JamieMagee.DockerReference/Models/CanonicalReference.cs)
    
    Contains: domain, repository, and digest.
    For example `docker.io/library/hello-world@sha256:10d7d58d5ebd2a652f4d93fdd86da8f265f5318c6a73cc5b6a9798ff6d2b2e67`

2. [DigestReference](https://github.com/JamieMagee/DockerReference/blob/main/src/JamieMagee.DockerReference/Models/DigestReference.cs)

    Contains: digest.
    For example `sha256:10d7d58d5ebd2a652f4d93fdd86da8f265f5318c6a73cc5b6a9798ff6d2b2e67`

3. [DualReference](https://github.com/JamieMagee/DockerReference/blob/main/src/JamieMagee.DockerReference/Models/DualReference.cs)

    Contains: domain, repository, tag, and digest.
    For example `docker.io/library/hello-world:latest@sha256:10d7d58d5ebd2a652f4d93fdd86da8f265f5318c6a73cc5b6a9798ff6d2b2e67`

4. [RepositoryReference](https://github.com/JamieMagee/DockerReference/blob/main/src/JamieMagee.DockerReference/Models/RepositoryReference.cs)

    Contains: domain and repository.
    For example `docker.io/library/hello-world`

5. [TaggedReference](https://github.com/JamieMagee/DockerReference/blob/main/src/JamieMagee.DockerReference/Models/TaggedReference.cs)

    Contains: domain, repository, and tag.
    For example `docker.io/library/hello-world:latest`

### Parsers

There are three different parsers

1. `ParseQualifiedName`

    Used when parsing a string representing a fully-qualified image name (an image name that contains at least a domain and a repository).

2. `ParseFamiliarName`

    Used when parsing a string representing a familiar image name (an image that may not contain a domain). If a domain isn't specified, the default domain `docker.io` is used. If the domain is `docker.io` and the repository contains only one part, the repository is prefixed with `library/`

3. `ParseAll`

    Used when parsing a string representing a familiar image name or digest identifier.

## License

All packages in this repository are licensed under [the MIT license](https://opensource.org/licenses/MIT).
