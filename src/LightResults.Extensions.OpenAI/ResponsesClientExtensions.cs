using System.ClientModel;
using System.ClientModel.Primitives;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.Responses;

using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

// ReSharper disable InconsistentNaming

/// <summary>
/// Provides extension methods for <see cref="ResponsesClient"/> that integrate the <see cref="Result"/> pattern, enabling safe and expressive error
/// handling for OpenAI response operations. These methods wrap both synchronous and asynchronous response requests and streaming operations in
/// <see cref="Result{T}"/> types, making it easy to handle errors and successful responses without exceptions.
/// </summary>
public static class ResponsesClientExtensions
{
    /// <summary>Attempts to asynchronously cancel a response and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to cancel.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ResponseResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ResponseResult>> TryCancelResponseAsync(
        this ResponsesClient client,
        string responseId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<ResponseResult>>> func = client.CancelResponseAsync;

        var funcResult = await func.TryAsync(responseId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseResult>();
    }

    /// <summary>Attempts to synchronously cancel a response and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to cancel.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{ResponseResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ResponseResult> TryCancelResponse(this ResponsesClient client, string responseId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<ResponseResult>> func = client.CancelResponse;

        var funcResult = func.Try(responseId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseResult>();
    }

    /// <summary>Attempts to asynchronously create a response with input items and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="model">The model to use for the response.</param>
    /// <param name="inputItems">The input items for the response.</param>
    /// <param name="previousResponseId">The optional previous response ID.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ResponseResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ResponseResult>> TryCreateResponseAsync(
        this ResponsesClient client,
        string model,
        IEnumerable<ResponseItem> inputItems,
        string? previousResponseId = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, IEnumerable<ResponseItem>, string?, CancellationToken, Task<ClientResult<ResponseResult>>> func = client.CreateResponseAsync;

        var funcResult = await func.TryAsync(model, inputItems, previousResponseId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseResult>();
    }

    /// <summary>Attempts to synchronously create a response with input items and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="model">The model to use for the response.</param>
    /// <param name="inputItems">The input items for the response.</param>
    /// <param name="previousResponseId">The optional previous response ID.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{ResponseResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ResponseResult> TryCreateResponse(
        this ResponsesClient client,
        string model,
        IEnumerable<ResponseItem> inputItems,
        string? previousResponseId = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, IEnumerable<ResponseItem>, string?, CancellationToken, ClientResult<ResponseResult>> func = client.CreateResponse;

        var funcResult = func.Try(model, inputItems, previousResponseId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseResult>();
    }

    /// <summary>Attempts to asynchronously create a response with user input text and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="model">The model to use for the response.</param>
    /// <param name="userInputText">The user input text for the response.</param>
    /// <param name="previousResponseId">The optional previous response ID.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ResponseResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ResponseResult>> TryCreateResponseAsync(
        this ResponsesClient client,
        string model,
        string userInputText,
        string? previousResponseId = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, string?, CancellationToken, Task<ClientResult<ResponseResult>>> func = client.CreateResponseAsync;

        var funcResult = await func.TryAsync(model, userInputText, previousResponseId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseResult>();
    }

    /// <summary>Attempts to synchronously create a response with user input text and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="model">The model to use for the response.</param>
    /// <param name="userInputText">The user input text for the response.</param>
    /// <param name="previousResponseId">The optional previous response ID.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{ResponseResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ResponseResult> TryCreateResponse(
        this ResponsesClient client,
        string model,
        string userInputText,
        string? previousResponseId = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, string?, CancellationToken, ClientResult<ResponseResult>> func = client.CreateResponse;

        var funcResult = func.Try(model, userInputText, previousResponseId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseResult>();
    }

    /// <summary>Attempts to asynchronously delete a response and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to delete.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ResponseDeletionResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ResponseDeletionResult>> TryDeleteResponseAsync(
        this ResponsesClient client,
        string responseId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<ResponseDeletionResult>>> func = client.DeleteResponseAsync;

        var funcResult = await func.TryAsync(responseId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseDeletionResult>();
    }

    /// <summary>Attempts to synchronously delete a response and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to delete.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{ResponseDeletionResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ResponseDeletionResult> TryDeleteResponse(
        this ResponsesClient client,
        string responseId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<ResponseDeletionResult>> func = client.DeleteResponse;

        var funcResult = func.Try(responseId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseDeletionResult>();
    }

    /// <summary>Attempts to asynchronously get a response and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to retrieve.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ResponseResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ResponseResult>> TryGetResponseAsync(
        this ResponsesClient client,
        string responseId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<ResponseResult>>> func = client.GetResponseAsync;

        var funcResult = await func.TryAsync(responseId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseResult>();
    }

    /// <summary>Attempts to synchronously get a response and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to retrieve.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{ResponseResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ResponseResult> TryGetResponse(this ResponsesClient client, string responseId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<ResponseResult>> func = client.GetResponse;

        var funcResult = func.Try(responseId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseResult>();
    }

    /// <summary>Attempts to asynchronously get response input items and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="options">Response item collection options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{ResponseItem}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<ResponseItem>>> TryGetResponseInputItemsAsync(
        this ResponsesClient client,
        ResponseItemCollectionOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ResponseItemCollectionOptions, CancellationToken, AsyncCollectionResult<ResponseItem>> func = client.GetResponseInputItemsAsync;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<ResponseItem>>>();
    }

    /// <summary>Attempts to synchronously get response input items and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="options">Response item collection options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{ResponseItem}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<ResponseItem>>> TryGetResponseInputItems(
        this ResponsesClient client,
        ResponseItemCollectionOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ResponseItemCollectionOptions, CancellationToken, CollectionResult<ResponseItem>> func = client.GetResponseInputItems;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<ResponseItem>>>();
    }

    /// <summary>Attempts to asynchronously get response input items and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to get input items for.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{ResponseItem}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<ResponseItem>>> TryGetResponseInputItemsAsync(
        this ResponsesClient client,
        string responseId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, AsyncCollectionResult<ResponseItem>> func = client.GetResponseInputItemsAsync;

        var funcResult = func.Try(responseId, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<ResponseItem>>>();
    }

    /// <summary>Attempts to synchronously get response input items and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to get input items for.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{ResponseItem}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<ResponseItem>>> TryGetResponseInputItems(
        this ResponsesClient client,
        string responseId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, CollectionResult<ResponseItem>> func = client.GetResponseInputItems;

        var funcResult = func.Try(responseId, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<ResponseItem>>>();
    }

    /// <summary>Attempts to asynchronously create a streaming response and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="options">Response creation options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<StreamingResponseUpdate>>> TryCreateResponseStreamingAsync(
        this ResponsesClient client,
        CreateResponseOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<CreateResponseOptions, CancellationToken, AsyncCollectionResult<StreamingResponseUpdate>> func = client.CreateResponseStreamingAsync;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>Attempts to synchronously create a streaming response and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="options">Response creation options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<StreamingResponseUpdate>>> TryCreateResponseStreaming(
        this ResponsesClient client,
        CreateResponseOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<CreateResponseOptions, CancellationToken, CollectionResult<StreamingResponseUpdate>> func = client.CreateResponseStreaming;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>Attempts to asynchronously create a streaming response with input items and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="model">The model to use for the response.</param>
    /// <param name="inputItems">The input items for the response.</param>
    /// <param name="previousResponseId">The optional previous response ID.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<StreamingResponseUpdate>>> TryCreateResponseStreamingAsync(
        this ResponsesClient client,
        string model,
        IEnumerable<ResponseItem> inputItems,
        string? previousResponseId = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, IEnumerable<ResponseItem>, string?, CancellationToken, AsyncCollectionResult<StreamingResponseUpdate>> func = client.CreateResponseStreamingAsync;

        var funcResult = func.Try(model, inputItems, previousResponseId, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>Attempts to synchronously create a streaming response with input items and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="model">The model to use for the response.</param>
    /// <param name="inputItems">The input items for the response.</param>
    /// <param name="previousResponseId">The optional previous response ID.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<StreamingResponseUpdate>>> TryCreateResponseStreaming(
        this ResponsesClient client,
        string model,
        IEnumerable<ResponseItem> inputItems,
        string? previousResponseId = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, IEnumerable<ResponseItem>, string?, CancellationToken, CollectionResult<StreamingResponseUpdate>> func = client.CreateResponseStreaming;

        var funcResult = func.Try(model, inputItems, previousResponseId, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>Attempts to asynchronously create a streaming response with user input text and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="model">The model to use for the response.</param>
    /// <param name="userInputText">The user input text for the response.</param>
    /// <param name="previousResponseId">The optional previous response ID.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<StreamingResponseUpdate>>> TryCreateResponseStreamingAsync(
        this ResponsesClient client,
        string model,
        string userInputText,
        string? previousResponseId = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, string?, CancellationToken, AsyncCollectionResult<StreamingResponseUpdate>> func = client.CreateResponseStreamingAsync;

        var funcResult = func.Try(model, userInputText, previousResponseId, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>Attempts to synchronously create a streaming response with user input text and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="model">The model to use for the response.</param>
    /// <param name="userInputText">The user input text for the response.</param>
    /// <param name="previousResponseId">The optional previous response ID.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<StreamingResponseUpdate>>> TryCreateResponseStreaming(
        this ResponsesClient client,
        string model,
        string userInputText,
        string? previousResponseId = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, string?, CancellationToken, CollectionResult<StreamingResponseUpdate>> func = client.CreateResponseStreaming;

        var funcResult = func.Try(model, userInputText, previousResponseId, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>Attempts to asynchronously get streaming response and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to stream.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<StreamingResponseUpdate>>> TryGetResponseStreamingAsync(
        this ResponsesClient client,
        string responseId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, AsyncCollectionResult<StreamingResponseUpdate>> func = client.GetResponseStreamingAsync;

        var funcResult = func.Try(responseId, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>Attempts to synchronously get streaming response and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to stream.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<StreamingResponseUpdate>>> TryGetResponseStreaming(
        this ResponsesClient client,
        string responseId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, CollectionResult<StreamingResponseUpdate>> func = client.GetResponseStreaming;

        var funcResult = func.Try(responseId, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>Attempts to asynchronously cancel a response with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to cancel.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCancelResponseAsync(this ResponsesClient client, string responseId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, Task<ClientResult>> func = client.CancelResponseAsync;

        var funcResult = await func.TryAsync(responseId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously cancel a response with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to cancel.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCancelResponse(this ResponsesClient client, string responseId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, ClientResult> func = client.CancelResponse;

        var funcResult = func.Try(responseId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously create a response with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCreateResponseAsync(
        this ResponsesClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CreateResponseAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously create a response with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCreateResponse(this ResponsesClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, ClientResult> func = client.CreateResponse;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously compact a response and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="contentType">The content type for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCompactResponseAsync(
        this ResponsesClient client,
        BinaryContent content,
        string contentType,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions, Task<ClientResult>> func = client.CompactResponseAsync;

        var funcResult = await func.TryAsync(content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously compact a response and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="contentType">The content type for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCompactResponse(
        this ResponsesClient client,
        BinaryContent content,
        string contentType,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions, ClientResult> func = client.CompactResponse;

        var funcResult = func.Try(content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously get input token count and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="contentType">The content type for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetInputTokenCountAsync(
        this ResponsesClient client,
        BinaryContent content,
        string contentType,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions, Task<ClientResult>> func = client.GetInputTokenCountAsync;

        var funcResult = await func.TryAsync(content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously get input token count and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="contentType">The content type for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetInputTokenCount(
        this ResponsesClient client,
        BinaryContent content,
        string contentType,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions, ClientResult> func = client.GetInputTokenCount;

        var funcResult = func.Try(content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously delete a response with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to delete.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDeleteResponseAsync(this ResponsesClient client, string responseId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, Task<ClientResult>> func = client.DeleteResponseAsync;

        var funcResult = await func.TryAsync(responseId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously delete a response with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to delete.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDeleteResponse(this ResponsesClient client, string responseId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, ClientResult> func = client.DeleteResponse;

        var funcResult = func.Try(responseId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously get a response with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to retrieve.</param>
    /// <param name="include">Response properties to include.</param>
    /// <param name="stream">Whether to stream the response.</param>
    /// <param name="startingAfter">Starting position for the response.</param>
    /// <param name="includeObfuscation">Whether to include obfuscation in the response.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetResponseAsync(
        this ResponsesClient client,
        string responseId,
        IEnumerable<IncludedResponseProperty> include,
        bool? stream,
        int? startingAfter,
        bool? includeObfuscation,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, IEnumerable<IncludedResponseProperty>, bool?, int?, bool?, RequestOptions, Task<ClientResult>> func = client.GetResponseAsync;

        var funcResult = await func.TryAsync(responseId, include, stream, startingAfter, includeObfuscation, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously get a response with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to retrieve.</param>
    /// <param name="include">Response properties to include.</param>
    /// <param name="stream">Whether to stream the response.</param>
    /// <param name="startingAfter">Starting position for the response.</param>
    /// <param name="includeObfuscation">Whether to include obfuscation in the response.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetResponse(
        this ResponsesClient client,
        string responseId,
        IEnumerable<IncludedResponseProperty> include,
        bool? stream,
        int? startingAfter,
        bool? includeObfuscation,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, IEnumerable<IncludedResponseProperty>, bool?, int?, bool?, RequestOptions, ClientResult> func = client.GetResponse;

        var funcResult = func.Try(responseId, include, stream, startingAfter, includeObfuscation, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously get a response input item collection page with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to get input items for.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="order">The order to return items in.</param>
    /// <param name="after">A cursor for pagination.</param>
    /// <param name="before">A cursor for pagination.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetResponseInputItemCollectionPageAsync(
        this ResponsesClient client,
        string responseId,
        int? limit,
        string? order,
        string? after,
        string? before,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string, string, string, RequestOptions, Task<ClientResult>> func = client.GetResponseInputItemCollectionPageAsync;

        var funcResult = await func.TryAsync(responseId, limit, order ?? null!, after ?? null!, before ?? null!, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously get a response input item collection page with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to get input items for.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="order">The order to return items in.</param>
    /// <param name="after">A cursor for pagination.</param>
    /// <param name="before">A cursor for pagination.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetResponseInputItemCollectionPage(
        this ResponsesClient client,
        string responseId,
        int? limit,
        string? order,
        string? after,
        string? before,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string, string, string, RequestOptions, ClientResult> func = client.GetResponseInputItemCollectionPage;

        var funcResult = func.Try(responseId, limit, order ?? null!, after ?? null!, before ?? null!, options);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously create a response with options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="options">Response creation options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ResponseResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ResponseResult>> TryCreateResponseAsync(
        this ResponsesClient client,
        CreateResponseOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<CreateResponseOptions, CancellationToken, Task<ClientResult<ResponseResult>>> func = client.CreateResponseAsync;

        var funcResult = await func.TryAsync(options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseResult>();
    }

    /// <summary>Attempts to synchronously create a response with options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="options">Response creation options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{ResponseResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ResponseResult> TryCreateResponse(this ResponsesClient client, CreateResponseOptions options, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<CreateResponseOptions, CancellationToken, ClientResult<ResponseResult>> func = client.CreateResponse;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseResult>();
    }

    /// <summary>Attempts to asynchronously get a response with options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="options">Response retrieval options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ResponseResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ResponseResult>> TryGetResponseAsync(
        this ResponsesClient client,
        GetResponseOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<GetResponseOptions, CancellationToken, Task<ClientResult<ResponseResult>>> func = client.GetResponseAsync;

        var funcResult = await func.TryAsync(options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseResult>();
    }

    /// <summary>Attempts to synchronously get a response with options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="options">Response retrieval options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{ResponseResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ResponseResult> TryGetResponse(this ResponsesClient client, GetResponseOptions options, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<GetResponseOptions, CancellationToken, ClientResult<ResponseResult>> func = client.GetResponse;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseResult>();
    }

    /// <summary>Attempts to asynchronously get streaming response with options and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="options">Response retrieval options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<StreamingResponseUpdate>>> TryGetResponseStreamingAsync(
        this ResponsesClient client,
        GetResponseOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<GetResponseOptions, CancellationToken, AsyncCollectionResult<StreamingResponseUpdate>> func = client.GetResponseStreamingAsync;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>Attempts to synchronously get streaming response with options and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="options">Response retrieval options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<StreamingResponseUpdate>>> TryGetResponseStreaming(
        this ResponsesClient client,
        GetResponseOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<GetResponseOptions, CancellationToken, CollectionResult<StreamingResponseUpdate>> func = client.GetResponseStreaming;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>Attempts to asynchronously get a response input item collection page with options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="options">Response item collection options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ResponseItemCollectionPage}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ResponseItemCollectionPage>> TryGetResponseInputItemCollectionPageAsync(
        this ResponsesClient client,
        ResponseItemCollectionOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ResponseItemCollectionOptions, CancellationToken, Task<ClientResult<ResponseItemCollectionPage>>> func = client.GetResponseInputItemCollectionPageAsync;

        var funcResult = await func.TryAsync(options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseItemCollectionPage>();
    }

    /// <summary>Attempts to synchronously get a response input item collection page with options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="options">Response item collection options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{ResponseItemCollectionPage}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ResponseItemCollectionPage> TryGetResponseInputItemCollectionPage(
        this ResponsesClient client,
        ResponseItemCollectionOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ResponseItemCollectionOptions, CancellationToken, ClientResult<ResponseItemCollectionPage>> func = client.GetResponseInputItemCollectionPage;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ResponseItemCollectionPage>();
    }
}
