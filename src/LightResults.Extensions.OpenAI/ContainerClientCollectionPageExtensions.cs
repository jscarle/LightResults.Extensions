using LightResults.Extensions.ExceptionHandling;
using OpenAI.Containers;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides Try wrappers for the collection page methods on <see cref="ContainerClient"/> in OpenAI 2.13.0.
/// </summary>
public static class ContainerClientCollectionPageExtensions
{
    /// <summary>Attempts to retrieve a container collection page and wraps the outcome in a Result.</summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="limit">The maximum number of containers to return.</param>
    /// <param name="order">The sort order.</param>
    /// <param name="after">The pagination cursor.</param>
    /// <param name="name">The container name filter.</param>
    /// <param name="options">The request options.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetContainerCollectionPage(
        this ContainerClient client, int? limit, string order, string after, string name, RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);
        Func<int?, string, string, string, RequestOptions, ClientResult> func = client.GetContainerCollectionPage;
        var funcResult = func.Try(limit, order, after, name, options);
        if (funcResult.IsSuccess(out var clientResult)) return Result.Success(clientResult);
        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve a container collection page asynchronously and wraps the outcome in a Result.</summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="limit">The maximum number of containers to return.</param>
    /// <param name="order">The sort order.</param>
    /// <param name="after">The pagination cursor.</param>
    /// <param name="name">The container name filter.</param>
    /// <param name="options">The request options.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetContainerCollectionPageAsync(
        this ContainerClient client, int? limit, string order, string after, string name, RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);
        Func<int?, string, string, string, RequestOptions, Task<ClientResult>> func = client.GetContainerCollectionPageAsync;
        var funcResult = await func.TryAsync(limit, order, after, name, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult)) return Result.Success(clientResult);
        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve a typed container collection page and wraps the outcome in a Result.</summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="options">The collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ContainerCollectionPage> TryGetContainerCollectionPage(
        this ContainerClient client, ContainerCollectionOptions options, CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);
        Func<ContainerCollectionOptions, CancellationToken, ClientResult<ContainerCollectionPage>> func = client.GetContainerCollectionPage;
        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult)) return Result.Success(clientResult.Value);
        return funcResult.AsFailure<ContainerCollectionPage>();
    }

    /// <summary>Attempts to retrieve a typed container collection page asynchronously and wraps the outcome in a Result.</summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="options">The collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ContainerCollectionPage>> TryGetContainerCollectionPageAsync(
        this ContainerClient client, ContainerCollectionOptions options, CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);
        Func<ContainerCollectionOptions, CancellationToken, Task<ClientResult<ContainerCollectionPage>>> func =
            client.GetContainerCollectionPageAsync;
        var funcResult = await func.TryAsync(options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult)) return Result.Success(clientResult.Value);
        return funcResult.AsFailure<ContainerCollectionPage>();
    }

    /// <summary>Attempts to retrieve a container file collection page and wraps the outcome in a Result.</summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">The container identifier.</param>
    /// <param name="limit">The maximum number of files to return.</param>
    /// <param name="order">The sort order.</param>
    /// <param name="after">The pagination cursor.</param>
    /// <param name="options">The request options.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetContainerFileCollectionPage(
        this ContainerClient client, string containerId, int? limit, string order, string after, RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);
        Func<string, int?, string, string, RequestOptions, ClientResult> func = client.GetContainerFileCollectionPage;
        var funcResult = func.Try(containerId, limit, order, after, options);
        if (funcResult.IsSuccess(out var clientResult)) return Result.Success(clientResult);
        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve a container file collection page asynchronously and wraps the outcome in a Result.</summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">The container identifier.</param>
    /// <param name="limit">The maximum number of files to return.</param>
    /// <param name="order">The sort order.</param>
    /// <param name="after">The pagination cursor.</param>
    /// <param name="options">The request options.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetContainerFileCollectionPageAsync(
        this ContainerClient client, string containerId, int? limit, string order, string after, RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);
        Func<string, int?, string, string, RequestOptions, Task<ClientResult>> func = client.GetContainerFileCollectionPageAsync;
        var funcResult = await func.TryAsync(containerId, limit, order, after, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult)) return Result.Success(clientResult);
        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve a typed container file collection page and wraps the outcome in a Result.</summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="options">The collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ContainerFileCollectionPage> TryGetContainerFileCollectionPage(
        this ContainerClient client, ContainerFileCollectionOptions options, CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);
        Func<ContainerFileCollectionOptions, CancellationToken, ClientResult<ContainerFileCollectionPage>> func =
            client.GetContainerFileCollectionPage;
        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult)) return Result.Success(clientResult.Value);
        return funcResult.AsFailure<ContainerFileCollectionPage>();
    }

    /// <summary>Attempts to retrieve a typed container file collection page asynchronously and wraps the outcome in a Result.</summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="options">The collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ContainerFileCollectionPage>> TryGetContainerFileCollectionPageAsync(
        this ContainerClient client, ContainerFileCollectionOptions options, CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);
        Func<ContainerFileCollectionOptions, CancellationToken, Task<ClientResult<ContainerFileCollectionPage>>> func =
            client.GetContainerFileCollectionPageAsync;
        var funcResult = await func.TryAsync(options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult)) return Result.Success(clientResult.Value);
        return funcResult.AsFailure<ContainerFileCollectionPage>();
    }
}
