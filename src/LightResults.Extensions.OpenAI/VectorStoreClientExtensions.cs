using System.ClientModel;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.VectorStores;
using System.Diagnostics.CodeAnalysis;

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
}
