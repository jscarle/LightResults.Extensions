using System.ClientModel;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.VectorStores;
using System.Diagnostics.CodeAnalysis;
using System.ClientModel.Primitives;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides extension methods for <see cref="VectorStoreClient"/> that integrate the <see cref="Result"/> pattern, enabling safe
/// and expressive error handling for OpenAI vector store operations. These methods wrap both synchronous and asynchronous
/// vector store requests in <see cref="Result{T}"/> types, making it easy to handle errors and successful responses without
/// exceptions.
/// </summary>
public static class VectorStoreClientExtensions
{
    /// <summary>Attempts to asynchronously create a vector store and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="options">The creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing a <see cref="Result{VectorStore}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<VectorStore>> TryCreateVectorStoreAsync(
        this VectorStoreClient client,
        VectorStoreCreationOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<VectorStoreCreationOptions, CancellationToken, Task<ClientResult<VectorStore>>> func = client.CreateVectorStoreAsync;

        var funcResult = await func.TryAsync(options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStore>();
    }

    /// <summary>Attempts to create a vector store and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="options">The creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStore}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<VectorStore> TryCreateVectorStore(
        this VectorStoreClient client,
        VectorStoreCreationOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<VectorStoreCreationOptions, CancellationToken, ClientResult<VectorStore>> func = client.CreateVectorStore;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStore>();
    }

    /// <summary>Attempts to asynchronously retrieve a vector store by ID and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing a <see cref="Result{VectorStore}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<VectorStore>> TryGetVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<VectorStore>>> func = client.GetVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStore>();
    }

    /// <summary>Attempts to retrieve a vector store by ID and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStore}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<VectorStore> TryGetVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<VectorStore>> func = client.GetVectorStore;

        var funcResult = func.Try(vectorStoreId, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStore>();
    }

    /// <summary>Attempts to asynchronously modify a vector store and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="options">The modification options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing a <see cref="Result{VectorStore}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<VectorStore>> TryModifyVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        VectorStoreModificationOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, VectorStoreModificationOptions, CancellationToken, Task<ClientResult<VectorStore>>> func = client.ModifyVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStore>();
    }

    /// <summary>Attempts to modify a vector store and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="options">The modification options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStore}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<VectorStore> TryModifyVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        VectorStoreModificationOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, VectorStoreModificationOptions, CancellationToken, ClientResult<VectorStore>> func = client.ModifyVectorStore;

        var funcResult = func.Try(vectorStoreId, options, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStore>();
    }

    /// <summary>Attempts to asynchronously delete a vector store and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing a <see cref="Result{VectorStoreDeletionResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<VectorStoreDeletionResult>> TryDeleteVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<VectorStoreDeletionResult>>> func = client.DeleteVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreDeletionResult>();
    }

    /// <summary>Attempts to delete a vector store and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStoreDeletionResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<VectorStoreDeletionResult> TryDeleteVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<VectorStoreDeletionResult>> func = client.DeleteVectorStore;

        var funcResult = func.Try(vectorStoreId, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreDeletionResult>();
    }

    /// <summary>Attempts to asynchronously add a file to a vector store and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing a <see cref="Result{VectorStoreFile}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<VectorStoreFile>> TryAddFileToVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, Task<ClientResult<VectorStoreFile>>> func = client.AddFileToVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreFile>();
    }

    /// <summary>Attempts to add a file to a vector store and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStoreFile}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<VectorStoreFile> TryAddFileToVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, ClientResult<VectorStoreFile>> func = client.AddFileToVectorStore;

        var funcResult = func.Try(vectorStoreId, fileId, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreFile>();
    }

    /// <summary>Attempts to asynchronously retrieve a vector store file association and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing a <see cref="Result{VectorStoreFile}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<VectorStoreFile>> TryGetVectorStoreFileAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, Task<ClientResult<VectorStoreFile>>> func = client.GetVectorStoreFileAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreFile>();
    }

    /// <summary>Attempts to retrieve a vector store file association and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStoreFile}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<VectorStoreFile> TryGetVectorStoreFile(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, ClientResult<VectorStoreFile>> func = client.GetVectorStoreFile;

        var funcResult = func.Try(vectorStoreId, fileId, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreFile>();
    }

    /// <summary>Attempts to asynchronously remove a file from a vector store and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing a <see cref="Result{FileFromStoreRemovalResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<FileFromStoreRemovalResult>> TryRemoveFileFromVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, Task<ClientResult<FileFromStoreRemovalResult>>> func = client.RemoveFileFromVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<FileFromStoreRemovalResult>();
    }

    /// <summary>Attempts to remove a file from a vector store and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{FileFromStoreRemovalResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<FileFromStoreRemovalResult> TryRemoveFileFromVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, ClientResult<FileFromStoreRemovalResult>> func = client.RemoveFileFromVectorStore;

        var funcResult = func.Try(vectorStoreId, fileId, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<FileFromStoreRemovalResult>();
    }

    /// <summary>Attempts to asynchronously add multiple files to a vector store and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileIds">The file identifiers.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing a <see cref="Result{VectorStoreFileBatch}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<VectorStoreFileBatch>> TryAddFileBatchToVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        IEnumerable<string> fileIds,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, IEnumerable<string>, CancellationToken, Task<ClientResult<VectorStoreFileBatch>>> func = client.AddFileBatchToVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileIds, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreFileBatch>();
    }

    /// <summary>Attempts to add multiple files to a vector store and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileIds">The file identifiers.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStoreFileBatch}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<VectorStoreFileBatch> TryAddFileBatchToVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        IEnumerable<string> fileIds,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, IEnumerable<string>, CancellationToken, ClientResult<VectorStoreFileBatch>> func = client.AddFileBatchToVectorStore;

        var funcResult = func.Try(vectorStoreId, fileIds, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreFileBatch>();
    }

    /// <summary>Attempts to asynchronously get a vector store file batch and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchId">The batch identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing a <see cref="Result{VectorStoreFileBatch}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<VectorStoreFileBatch>> TryGetVectorStoreFileBatchAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, Task<ClientResult<VectorStoreFileBatch>>> func = client.GetVectorStoreFileBatchAsync;

        var funcResult = await func.TryAsync(vectorStoreId, batchId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreFileBatch>();
    }

    /// <summary>Attempts to get a vector store file batch and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchId">The batch identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStoreFileBatch}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<VectorStoreFileBatch> TryGetVectorStoreFileBatch(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, ClientResult<VectorStoreFileBatch>> func = client.GetVectorStoreFileBatch;

        var funcResult = func.Try(vectorStoreId, batchId, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreFileBatch>();
    }

    /// <summary>Attempts to asynchronously cancel a vector store file batch and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchId">The batch identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing a <see cref="Result{VectorStoreFileBatch}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<VectorStoreFileBatch>> TryCancelVectorStoreFileBatchAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, Task<ClientResult<VectorStoreFileBatch>>> func = client.CancelVectorStoreFileBatchAsync;

        var funcResult = await func.TryAsync(vectorStoreId, batchId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreFileBatch>();
    }

    /// <summary>Attempts to cancel a vector store file batch and wraps the response in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchId">The batch identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStoreFileBatch}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<VectorStoreFileBatch> TryCancelVectorStoreFileBatch(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, ClientResult<VectorStoreFileBatch>> func = client.CancelVectorStoreFileBatch;

        var funcResult = func.Try(vectorStoreId, batchId, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreFileBatch>();
    }

/// <summary>
    /// Attempts to execute <c>AddFileBatchToVectorStore</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>AddFileBatchToVectorStore</c>.</param>
    /// <param name="content">Parameter forwarded to <c>AddFileBatchToVectorStore</c>.</param>
    /// <param name="options">Parameter forwarded to <c>AddFileBatchToVectorStore</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryAddFileBatchToVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            BinaryContent,
            RequestOptions?,
            ClientResult> func = client.AddFileBatchToVectorStore;

        var funcResult = func.Try(vectorStoreId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>AddFileBatchToVectorStoreAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>AddFileBatchToVectorStoreAsync</c>.</param>
    /// <param name="content">Parameter forwarded to <c>AddFileBatchToVectorStoreAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>AddFileBatchToVectorStoreAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryAddFileBatchToVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            BinaryContent,
            RequestOptions?,
            Task<ClientResult>> func = client.AddFileBatchToVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>AddFileToVectorStore</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>AddFileToVectorStore</c>.</param>
    /// <param name="content">Parameter forwarded to <c>AddFileToVectorStore</c>.</param>
    /// <param name="options">Parameter forwarded to <c>AddFileToVectorStore</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryAddFileToVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            BinaryContent,
            RequestOptions?,
            ClientResult> func = client.AddFileToVectorStore;

        var funcResult = func.Try(vectorStoreId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>AddFileToVectorStoreAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>AddFileToVectorStoreAsync</c>.</param>
    /// <param name="content">Parameter forwarded to <c>AddFileToVectorStoreAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>AddFileToVectorStoreAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryAddFileToVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            BinaryContent,
            RequestOptions?,
            Task<ClientResult>> func = client.AddFileToVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>CancelVectorStoreFileBatch</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>CancelVectorStoreFileBatch</c>.</param>
    /// <param name="batchId">Parameter forwarded to <c>CancelVectorStoreFileBatch</c>.</param>
    /// <param name="options">Parameter forwarded to <c>CancelVectorStoreFileBatch</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCancelVectorStoreFileBatch(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions?,
            ClientResult> func = client.CancelVectorStoreFileBatch;

        var funcResult = func.Try(vectorStoreId, batchId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>CancelVectorStoreFileBatchAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>CancelVectorStoreFileBatchAsync</c>.</param>
    /// <param name="batchId">Parameter forwarded to <c>CancelVectorStoreFileBatchAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>CancelVectorStoreFileBatchAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCancelVectorStoreFileBatchAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            Task<ClientResult>> func = client.CancelVectorStoreFileBatchAsync;

        var funcResult = await func.TryAsync(vectorStoreId, batchId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>CreateVectorStore</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>CreateVectorStore</c>.</param>
    /// <param name="options">Parameter forwarded to <c>CreateVectorStore</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCreateVectorStore(
        this VectorStoreClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            RequestOptions?,
            ClientResult> func = client.CreateVectorStore;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>CreateVectorStoreAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>CreateVectorStoreAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>CreateVectorStoreAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCreateVectorStoreAsync(
        this VectorStoreClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            RequestOptions?,
            Task<ClientResult>> func = client.CreateVectorStoreAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteVectorStore</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>DeleteVectorStore</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DeleteVectorStore</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDeleteVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions,
            ClientResult> func = client.DeleteVectorStore;

        var funcResult = func.Try(vectorStoreId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteVectorStoreAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>DeleteVectorStoreAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DeleteVectorStoreAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDeleteVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions,
            Task<ClientResult>> func = client.DeleteVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStore</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>GetVectorStore</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStore</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions,
            ClientResult> func = client.GetVectorStore;

        var funcResult = func.Try(vectorStoreId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoreAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>GetVectorStoreAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoreAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions,
            Task<ClientResult>> func = client.GetVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoreFile</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>GetVectorStoreFile</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>GetVectorStoreFile</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoreFile</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetVectorStoreFile(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            ClientResult> func = client.GetVectorStoreFile;

        var funcResult = func.Try(vectorStoreId, fileId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoreFileAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>GetVectorStoreFileAsync</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>GetVectorStoreFileAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoreFileAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetVectorStoreFileAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            Task<ClientResult>> func = client.GetVectorStoreFileAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoreFileBatch</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>GetVectorStoreFileBatch</c>.</param>
    /// <param name="batchId">Parameter forwarded to <c>GetVectorStoreFileBatch</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoreFileBatch</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetVectorStoreFileBatch(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            ClientResult> func = client.GetVectorStoreFileBatch;

        var funcResult = func.Try(vectorStoreId, batchId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoreFileBatchAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>GetVectorStoreFileBatchAsync</c>.</param>
    /// <param name="batchId">Parameter forwarded to <c>GetVectorStoreFileBatchAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoreFileBatchAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetVectorStoreFileBatchAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            Task<ClientResult>> func = client.GetVectorStoreFileBatchAsync;

        var funcResult = await func.TryAsync(vectorStoreId, batchId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoreFiles</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>GetVectorStoreFiles</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoreFiles</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetVectorStoreFiles</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<VectorStoreFile>>> TryGetVectorStoreFiles(
        this VectorStoreClient client,
        string vectorStoreId,
        VectorStoreFileCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            VectorStoreFileCollectionOptions?,
            CancellationToken,
            CollectionResult<VectorStoreFile>> func = client.GetVectorStoreFiles;

        var funcResult = func.Try(vectorStoreId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<VectorStoreFile>>>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoreFiles</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>GetVectorStoreFiles</c>.</param>
    /// <param name="limit">Parameter forwarded to <c>GetVectorStoreFiles</c>.</param>
    /// <param name="order">Parameter forwarded to <c>GetVectorStoreFiles</c>.</param>
    /// <param name="after">Parameter forwarded to <c>GetVectorStoreFiles</c>.</param>
    /// <param name="before">Parameter forwarded to <c>GetVectorStoreFiles</c>.</param>
    /// <param name="filter">Parameter forwarded to <c>GetVectorStoreFiles</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoreFiles</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<CollectionResult> TryGetVectorStoreFiles(
        this VectorStoreClient client,
        string vectorStoreId,
        int? limit,
        string order,
        string after,
        string before,
        string filter,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            int?,
            string,
            string,
            string,
            string,
            RequestOptions,
            CollectionResult> func = client.GetVectorStoreFiles;

        var funcResult = func.Try(vectorStoreId, limit, order, after, before, filter, options);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoreFilesAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>GetVectorStoreFilesAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoreFilesAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetVectorStoreFilesAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<VectorStoreFile>>> TryGetVectorStoreFilesAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        VectorStoreFileCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            VectorStoreFileCollectionOptions?,
            CancellationToken,
            AsyncCollectionResult<VectorStoreFile>> func = client.GetVectorStoreFilesAsync;

        var funcResult = func.Try(vectorStoreId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<VectorStoreFile>>>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoreFilesAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>GetVectorStoreFilesAsync</c>.</param>
    /// <param name="limit">Parameter forwarded to <c>GetVectorStoreFilesAsync</c>.</param>
    /// <param name="order">Parameter forwarded to <c>GetVectorStoreFilesAsync</c>.</param>
    /// <param name="after">Parameter forwarded to <c>GetVectorStoreFilesAsync</c>.</param>
    /// <param name="before">Parameter forwarded to <c>GetVectorStoreFilesAsync</c>.</param>
    /// <param name="filter">Parameter forwarded to <c>GetVectorStoreFilesAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoreFilesAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<AsyncCollectionResult> TryGetVectorStoreFilesAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        int? limit,
        string order,
        string after,
        string before,
        string filter,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            int?,
            string,
            string,
            string,
            string,
            RequestOptions,
            AsyncCollectionResult> func = client.GetVectorStoreFilesAsync;

        var funcResult = func.Try(vectorStoreId, limit, order, after, before, filter, options);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoreFilesInBatch</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>GetVectorStoreFilesInBatch</c>.</param>
    /// <param name="batchId">Parameter forwarded to <c>GetVectorStoreFilesInBatch</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoreFilesInBatch</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetVectorStoreFilesInBatch</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<VectorStoreFile>>> TryGetVectorStoreFilesInBatch(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        VectorStoreFileCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            VectorStoreFileCollectionOptions?,
            CancellationToken,
            CollectionResult<VectorStoreFile>> func = client.GetVectorStoreFilesInBatch;

        var funcResult = func.Try(vectorStoreId, batchId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<VectorStoreFile>>>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoreFilesInBatch</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>GetVectorStoreFilesInBatch</c>.</param>
    /// <param name="batchId">Parameter forwarded to <c>GetVectorStoreFilesInBatch</c>.</param>
    /// <param name="limit">Parameter forwarded to <c>GetVectorStoreFilesInBatch</c>.</param>
    /// <param name="order">Parameter forwarded to <c>GetVectorStoreFilesInBatch</c>.</param>
    /// <param name="after">Parameter forwarded to <c>GetVectorStoreFilesInBatch</c>.</param>
    /// <param name="before">Parameter forwarded to <c>GetVectorStoreFilesInBatch</c>.</param>
    /// <param name="filter">Parameter forwarded to <c>GetVectorStoreFilesInBatch</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoreFilesInBatch</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<CollectionResult> TryGetVectorStoreFilesInBatch(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        int? limit,
        string order,
        string after,
        string before,
        string filter,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            int?,
            string,
            string,
            string,
            string,
            RequestOptions,
            CollectionResult> func = client.GetVectorStoreFilesInBatch;

        var funcResult = func.Try(vectorStoreId, batchId, limit, order, after, before, filter, options);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoreFilesInBatchAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>GetVectorStoreFilesInBatchAsync</c>.</param>
    /// <param name="batchId">Parameter forwarded to <c>GetVectorStoreFilesInBatchAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoreFilesInBatchAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetVectorStoreFilesInBatchAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<VectorStoreFile>>> TryGetVectorStoreFilesInBatchAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        VectorStoreFileCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            VectorStoreFileCollectionOptions?,
            CancellationToken,
            AsyncCollectionResult<VectorStoreFile>> func = client.GetVectorStoreFilesInBatchAsync;

        var funcResult = func.Try(vectorStoreId, batchId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<VectorStoreFile>>>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoreFilesInBatchAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>GetVectorStoreFilesInBatchAsync</c>.</param>
    /// <param name="batchId">Parameter forwarded to <c>GetVectorStoreFilesInBatchAsync</c>.</param>
    /// <param name="limit">Parameter forwarded to <c>GetVectorStoreFilesInBatchAsync</c>.</param>
    /// <param name="order">Parameter forwarded to <c>GetVectorStoreFilesInBatchAsync</c>.</param>
    /// <param name="after">Parameter forwarded to <c>GetVectorStoreFilesInBatchAsync</c>.</param>
    /// <param name="before">Parameter forwarded to <c>GetVectorStoreFilesInBatchAsync</c>.</param>
    /// <param name="filter">Parameter forwarded to <c>GetVectorStoreFilesInBatchAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoreFilesInBatchAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<AsyncCollectionResult> TryGetVectorStoreFilesInBatchAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        int? limit,
        string order,
        string after,
        string before,
        string filter,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            int?,
            string,
            string,
            string,
            string,
            RequestOptions,
            AsyncCollectionResult> func = client.GetVectorStoreFilesInBatchAsync;

        var funcResult = func.Try(vectorStoreId, batchId, limit, order, after, before, filter, options);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStores</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStores</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetVectorStores</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<VectorStore>>> TryGetVectorStores(
        this VectorStoreClient client,
        VectorStoreCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            VectorStoreCollectionOptions?,
            CancellationToken,
            CollectionResult<VectorStore>> func = client.GetVectorStores;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<VectorStore>>>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStores</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="limit">Parameter forwarded to <c>GetVectorStores</c>.</param>
    /// <param name="order">Parameter forwarded to <c>GetVectorStores</c>.</param>
    /// <param name="after">Parameter forwarded to <c>GetVectorStores</c>.</param>
    /// <param name="before">Parameter forwarded to <c>GetVectorStores</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStores</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<CollectionResult> TryGetVectorStores(
        this VectorStoreClient client,
        int? limit,
        string order,
        string after,
        string before,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            int?,
            string,
            string,
            string,
            RequestOptions,
            CollectionResult> func = client.GetVectorStores;

        var funcResult = func.Try(limit, order, after, before, options);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoresAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoresAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetVectorStoresAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<VectorStore>>> TryGetVectorStoresAsync(
        this VectorStoreClient client,
        VectorStoreCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            VectorStoreCollectionOptions?,
            CancellationToken,
            AsyncCollectionResult<VectorStore>> func = client.GetVectorStoresAsync;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<VectorStore>>>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoresAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="limit">Parameter forwarded to <c>GetVectorStoresAsync</c>.</param>
    /// <param name="order">Parameter forwarded to <c>GetVectorStoresAsync</c>.</param>
    /// <param name="after">Parameter forwarded to <c>GetVectorStoresAsync</c>.</param>
    /// <param name="before">Parameter forwarded to <c>GetVectorStoresAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVectorStoresAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<AsyncCollectionResult> TryGetVectorStoresAsync(
        this VectorStoreClient client,
        int? limit,
        string order,
        string after,
        string before,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            int?,
            string,
            string,
            string,
            RequestOptions,
            AsyncCollectionResult> func = client.GetVectorStoresAsync;

        var funcResult = func.Try(limit, order, after, before, options);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>
    /// Attempts to execute <c>ModifyVectorStore</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>ModifyVectorStore</c>.</param>
    /// <param name="content">Parameter forwarded to <c>ModifyVectorStore</c>.</param>
    /// <param name="options">Parameter forwarded to <c>ModifyVectorStore</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryModifyVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            BinaryContent,
            RequestOptions?,
            ClientResult> func = client.ModifyVectorStore;

        var funcResult = func.Try(vectorStoreId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>ModifyVectorStoreAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>ModifyVectorStoreAsync</c>.</param>
    /// <param name="content">Parameter forwarded to <c>ModifyVectorStoreAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>ModifyVectorStoreAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryModifyVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            BinaryContent,
            RequestOptions?,
            Task<ClientResult>> func = client.ModifyVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>RemoveFileFromVectorStore</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>RemoveFileFromVectorStore</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>RemoveFileFromVectorStore</c>.</param>
    /// <param name="options">Parameter forwarded to <c>RemoveFileFromVectorStore</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryRemoveFileFromVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            ClientResult> func = client.RemoveFileFromVectorStore;

        var funcResult = func.Try(vectorStoreId, fileId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>RemoveFileFromVectorStoreAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>RemoveFileFromVectorStoreAsync</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>RemoveFileFromVectorStoreAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>RemoveFileFromVectorStoreAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryRemoveFileFromVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            Task<ClientResult>> func = client.RemoveFileFromVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>RetrieveVectorStoreFileContent</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>RetrieveVectorStoreFileContent</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>RetrieveVectorStoreFileContent</c>.</param>
    /// <param name="options">Parameter forwarded to <c>RetrieveVectorStoreFileContent</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryRetrieveVectorStoreFileContent(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            ClientResult> func = client.RetrieveVectorStoreFileContent;

        var funcResult = func.Try(vectorStoreId, fileId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>RetrieveVectorStoreFileContentAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>RetrieveVectorStoreFileContentAsync</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>RetrieveVectorStoreFileContentAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>RetrieveVectorStoreFileContentAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryRetrieveVectorStoreFileContentAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RequestOptions,
            Task<ClientResult>> func = client.RetrieveVectorStoreFileContentAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>SearchVectorStore</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>SearchVectorStore</c>.</param>
    /// <param name="content">Parameter forwarded to <c>SearchVectorStore</c>.</param>
    /// <param name="options">Parameter forwarded to <c>SearchVectorStore</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TrySearchVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            BinaryContent,
            RequestOptions?,
            ClientResult> func = client.SearchVectorStore;

        var funcResult = func.Try(vectorStoreId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>SearchVectorStoreAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>SearchVectorStoreAsync</c>.</param>
    /// <param name="content">Parameter forwarded to <c>SearchVectorStoreAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>SearchVectorStoreAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TrySearchVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            BinaryContent,
            RequestOptions?,
            Task<ClientResult>> func = client.SearchVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>UpdateVectorStoreFileAttributes</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>UpdateVectorStoreFileAttributes</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>UpdateVectorStoreFileAttributes</c>.</param>
    /// <param name="attributes">Parameter forwarded to <c>UpdateVectorStoreFileAttributes</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>UpdateVectorStoreFileAttributes</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<VectorStoreFile> TryUpdateVectorStoreFileAttributes(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        IDictionary<string, BinaryData> attributes,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            IDictionary<string, BinaryData>,
            CancellationToken,
            ClientResult<VectorStoreFile>> func = client.UpdateVectorStoreFileAttributes;

        var funcResult = func.Try(vectorStoreId, fileId, attributes, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<VectorStoreFile>();
    }

    /// <summary>
    /// Attempts to execute <c>UpdateVectorStoreFileAttributes</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>UpdateVectorStoreFileAttributes</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>UpdateVectorStoreFileAttributes</c>.</param>
    /// <param name="content">Parameter forwarded to <c>UpdateVectorStoreFileAttributes</c>.</param>
    /// <param name="options">Parameter forwarded to <c>UpdateVectorStoreFileAttributes</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryUpdateVectorStoreFileAttributes(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            BinaryContent,
            RequestOptions?,
            ClientResult> func = client.UpdateVectorStoreFileAttributes;

        var funcResult = func.Try(vectorStoreId, fileId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>UpdateVectorStoreFileAttributesAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>UpdateVectorStoreFileAttributesAsync</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>UpdateVectorStoreFileAttributesAsync</c>.</param>
    /// <param name="attributes">Parameter forwarded to <c>UpdateVectorStoreFileAttributesAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>UpdateVectorStoreFileAttributesAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<VectorStoreFile>> TryUpdateVectorStoreFileAttributesAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        IDictionary<string, BinaryData> attributes,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            IDictionary<string, BinaryData>,
            CancellationToken,
            Task<ClientResult<VectorStoreFile>>> func = client.UpdateVectorStoreFileAttributesAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, attributes, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<VectorStoreFile>();
    }

    /// <summary>
    /// Attempts to execute <c>UpdateVectorStoreFileAttributesAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VectorStoreClient instance.</param>
    /// <param name="vectorStoreId">Parameter forwarded to <c>UpdateVectorStoreFileAttributesAsync</c>.</param>
    /// <param name="fileId">Parameter forwarded to <c>UpdateVectorStoreFileAttributesAsync</c>.</param>
    /// <param name="content">Parameter forwarded to <c>UpdateVectorStoreFileAttributesAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>UpdateVectorStoreFileAttributesAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryUpdateVectorStoreFileAttributesAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            BinaryContent,
            RequestOptions?,
            Task<ClientResult>> func = client.UpdateVectorStoreFileAttributesAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }
}

