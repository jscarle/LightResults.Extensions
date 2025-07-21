using System.ClientModel;
using System.ClientModel.Primitives;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.VectorStores;

#if NET8_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;

#else
#pragma warning disable OPENAI001
#endif

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides extension methods for <see cref="VectorStoreClient"/> that integrate the <see cref="Result"/> pattern, enabling safe and expressive error
/// handling for OpenAI vector store operations. These methods wrap both synchronous and asynchronous vector store requests and collection operations in
/// <see cref="Result{T}"/> types, making it easy to handle errors and successful responses without exceptions.
/// </summary>
public static class VectorStoreClientExtensions
{
    /// <summary>Attempts to create a vector store operation and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the operation is completed.</param>
    /// <param name="options">Optional creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{CreateVectorStoreOperation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<CreateVectorStoreOperation> TryCreateVectorStore(
        this VectorStoreClient client,
        bool waitUntilCompleted,
        VectorStoreCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<bool, VectorStoreCreationOptions?, CancellationToken, CreateVectorStoreOperation> func = client.CreateVectorStore;

        var funcResult = func.Try(waitUntilCompleted, options, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<CreateVectorStoreOperation>();
    }

    /// <summary>Attempts to asynchronously create a vector store operation and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the operation is completed.</param>
    /// <param name="options">Optional creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{CreateVectorStoreOperation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<CreateVectorStoreOperation>> TryCreateVectorStoreAsync(
        this VectorStoreClient client,
        bool waitUntilCompleted,
        VectorStoreCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<bool, VectorStoreCreationOptions?, CancellationToken, Task<CreateVectorStoreOperation>> func = client.CreateVectorStoreAsync;

        var funcResult = await func.TryAsync(waitUntilCompleted, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<CreateVectorStoreOperation>();
    }

    /// <summary>Attempts to create a vector store operation with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="content">The binary content for the vector store creation.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the operation is completed.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{CreateVectorStoreOperation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<CreateVectorStoreOperation> TryCreateVectorStore(
        this VectorStoreClient client,
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, bool, RequestOptions?, CreateVectorStoreOperation> func = client.CreateVectorStore;

        var funcResult = func.Try(content, waitUntilCompleted, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<CreateVectorStoreOperation>();
    }

    /// <summary>Attempts to asynchronously create a vector store operation with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="content">The binary content for the vector store creation.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the operation is completed.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{CreateVectorStoreOperation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<CreateVectorStoreOperation>> TryCreateVectorStoreAsync(
        this VectorStoreClient client,
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, bool, RequestOptions?, Task<CreateVectorStoreOperation>> func = client.CreateVectorStoreAsync;

        var funcResult = await func.TryAsync(content, waitUntilCompleted, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<CreateVectorStoreOperation>();
    }

    /// <summary>Attempts to create a vector store with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="content">The binary content for the vector store creation.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryCreateVectorStore(this VectorStoreClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, ClientResult> func = client.CreateVectorStore;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously create a vector store with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="content">The binary content for the vector store creation.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryCreateVectorStoreAsync(
        this VectorStoreClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CreateVectorStoreAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to get a vector store and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStore}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<VectorStore> TryGetVectorStore(this VectorStoreClient client, string vectorStoreId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<VectorStore>> func = client.GetVectorStore;

        var funcResult = func.Try(vectorStoreId, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStore>();
    }

    /// <summary>Attempts to get vector stores collection and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="options">Optional collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an <see cref="IEnumerable{T}"/> of <see cref="Result{VectorStore}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<VectorStore>>> TryGetVectorStores(
        this VectorStoreClient client,
        VectorStoreCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<VectorStoreCollectionOptions?, CancellationToken, CollectionResult<VectorStore>> func = client.GetVectorStores;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<VectorStore>>>();
    }

    /// <summary>Attempts to get vector stores collection with continuation token and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="firstPageToken">The continuation token for the first page.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an <see cref="IEnumerable{T}"/> of <see cref="Result{VectorStore}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<VectorStore>>> TryGetVectorStores(
        this VectorStoreClient client,
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ContinuationToken, CancellationToken, CollectionResult<VectorStore>> func = client.GetVectorStores;

        var funcResult = func.Try(firstPageToken, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<VectorStore>>>();
    }

    /// <summary>Attempts to get vector stores collection with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="order">The order to return items in.</param>
    /// <param name="after">The item after which to start returning results.</param>
    /// <param name="before">The item before which to stop returning results.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{CollectionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<CollectionResult> TryGetVectorStores(
        this VectorStoreClient client,
        int? limit,
        string? order,
        string? after,
        string? before,
        RequestOptions? options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<int?, string?, string?, string?, RequestOptions?, CollectionResult> func = client.GetVectorStores;

        var funcResult = func.Try(limit, order, after, before, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>Attempts to asynchronously get vector stores collection and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="options">Optional collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an <see cref="IAsyncEnumerable{T}"/> of <see cref="Result{VectorStore}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<VectorStore>>> TryGetVectorStoresAsync(
        this VectorStoreClient client,
        VectorStoreCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<VectorStoreCollectionOptions?, CancellationToken, AsyncCollectionResult<VectorStore>> func = client.GetVectorStoresAsync;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<VectorStore>>>();
    }

    /// <summary>Attempts to asynchronously get vector stores collection with continuation token and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="firstPageToken">The continuation token for the first page.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an <see cref="IAsyncEnumerable{T}"/> of <see cref="Result{VectorStore}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<VectorStore>>> TryGetVectorStoresAsync(
        this VectorStoreClient client,
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ContinuationToken, CancellationToken, AsyncCollectionResult<VectorStore>> func = client.GetVectorStoresAsync;

        var funcResult = func.Try(firstPageToken, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<VectorStore>>>();
    }

    /// <summary>Attempts to asynchronously get vector stores collection with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="order">The order to return items in.</param>
    /// <param name="after">The item after which to start returning results.</param>
    /// <param name="before">The item before which to stop returning results.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{AsyncCollectionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<AsyncCollectionResult> TryGetVectorStoresAsync(
        this VectorStoreClient client,
        int? limit,
        string? order,
        string? after,
        string? before,
        RequestOptions? options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<int?, string?, string?, string?, RequestOptions?, AsyncCollectionResult> func = client.GetVectorStoresAsync;

        var funcResult = func.Try(limit, order, after, before, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>Attempts to modify a vector store and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="options">The modification options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStore}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
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

    /// <summary>Attempts to asynchronously modify a vector store and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="options">The modification options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{VectorStore}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
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

    /// <summary>Attempts to modify a vector store with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="content">The binary content for the modification.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryModifyVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, ClientResult> func = client.ModifyVectorStore;

        var funcResult = func.Try(vectorStoreId, content, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously modify a vector store with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="content">The binary content for the modification.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryModifyVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.ModifyVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to delete a vector store and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStoreDeletionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
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

    /// <summary>Attempts to asynchronously delete a vector store and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{VectorStoreDeletionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
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

    /// <summary>Attempts to delete a vector store with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="options">The request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryDeleteVectorStore(this VectorStoreClient client, string vectorStoreId, RequestOptions? options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, ClientResult> func = client.DeleteVectorStore;

        var funcResult = func.Try(vectorStoreId, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously delete a vector store with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="options">The request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryDeleteVectorStoreAsync(this VectorStoreClient client, string vectorStoreId, RequestOptions? options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, Task<ClientResult>> func = client.DeleteVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to add a file to a vector store and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the operation is completed.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{AddFileToVectorStoreOperation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<AddFileToVectorStoreOperation> TryAddFileToVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        bool waitUntilCompleted,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, bool, CancellationToken, AddFileToVectorStoreOperation> func = client.AddFileToVectorStore;

        var funcResult = func.Try(vectorStoreId, fileId, waitUntilCompleted, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<AddFileToVectorStoreOperation>();
    }

    /// <summary>Attempts to asynchronously add a file to a vector store and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the operation is completed.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AddFileToVectorStoreOperation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<AddFileToVectorStoreOperation>> TryAddFileToVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        bool waitUntilCompleted,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, bool, CancellationToken, Task<AddFileToVectorStoreOperation>> func = client.AddFileToVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, waitUntilCompleted, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<AddFileToVectorStoreOperation>();
    }

    /// <summary>Attempts to add a file to a vector store with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="content">The binary content for the file.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the operation is completed.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{AddFileToVectorStoreOperation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<AddFileToVectorStoreOperation> TryAddFileToVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, bool, RequestOptions?, AddFileToVectorStoreOperation> func = client.AddFileToVectorStore;

        var funcResult = func.Try(vectorStoreId, content, waitUntilCompleted, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<AddFileToVectorStoreOperation>();
    }

    /// <summary>Attempts to asynchronously add a file to a vector store with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="content">The binary content for the file.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the operation is completed.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AddFileToVectorStoreOperation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<AddFileToVectorStoreOperation>> TryAddFileToVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, bool, RequestOptions?, Task<AddFileToVectorStoreOperation>> func = client.AddFileToVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, content, waitUntilCompleted, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<AddFileToVectorStoreOperation>();
    }

    /// <summary>Attempts to remove a file from a vector store and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{FileFromStoreRemovalResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<FileFromStoreRemovalResult> TryRemoveFileFromStore(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, ClientResult<FileFromStoreRemovalResult>> func = client.RemoveFileFromStore;

        var funcResult = func.Try(vectorStoreId, fileId, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<FileFromStoreRemovalResult>();
    }

    /// <summary>Attempts to asynchronously remove a file from a vector store and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{FileFromStoreRemovalResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<FileFromStoreRemovalResult>> TryRemoveFileFromStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, Task<ClientResult<FileFromStoreRemovalResult>>> func = client.RemoveFileFromStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<FileFromStoreRemovalResult>();
    }

    /// <summary>Attempts to remove a file from a vector store with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="options">The request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryRemoveFileFromStore(this VectorStoreClient client, string vectorStoreId, string fileId, RequestOptions? options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions?, ClientResult> func = client.RemoveFileFromStore;

        var funcResult = func.Try(vectorStoreId, fileId, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously remove a file from a vector store with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="options">The request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryRemoveFileFromStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        RequestOptions? options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions?, Task<ClientResult>> func = client.RemoveFileFromStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to get a file association and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStoreFileAssociation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<VectorStoreFileAssociation> TryGetFileAssociation(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, ClientResult<VectorStoreFileAssociation>> func = client.GetFileAssociation;

        var funcResult = func.Try(vectorStoreId, fileId, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreFileAssociation>();
    }

    /// <summary>Attempts to asynchronously get a file association and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{VectorStoreFileAssociation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<VectorStoreFileAssociation>> TryGetFileAssociationAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, Task<ClientResult<VectorStoreFileAssociation>>> func = client.GetFileAssociationAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreFileAssociation>();
    }

    /// <summary>Attempts to get a file association with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="options">The request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryGetFileAssociation(this VectorStoreClient client, string vectorStoreId, string fileId, RequestOptions? options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions?, ClientResult> func = client.GetFileAssociation;

        var funcResult = func.Try(vectorStoreId, fileId, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously get a file association with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="options">The request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryGetFileAssociationAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        RequestOptions? options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions?, Task<ClientResult>> func = client.GetFileAssociationAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to get file associations collection and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="options">Optional collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an <see cref="IEnumerable{T}"/> of <see cref="Result{VectorStoreFileAssociation}"/>.</returns>

#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<VectorStoreFileAssociation>>> TryGetFileAssociations(
        this VectorStoreClient client,
        string vectorStoreId,
        VectorStoreFileAssociationCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, VectorStoreFileAssociationCollectionOptions?, CancellationToken, CollectionResult<VectorStoreFileAssociation>> func =
            client.GetFileAssociations;

        var funcResult = func.Try(vectorStoreId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<VectorStoreFileAssociation>>>();
    }

    /// <summary>Attempts to get file associations collection with continuation token and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="firstPageToken">The continuation token for the first page.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an <see cref="IEnumerable{T}"/> of <see cref="Result{VectorStoreFileAssociation}"/>.</returns>

#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<VectorStoreFileAssociation>>> TryGetFileAssociations(
        this VectorStoreClient client,
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ContinuationToken, CancellationToken, CollectionResult<VectorStoreFileAssociation>> func = client.GetFileAssociations;

        var funcResult = func.Try(firstPageToken, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<VectorStoreFileAssociation>>>();
    }

    /// <summary>Attempts to get file associations collection with batch job ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchJobId">The batch job identifier.</param>
    /// <param name="options">Optional collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an <see cref="IEnumerable{T}"/> of <see cref="Result{VectorStoreFileAssociation}"/>.</returns>

#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<VectorStoreFileAssociation>>> TryGetFileAssociations(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchJobId,
        VectorStoreFileAssociationCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, VectorStoreFileAssociationCollectionOptions?, CancellationToken, CollectionResult<VectorStoreFileAssociation>> func =
            client.GetFileAssociations;

        var funcResult = func.Try(vectorStoreId, batchJobId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<VectorStoreFileAssociation>>>();
    }

    /// <summary>Attempts to get file associations collection with batch job ID and continuation token and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchJobId">The batch job identifier.</param>
    /// <param name="firstPageToken">The continuation token for the first page.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an <see cref="IEnumerable{T}"/> of <see cref="Result{VectorStoreFileAssociation}"/>.</returns>

#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<VectorStoreFileAssociation>>> TryGetFileAssociations(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchJobId,
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, ContinuationToken, CancellationToken, CollectionResult<VectorStoreFileAssociation>> func = client.GetFileAssociations;

        var funcResult = func.Try(vectorStoreId, batchJobId, firstPageToken, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<VectorStoreFileAssociation>>>();
    }

    /// <summary>Attempts to get file associations collection with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="order">The order to return items in.</param>
    /// <param name="after">The item after which to start returning results.</param>
    /// <param name="before">The item before which to stop returning results.</param>
    /// <param name="filter">The filter to apply.</param>
    /// <param name="options">The request options.</param>
    /// <returns>A <see cref="Result{CollectionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<CollectionResult> TryGetFileAssociations(
        this VectorStoreClient client,
        string vectorStoreId,
        int? limit,
        string? order,
        string? after,
        string? before,
        string? filter,
        RequestOptions? options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string?, string?, string?, string?, RequestOptions?, CollectionResult> func = client.GetFileAssociations;

        var funcResult = func.Try(vectorStoreId, limit, order, after, before, filter, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>Attempts to get file associations collection with batch ID and pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchId">The batch identifier.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="order">The order to return items in.</param>
    /// <param name="after">The item after which to start returning results.</param>
    /// <param name="before">The item before which to stop returning results.</param>
    /// <param name="filter">The filter to apply.</param>
    /// <param name="options">The request options.</param>
    /// <returns>A <see cref="Result{CollectionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<CollectionResult> TryGetFileAssociations(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        int? limit,
        string? order,
        string? after,
        string? before,
        string? filter,
        RequestOptions? options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, int?, string?, string?, string?, string?, RequestOptions?, CollectionResult> func = client.GetFileAssociations;

        var funcResult = func.Try(vectorStoreId, batchId, limit, order, after, before, filter, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>Attempts to asynchronously get file associations collection and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="options">Optional collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an <see cref="IAsyncEnumerable{T}"/> of <see cref="Result{VectorStoreFileAssociation}"/>.</returns>

#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<VectorStoreFileAssociation>>> TryGetFileAssociationsAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        VectorStoreFileAssociationCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, VectorStoreFileAssociationCollectionOptions?, CancellationToken, AsyncCollectionResult<VectorStoreFileAssociation>> func =
            client.GetFileAssociationsAsync;

        var funcResult = func.Try(vectorStoreId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<VectorStoreFileAssociation>>>();
    }

    /// <summary>Attempts to asynchronously get file associations collection with continuation token and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="firstPageToken">The continuation token for the first page.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an <see cref="IAsyncEnumerable{T}"/> of <see cref="Result{VectorStoreFileAssociation}"/>.</returns>

#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<VectorStoreFileAssociation>>> TryGetFileAssociationsAsync(
        this VectorStoreClient client,
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ContinuationToken, CancellationToken, AsyncCollectionResult<VectorStoreFileAssociation>> func = client.GetFileAssociationsAsync;

        var funcResult = func.Try(firstPageToken, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<VectorStoreFileAssociation>>>();
    }

    /// <summary>Attempts to asynchronously get file associations collection with batch job ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchJobId">The batch job identifier.</param>
    /// <param name="options">Optional collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an <see cref="IAsyncEnumerable{T}"/> of <see cref="Result{VectorStoreFileAssociation}"/>.</returns>

#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<VectorStoreFileAssociation>>> TryGetFileAssociationsAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchJobId,
        VectorStoreFileAssociationCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, VectorStoreFileAssociationCollectionOptions?, CancellationToken, AsyncCollectionResult<VectorStoreFileAssociation>> func =
            client.GetFileAssociationsAsync;

        var funcResult = func.Try(vectorStoreId, batchJobId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<VectorStoreFileAssociation>>>();
    }

    /// <summary>
    /// Attempts to asynchronously get file associations collection with batch job ID and continuation token and wraps the result in a <see cref="Result{T}"/>
    /// .
    /// </summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchJobId">The batch job identifier.</param>
    /// <param name="firstPageToken">The continuation token for the first page.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an <see cref="IAsyncEnumerable{T}"/> of <see cref="Result{VectorStoreFileAssociation}"/>.</returns>

#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<VectorStoreFileAssociation>>> TryGetFileAssociationsAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchJobId,
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, ContinuationToken, CancellationToken, AsyncCollectionResult<VectorStoreFileAssociation>> func = client.GetFileAssociationsAsync;

        var funcResult = func.Try(vectorStoreId, batchJobId, firstPageToken, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<VectorStoreFileAssociation>>>();
    }

    /// <summary>Attempts to asynchronously get file associations collection with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="order">The order to return items in.</param>
    /// <param name="after">The item after which to start returning results.</param>
    /// <param name="before">The item before which to stop returning results.</param>
    /// <param name="filter">The filter to apply.</param>
    /// <param name="options">The request options.</param>
    /// <returns>A <see cref="Result{AsyncCollectionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<AsyncCollectionResult> TryGetFileAssociationsAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        int? limit,
        string? order,
        string? after,
        string? before,
        string? filter,
        RequestOptions? options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string?, string?, string?, string?, RequestOptions?, AsyncCollectionResult> func = client.GetFileAssociationsAsync;

        var funcResult = func.Try(vectorStoreId, limit, order, after, before, filter, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>Attempts to asynchronously get file associations collection with batch ID and pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchId">The batch identifier.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="order">The order to return items in.</param>
    /// <param name="after">The item after which to start returning results.</param>
    /// <param name="before">The item before which to stop returning results.</param>
    /// <param name="filter">The filter to apply.</param>
    /// <param name="options">The request options.</param>
    /// <returns>A <see cref="Result{AsyncCollectionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<AsyncCollectionResult> TryGetFileAssociationsAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        int? limit,
        string? order,
        string? after,
        string? before,
        string? filter,
        RequestOptions? options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, int?, string?, string?, string?, string?, RequestOptions?, AsyncCollectionResult> func = client.GetFileAssociationsAsync;

        var funcResult = func.Try(vectorStoreId, batchId, limit, order, after, before, filter, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>Attempts to update vector store file attributes and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="attributes">The attributes to update.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStoreFileAssociation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<VectorStoreFileAssociation> TryUpdateVectorStoreFileAttributes(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        IDictionary<string, BinaryData> attributes,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, IDictionary<string, BinaryData>, CancellationToken, ClientResult<VectorStoreFileAssociation>> func =
            client.UpdateVectorStoreFileAttributes;

        var funcResult = func.Try(vectorStoreId, fileId, attributes, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreFileAssociation>();
    }

    /// <summary>Attempts to asynchronously update vector store file attributes and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="attributes">The attributes to update.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{VectorStoreFileAssociation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<VectorStoreFileAssociation>> TryUpdateVectorStoreFileAttributesAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        IDictionary<string, BinaryData> attributes,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, IDictionary<string, BinaryData>, CancellationToken, Task<ClientResult<VectorStoreFileAssociation>>> func =
            client.UpdateVectorStoreFileAttributesAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, attributes, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreFileAssociation>();
    }

    /// <summary>Attempts to update vector store file attributes with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="content">The binary content for the update.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryUpdateVectorStoreFileAttributes(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, BinaryContent, RequestOptions?, ClientResult> func = client.UpdateVectorStoreFileAttributes;

        var funcResult = func.Try(vectorStoreId, fileId, content, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously update vector store file attributes with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="content">The binary content for the update.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryUpdateVectorStoreFileAttributesAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.UpdateVectorStoreFileAttributesAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve vector store file content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="options">The request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryRetrieveVectorStoreFileContent(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        RequestOptions? options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions?, ClientResult> func = client.RetrieveVectorStoreFileContent;

        var funcResult = func.Try(vectorStoreId, fileId, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously retrieve vector store file content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="options">The request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryRetrieveVectorStoreFileContentAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string fileId,
        RequestOptions? options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions?, Task<ClientResult>> func = client.RetrieveVectorStoreFileContentAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to create a batch file job operation and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileIds">The file identifiers.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the operation is completed.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{CreateBatchFileJobOperation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<CreateBatchFileJobOperation> TryCreateBatchFileJob(
        this VectorStoreClient client,
        string vectorStoreId,
        IEnumerable<string> fileIds,
        bool waitUntilCompleted,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, IEnumerable<string>, bool, CancellationToken, CreateBatchFileJobOperation> func = client.CreateBatchFileJob;

        var funcResult = func.Try(vectorStoreId, fileIds, waitUntilCompleted, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<CreateBatchFileJobOperation>();
    }

    /// <summary>Attempts to asynchronously create a batch file job operation and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="fileIds">The file identifiers.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the operation is completed.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{CreateBatchFileJobOperation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<CreateBatchFileJobOperation>> TryCreateBatchFileJobAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        IEnumerable<string> fileIds,
        bool waitUntilCompleted,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, IEnumerable<string>, bool, CancellationToken, Task<CreateBatchFileJobOperation>> func = client.CreateBatchFileJobAsync;

        var funcResult = await func.TryAsync(vectorStoreId, fileIds, waitUntilCompleted, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<CreateBatchFileJobOperation>();
    }

    /// <summary>Attempts to create a batch file job operation with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="content">The binary content for the batch job creation.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the operation is completed.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{CreateBatchFileJobOperation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<CreateBatchFileJobOperation> TryCreateBatchFileJob(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, bool, RequestOptions?, CreateBatchFileJobOperation> func = client.CreateBatchFileJob;

        var funcResult = func.Try(vectorStoreId, content, waitUntilCompleted, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<CreateBatchFileJobOperation>();
    }

    /// <summary>Attempts to asynchronously create a batch file job operation with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="content">The binary content for the batch job creation.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the operation is completed.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{CreateBatchFileJobOperation}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<CreateBatchFileJobOperation>> TryCreateBatchFileJobAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, bool, RequestOptions?, Task<CreateBatchFileJobOperation>> func = client.CreateBatchFileJobAsync;

        var funcResult = await func.TryAsync(vectorStoreId, content, waitUntilCompleted, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<CreateBatchFileJobOperation>();
    }

    /// <summary>Attempts to get a batch file job and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchJobId">The batch job identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStoreBatchFileJob}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<VectorStoreBatchFileJob> TryGetBatchFileJob(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchJobId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, ClientResult<VectorStoreBatchFileJob>> func = client.GetBatchFileJob;

        var funcResult = func.Try(vectorStoreId, batchJobId, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreBatchFileJob>();
    }

    /// <summary>Attempts to asynchronously get a batch file job and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchJobId">The batch job identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{VectorStoreBatchFileJob}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<VectorStoreBatchFileJob>> TryGetBatchFileJobAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchJobId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, Task<ClientResult<VectorStoreBatchFileJob>>> func = client.GetBatchFileJobAsync;

        var funcResult = await func.TryAsync(vectorStoreId, batchJobId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreBatchFileJob>();
    }

    /// <summary>Attempts to cancel a batch file job and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchJobId">The batch job identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{VectorStoreBatchFileJob}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<VectorStoreBatchFileJob> TryCancelBatchFileJob(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchJobId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, ClientResult<VectorStoreBatchFileJob>> func = client.CancelBatchFileJob;

        var funcResult = func.Try(vectorStoreId, batchJobId, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreBatchFileJob>();
    }

    /// <summary>Attempts to asynchronously cancel a batch file job and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchJobId">The batch job identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{VectorStoreBatchFileJob}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<VectorStoreBatchFileJob>> TryCancelBatchFileJobAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchJobId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, Task<ClientResult<VectorStoreBatchFileJob>>> func = client.CancelBatchFileJobAsync;

        var funcResult = await func.TryAsync(vectorStoreId, batchJobId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<VectorStoreBatchFileJob>();
    }

    /// <summary>Attempts to cancel a batch file job with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchId">The batch identifier.</param>
    /// <param name="options">The request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryCancelBatchFileJob(this VectorStoreClient client, string vectorStoreId, string batchId, RequestOptions? options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions?, ClientResult> func = client.CancelBatchFileJob;

        var funcResult = func.Try(vectorStoreId, batchId, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously cancel a batch file job with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="batchId">The batch identifier.</param>
    /// <param name="options">The request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryCancelBatchFileJobAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        string batchId,
        RequestOptions? options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions?, Task<ClientResult>> func = client.CancelBatchFileJobAsync;

        var funcResult = await func.TryAsync(vectorStoreId, batchId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to search a vector store and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="content">The search content.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TrySearchVectorStore(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, ClientResult> func = client.SearchVectorStore;

        var funcResult = func.Try(vectorStoreId, content, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously search a vector store and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The vector store client instance.</param>
    /// <param name="vectorStoreId">The vector store identifier.</param>
    /// <param name="content">The search content.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TrySearchVectorStoreAsync(
        this VectorStoreClient client,
        string vectorStoreId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.SearchVectorStoreAsync;

        var funcResult = await func.TryAsync(vectorStoreId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }
}
