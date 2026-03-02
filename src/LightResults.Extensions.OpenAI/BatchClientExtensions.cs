using System.ClientModel;
using System.ClientModel.Primitives;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.Batch;
using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides extension methods for <see cref="BatchClient"/> that integrate the <see cref="Result"/> pattern, enabling safe and expressive error handling
/// for OpenAI batch operations. These methods wrap both synchronous and asynchronous batch requests and streaming operations in <see cref="Result{T}"/> types,
/// making it easy to handle errors and successful responses without exceptions.
/// </summary>
public static class BatchClientExtensions
{
    /// <summary>Attempts to create and execute a batch asynchronously from an uploaded file of requests and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The batch client instance.</param>
    /// <param name="content">The content to send as the body of the request.</param>
    /// <param name="waitUntilCompleted">Indicates whether the method should wait until the operation has completed before returning.</param>
    /// <param name="options">Optional request options to override default client pipeline behaviors.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{CreateBatchOperation}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<CreateBatchOperation>> TryCreateBatchAsync(
        this BatchClient client,
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, bool, RequestOptions?, Task<CreateBatchOperation>> func = client.CreateBatchAsync;

        var funcResult = await func.TryAsync(content, waitUntilCompleted, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var batchOp))
            return Result.Success(batchOp);

        return funcResult.AsFailure<CreateBatchOperation>();
    }

    /// <summary>Attempts to create and execute a batch synchronously from an uploaded file of requests and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The batch client instance.</param>
    /// <param name="content">The content to send as the body of the request.</param>
    /// <param name="waitUntilCompleted">Indicates whether the method should wait until the operation has completed before returning.</param>
    /// <param name="options">Optional request options to override default client pipeline behaviors.</param>
    /// <returns>A <see cref="Result{CreateBatchOperation}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<CreateBatchOperation> TryCreateBatch(
        this BatchClient client,
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, bool, RequestOptions?, CreateBatchOperation> func = client.CreateBatch;

        var funcResult = func.Try(content, waitUntilCompleted, options);
        if (funcResult.IsSuccess(out var batchOp))
            return Result.Success(batchOp);

        return funcResult.AsFailure<CreateBatchOperation>();
    }

    /// <summary>Attempts to list your organization's batches asynchronously and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The batch client instance.</param>
    /// <param name="after">A cursor for use in pagination. <paramref name="after"/> is an object ID that defines your place in the list.</param>
    /// <param name="limit">A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20.</param>
    /// <param name="options">Optional request options to override default client pipeline behaviors.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{AsyncCollectionResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<AsyncCollectionResult> TryGetBatchesAsync(this BatchClient client, string after, int? limit, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, RequestOptions?, AsyncCollectionResult> func = client.GetBatchesAsync;

        var funcResult = func.Try(after, limit, options);
        if (funcResult.IsSuccess(out var asyncCollectionResult))
            return Result.Success(asyncCollectionResult);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>Attempts to list your organization's batches synchronously and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The batch client instance.</param>
    /// <param name="after">A cursor for use in pagination. <paramref name="after"/> is an object ID that defines your place in the list.</param>
    /// <param name="limit">A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20.</param>
    /// <param name="options">Optional request options to override default client pipeline behaviors.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{AsyncCollectionResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<CollectionResult> TryGetBatches(this BatchClient client, string after, int? limit, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, RequestOptions?, CollectionResult> func = client.GetBatches;

        var funcResult = func.Try(after, limit, options);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetBatch</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The BatchClient instance.</param>
    /// <param name="batchId">Parameter forwarded to <c>GetBatch</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetBatch</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetBatch(
        this BatchClient client,
        string batchId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions,
            ClientResult> func = client.GetBatch;

        var funcResult = func.Try(batchId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetBatchAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The BatchClient instance.</param>
    /// <param name="batchId">Parameter forwarded to <c>GetBatchAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetBatchAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetBatchAsync(
        this BatchClient client,
        string batchId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions,
            Task<ClientResult>> func = client.GetBatchAsync;

        var funcResult = await func.TryAsync(batchId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetBatches</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The BatchClient instance.</param>
    /// <param name="options">Parameter forwarded to <c>GetBatches</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetBatches</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<BatchJob>>> TryGetBatches(
        this BatchClient client,
        BatchCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BatchCollectionOptions?,
            CancellationToken,
            CollectionResult<BatchJob>> func = client.GetBatches;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<BatchJob>>>();
    }

    /// <summary>
    /// Attempts to execute <c>GetBatchesAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The BatchClient instance.</param>
    /// <param name="options">Parameter forwarded to <c>GetBatchesAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetBatchesAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<BatchJob>>> TryGetBatchesAsync(
        this BatchClient client,
        BatchCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BatchCollectionOptions?,
            CancellationToken,
            AsyncCollectionResult<BatchJob>> func = client.GetBatchesAsync;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<BatchJob>>>();
    }
}
