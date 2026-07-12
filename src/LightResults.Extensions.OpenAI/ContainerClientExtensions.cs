using LightResults.Extensions.ExceptionHandling;
using OpenAI.Containers;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides Try wrappers for <see cref="ContainerClient"/> methods in OpenAI 2.12.0.
/// </summary>
public static class ContainerClientExtensions
{
    /// <summary>
    /// Attempts to execute <c>CreateContainer</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>CreateContainer</c>.</param>
    /// <param name="options">Parameter forwarded to <c>CreateContainer</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCreateContainer(
        this ContainerClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            RequestOptions?,
            ClientResult> func = client.CreateContainer;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>CreateContainer</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="body">Parameter forwarded to <c>CreateContainer</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>CreateContainer</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ContainerResource> TryCreateContainer(
        this ContainerClient client,
        ContainerCreationOptions body,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            ContainerCreationOptions,
            CancellationToken,
            ClientResult<ContainerResource>> func = client.CreateContainer;

        var funcResult = func.Try(body, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ContainerResource>();
    }

    /// <summary>
    /// Attempts to execute <c>CreateContainerAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>CreateContainerAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>CreateContainerAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCreateContainerAsync(
        this ContainerClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            RequestOptions?,
            Task<ClientResult>> func = client.CreateContainerAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>CreateContainerAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="body">Parameter forwarded to <c>CreateContainerAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>CreateContainerAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ContainerResource>> TryCreateContainerAsync(
        this ContainerClient client,
        ContainerCreationOptions body,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            ContainerCreationOptions,
            CancellationToken,
            Task<ClientResult<ContainerResource>>> func = client.CreateContainerAsync;

        var funcResult = await func.TryAsync(body, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ContainerResource>();
    }

    /// <summary>
    /// Attempts to execute <c>UploadContainerFile</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>UploadContainerFile</c>.</param>
    /// <param name="content">Parameter forwarded to <c>UploadContainerFile</c>.</param>
    /// <param name="contentType">Parameter forwarded to <c>UploadContainerFile</c>.</param>
    /// <param name="options">Parameter forwarded to <c>UploadContainerFile</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryUploadContainerFile(
        this ContainerClient client,
        string containerId,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            BinaryContent,
            string,
            RequestOptions?,
            ClientResult> func = client.UploadContainerFile;

        var funcResult = func.Try(containerId, content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>UploadContainerFileAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>UploadContainerFileAsync</c>.</param>
    /// <param name="content">Parameter forwarded to <c>UploadContainerFileAsync</c>.</param>
    /// <param name="contentType">Parameter forwarded to <c>UploadContainerFileAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>UploadContainerFileAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryUploadContainerFileAsync(
        this ContainerClient client,
        string containerId,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            BinaryContent,
            string,
            RequestOptions?,
            Task<ClientResult>> func = client.UploadContainerFileAsync;

        var funcResult = await func.TryAsync(containerId, content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteContainer</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>DeleteContainer</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DeleteContainer</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDeleteContainer(
        this ContainerClient client,
        string containerId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions,
            ClientResult> func = client.DeleteContainer;

        var funcResult = func.Try(containerId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteContainer</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>DeleteContainer</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>DeleteContainer</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ContainerDeletionResult> TryDeleteContainer(
        this ContainerClient client,
        string containerId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            CancellationToken,
            ClientResult<ContainerDeletionResult>> func = client.DeleteContainer;

        var funcResult = func.Try(containerId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ContainerDeletionResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteContainerAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>DeleteContainerAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DeleteContainerAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDeleteContainerAsync(
        this ContainerClient client,
        string containerId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions,
            Task<ClientResult>> func = client.DeleteContainerAsync;

        var funcResult = await func.TryAsync(containerId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteContainerAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>DeleteContainerAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>DeleteContainerAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ContainerDeletionResult>> TryDeleteContainerAsync(
        this ContainerClient client,
        string containerId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            CancellationToken,
            Task<ClientResult<ContainerDeletionResult>>> func = client.DeleteContainerAsync;

        var funcResult = await func.TryAsync(containerId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ContainerDeletionResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteContainerFile</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>DeleteContainerFile</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>DeleteContainerFile</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DeleteContainerFile</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDeleteContainerFile(
        this ContainerClient client,
        string containerId,
        string fileId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            ClientResult> func = client.DeleteContainerFile;

        var funcResult = func.Try(containerId, fileId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteContainerFile</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>DeleteContainerFile</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>DeleteContainerFile</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>DeleteContainerFile</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ContainerFileDeletionResult> TryDeleteContainerFile(
        this ContainerClient client,
        string containerId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            CancellationToken,
            ClientResult<ContainerFileDeletionResult>> func = client.DeleteContainerFile;

        var funcResult = func.Try(containerId, fileId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ContainerFileDeletionResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteContainerFileAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>DeleteContainerFileAsync</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>DeleteContainerFileAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DeleteContainerFileAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDeleteContainerFileAsync(
        this ContainerClient client,
        string containerId,
        string fileId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            Task<ClientResult>> func = client.DeleteContainerFileAsync;

        var funcResult = await func.TryAsync(containerId, fileId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteContainerFileAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>DeleteContainerFileAsync</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>DeleteContainerFileAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>DeleteContainerFileAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ContainerFileDeletionResult>> TryDeleteContainerFileAsync(
        this ContainerClient client,
        string containerId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            CancellationToken,
            Task<ClientResult<ContainerFileDeletionResult>>> func = client.DeleteContainerFileAsync;

        var funcResult = await func.TryAsync(containerId, fileId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ContainerFileDeletionResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DownloadContainerFile</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>DownloadContainerFile</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>DownloadContainerFile</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DownloadContainerFile</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDownloadContainerFile(
        this ContainerClient client,
        string containerId,
        string fileId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            ClientResult> func = client.DownloadContainerFile;

        var funcResult = func.Try(containerId, fileId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DownloadContainerFile</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>DownloadContainerFile</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>DownloadContainerFile</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>DownloadContainerFile</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<BinaryData> TryDownloadContainerFile(
        this ContainerClient client,
        string containerId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            CancellationToken,
            ClientResult<BinaryData>> func = client.DownloadContainerFile;

        var funcResult = func.Try(containerId, fileId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<BinaryData>();
    }

    /// <summary>
    /// Attempts to execute <c>DownloadContainerFileAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>DownloadContainerFileAsync</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>DownloadContainerFileAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DownloadContainerFileAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDownloadContainerFileAsync(
        this ContainerClient client,
        string containerId,
        string fileId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            Task<ClientResult>> func = client.DownloadContainerFileAsync;

        var funcResult = await func.TryAsync(containerId, fileId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DownloadContainerFileAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>DownloadContainerFileAsync</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>DownloadContainerFileAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>DownloadContainerFileAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<BinaryData>> TryDownloadContainerFileAsync(
        this ContainerClient client,
        string containerId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            CancellationToken,
            Task<ClientResult<BinaryData>>> func = client.DownloadContainerFileAsync;

        var funcResult = await func.TryAsync(containerId, fileId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<BinaryData>();
    }

    /// <summary>
    /// Attempts to execute <c>GetContainer</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>GetContainer</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetContainer</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetContainer(
        this ContainerClient client,
        string containerId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions,
            ClientResult> func = client.GetContainer;

        var funcResult = func.Try(containerId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetContainer</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>GetContainer</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetContainer</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ContainerResource> TryGetContainer(
        this ContainerClient client,
        string containerId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            CancellationToken,
            ClientResult<ContainerResource>> func = client.GetContainer;

        var funcResult = func.Try(containerId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ContainerResource>();
    }

    /// <summary>
    /// Attempts to execute <c>GetContainerAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>GetContainerAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetContainerAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetContainerAsync(
        this ContainerClient client,
        string containerId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions,
            Task<ClientResult>> func = client.GetContainerAsync;

        var funcResult = await func.TryAsync(containerId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetContainerAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>GetContainerAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetContainerAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ContainerResource>> TryGetContainerAsync(
        this ContainerClient client,
        string containerId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            CancellationToken,
            Task<ClientResult<ContainerResource>>> func = client.GetContainerAsync;

        var funcResult = await func.TryAsync(containerId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ContainerResource>();
    }

    /// <summary>
    /// Attempts to execute <c>GetContainerFile</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>GetContainerFile</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>GetContainerFile</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetContainerFile</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetContainerFile(
        this ContainerClient client,
        string containerId,
        string fileId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            ClientResult> func = client.GetContainerFile;

        var funcResult = func.Try(containerId, fileId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetContainerFile</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>GetContainerFile</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>GetContainerFile</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetContainerFile</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ContainerFileResource> TryGetContainerFile(
        this ContainerClient client,
        string containerId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            CancellationToken,
            ClientResult<ContainerFileResource>> func = client.GetContainerFile;

        var funcResult = func.Try(containerId, fileId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ContainerFileResource>();
    }

    /// <summary>
    /// Attempts to execute <c>GetContainerFileAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>GetContainerFileAsync</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>GetContainerFileAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetContainerFileAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetContainerFileAsync(
        this ContainerClient client,
        string containerId,
        string fileId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            Task<ClientResult>> func = client.GetContainerFileAsync;

        var funcResult = await func.TryAsync(containerId, fileId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetContainerFileAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="containerId">Parameter forwarded to <c>GetContainerFileAsync</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>GetContainerFileAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetContainerFileAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ContainerFileResource>> TryGetContainerFileAsync(
        this ContainerClient client,
        string containerId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            CancellationToken,
            Task<ClientResult<ContainerFileResource>>> func = client.GetContainerFileAsync;

        var funcResult = await func.TryAsync(containerId, fileId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ContainerFileResource>();
    }

    /// <summary>
    /// Attempts to execute <c>GetContainerFiles</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="options">Parameter forwarded to <c>GetContainerFiles</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetContainerFiles</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<ContainerFileResource>>> TryGetContainerFiles(
        this ContainerClient client,
        ContainerFileCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            ContainerFileCollectionOptions?,
            CancellationToken,
            CollectionResult<ContainerFileResource>> func = client.GetContainerFiles;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<ContainerFileResource>>>();
    }

    /// <summary>
    /// Attempts to execute <c>GetContainerFilesAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="options">Parameter forwarded to <c>GetContainerFilesAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetContainerFilesAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<ContainerFileResource>>> TryGetContainerFilesAsync(
        this ContainerClient client,
        ContainerFileCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            ContainerFileCollectionOptions?,
            CancellationToken,
            AsyncCollectionResult<ContainerFileResource>> func = client.GetContainerFilesAsync;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<ContainerFileResource>>>();
    }

    /// <summary>
    /// Attempts to execute <c>GetContainers</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="options">Parameter forwarded to <c>GetContainers</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetContainers</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<ContainerResource>>> TryGetContainers(
        this ContainerClient client,
        ContainerCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            ContainerCollectionOptions?,
            CancellationToken,
            CollectionResult<ContainerResource>> func = client.GetContainers;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<ContainerResource>>>();
    }

    /// <summary>
    /// Attempts to execute <c>GetContainersAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ContainerClient instance.</param>
    /// <param name="options">Parameter forwarded to <c>GetContainersAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetContainersAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<ContainerResource>>> TryGetContainersAsync(
        this ContainerClient client,
        ContainerCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            ContainerCollectionOptions?,
            CancellationToken,
            AsyncCollectionResult<ContainerResource>> func = client.GetContainersAsync;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<ContainerResource>>>();
    }

}
