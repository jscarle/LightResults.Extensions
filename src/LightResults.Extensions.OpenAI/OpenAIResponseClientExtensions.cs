using System.ClientModel;
using System.ClientModel.Primitives;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.Responses;

using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

// ReSharper disable InconsistentNaming

/// <summary>
/// Provides extension methods for <see cref="OpenAIResponseClient"/> that integrate the <see cref="Result"/> pattern, enabling safe and expressive error
/// handling for OpenAI response operations. These methods wrap both synchronous and asynchronous response requests and streaming operations in
/// <see cref="Result{T}"/> types, making it easy to handle errors and successful responses without exceptions.
/// </summary>
public static class OpenAIResponseClientExtensions
{
    /// <summary>Attempts to asynchronously cancel a response and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to cancel.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{OpenAIResponse}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<OpenAIResponse>> TryCancelResponseAsync(
        this OpenAIResponseClient client,
        string responseId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<OpenAIResponse>>> func = client.CancelResponseAsync;

        var funcResult = await func.TryAsync(responseId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIResponse>();
    }

    /// <summary>Attempts to synchronously cancel a response and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to cancel.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{OpenAIResponse}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<OpenAIResponse> TryCancelResponse(this OpenAIResponseClient client, string responseId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<OpenAIResponse>> func = client.CancelResponse;

        var funcResult = func.Try(responseId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIResponse>();
    }

    /// <summary>Attempts to asynchronously create a response with input items and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="inputItems">The input items for the response.</param>
    /// <param name="options">Response creation options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{OpenAIResponse}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<OpenAIResponse>> TryCreateResponseAsync(
        this OpenAIResponseClient client,
        IEnumerable<ResponseItem> inputItems,
        ResponseCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<IEnumerable<ResponseItem>, ResponseCreationOptions?, CancellationToken, Task<ClientResult<OpenAIResponse>>> func = client.CreateResponseAsync;

        var funcResult = await func.TryAsync(inputItems, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIResponse>();
    }

    /// <summary>Attempts to synchronously create a response with input items and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="inputItems">The input items for the response.</param>
    /// <param name="options">Response creation options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{OpenAIResponse}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<OpenAIResponse> TryCreateResponse(
        this OpenAIResponseClient client,
        IEnumerable<ResponseItem> inputItems,
        ResponseCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<IEnumerable<ResponseItem>, ResponseCreationOptions?, CancellationToken, ClientResult<OpenAIResponse>> func = client.CreateResponse;

        var funcResult = func.Try(inputItems, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIResponse>();
    }

    /// <summary>Attempts to asynchronously create a response with user input text and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="userInputText">The user input text for the response.</param>
    /// <param name="options">Response creation options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{OpenAIResponse}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<OpenAIResponse>> TryCreateResponseAsync(
        this OpenAIResponseClient client,
        string userInputText,
        ResponseCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ResponseCreationOptions?, CancellationToken, Task<ClientResult<OpenAIResponse>>> func = client.CreateResponseAsync;

        var funcResult = await func.TryAsync(userInputText, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIResponse>();
    }

    /// <summary>Attempts to synchronously create a response with user input text and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="userInputText">The user input text for the response.</param>
    /// <param name="options">Response creation options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{OpenAIResponse}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<OpenAIResponse> TryCreateResponse(
        this OpenAIResponseClient client,
        string userInputText,
        ResponseCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ResponseCreationOptions?, CancellationToken, ClientResult<OpenAIResponse>> func = client.CreateResponse;

        var funcResult = func.Try(userInputText, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIResponse>();
    }

    /// <summary>Attempts to asynchronously delete a response and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to delete.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ResponseDeletionResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ResponseDeletionResult>> TryDeleteResponseAsync(
        this OpenAIResponseClient client,
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
        this OpenAIResponseClient client,
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
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{OpenAIResponse}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<OpenAIResponse>> TryGetResponseAsync(
        this OpenAIResponseClient client,
        string responseId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<OpenAIResponse>>> func = client.GetResponseAsync;

        var funcResult = await func.TryAsync(responseId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIResponse>();
    }

    /// <summary>Attempts to synchronously get a response and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to retrieve.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{OpenAIResponse}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<OpenAIResponse> TryGetResponse(this OpenAIResponseClient client, string responseId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<OpenAIResponse>> func = client.GetResponse;

        var funcResult = func.Try(responseId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIResponse>();
    }

    /// <summary>Attempts to asynchronously get response input items and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to get input items for.</param>
    /// <param name="options">Response item collection options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{ResponseItem}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<ResponseItem>>> TryGetResponseInputItemsAsync(
        this OpenAIResponseClient client,
        string responseId,
        ResponseItemCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ResponseItemCollectionOptions?, CancellationToken, AsyncCollectionResult<ResponseItem>> func = client.GetResponseInputItemsAsync;

        var funcResult = func.Try(responseId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<ResponseItem>>>();
    }

    /// <summary>Attempts to synchronously get response input items and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to get input items for.</param>
    /// <param name="options">Response item collection options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{ResponseItem}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<ResponseItem>>> TryGetResponseInputItems(
        this OpenAIResponseClient client,
        string responseId,
        ResponseItemCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ResponseItemCollectionOptions?, CancellationToken, CollectionResult<ResponseItem>> func = client.GetResponseInputItems;

        var funcResult = func.Try(responseId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<ResponseItem>>>();
    }

    /// <summary>Attempts to asynchronously create a streaming response with input items and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="inputItems">The input items for the response.</param>
    /// <param name="options">Response creation options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<StreamingResponseUpdate>>> TryCreateResponseStreamingAsync(
        this OpenAIResponseClient client,
        IEnumerable<ResponseItem> inputItems,
        ResponseCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<IEnumerable<ResponseItem>, ResponseCreationOptions?, CancellationToken, AsyncCollectionResult<StreamingResponseUpdate>> func =
            client.CreateResponseStreamingAsync;

        var funcResult = func.Try(inputItems, options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>Attempts to synchronously create a streaming response with input items and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="inputItems">The input items for the response.</param>
    /// <param name="options">Response creation options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<StreamingResponseUpdate>>> TryCreateResponseStreaming(
        this OpenAIResponseClient client,
        IEnumerable<ResponseItem> inputItems,
        ResponseCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<IEnumerable<ResponseItem>, ResponseCreationOptions?, CancellationToken, CollectionResult<StreamingResponseUpdate>> func =
            client.CreateResponseStreaming;

        var funcResult = func.Try(inputItems, options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>
    /// Attempts to asynchronously create a streaming response with user input text and wraps the result as an asynchronous enumerable of
    /// <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="userInputText">The user input text for the response.</param>
    /// <param name="options">Response creation options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<StreamingResponseUpdate>>> TryCreateResponseStreamingAsync(
        this OpenAIResponseClient client,
        string userInputText,
        ResponseCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ResponseCreationOptions?, CancellationToken, AsyncCollectionResult<StreamingResponseUpdate>> func = client.CreateResponseStreamingAsync;

        var funcResult = func.Try(userInputText, options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>Attempts to synchronously create a streaming response with user input text and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="userInputText">The user input text for the response.</param>
    /// <param name="options">Response creation options.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<StreamingResponseUpdate>>> TryCreateResponseStreaming(
        this OpenAIResponseClient client,
        string userInputText,
        ResponseCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ResponseCreationOptions?, CancellationToken, CollectionResult<StreamingResponseUpdate>> func = client.CreateResponseStreaming;

        var funcResult = func.Try(userInputText, options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>Attempts to asynchronously get streaming response and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to stream.</param>
    /// <param name="startingAfter">Optional starting position for streaming.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<StreamingResponseUpdate>>> TryGetResponseStreamingAsync(
        this OpenAIResponseClient client,
        string responseId,
        int? startingAfter = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, CancellationToken, AsyncCollectionResult<StreamingResponseUpdate>> func = client.GetResponseStreamingAsync;

        var funcResult = func.Try(responseId, startingAfter, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingResponseUpdate>>>();
    }

    /// <summary>Attempts to synchronously get streaming response and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to stream.</param>
    /// <param name="startingAfter">Optional starting position for streaming.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingResponseUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<StreamingResponseUpdate>>> TryGetResponseStreaming(
        this OpenAIResponseClient client,
        string responseId,
        int? startingAfter = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, CancellationToken, CollectionResult<StreamingResponseUpdate>> func = client.GetResponseStreaming;

        var funcResult = func.Try(responseId, startingAfter, cancellationToken);
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
    public static async Task<Result<ClientResult>> TryCancelResponseAsync(this OpenAIResponseClient client, string responseId, RequestOptions options)
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
    public static Result<ClientResult> TryCancelResponse(this OpenAIResponseClient client, string responseId, RequestOptions options)
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
        this OpenAIResponseClient client,
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
    public static Result<ClientResult> TryCreateResponse(this OpenAIResponseClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, ClientResult> func = client.CreateResponse;

        var funcResult = func.Try(content, options);
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
    public static async Task<Result<ClientResult>> TryDeleteResponseAsync(this OpenAIResponseClient client, string responseId, RequestOptions options)
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
    public static Result<ClientResult> TryDeleteResponse(this OpenAIResponseClient client, string responseId, RequestOptions options)
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
    /// <param name="stream">Whether to stream the response.</param>
    /// <param name="startingAfter">Starting position for the response.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetResponseAsync(
        this OpenAIResponseClient client,
        string responseId,
        bool? stream,
        int? startingAfter,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, bool?, int?, RequestOptions, Task<ClientResult>> func = client.GetResponseAsync;

        var funcResult = await func.TryAsync(responseId, stream, startingAfter, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously get a response with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to retrieve.</param>
    /// <param name="stream">Whether to stream the response.</param>
    /// <param name="startingAfter">Starting position for the response.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetResponse(
        this OpenAIResponseClient client,
        string responseId,
        bool? stream,
        int? startingAfter,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, bool?, int?, RequestOptions, ClientResult> func = client.GetResponse;

        var funcResult = func.Try(responseId, stream, startingAfter, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously get response input items with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to get input items for.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="order">The order to return items in.</param>
    /// <param name="after">A cursor for pagination.</param>
    /// <param name="before">A cursor for pagination.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{AsyncCollectionResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<AsyncCollectionResult> TryGetResponseInputItemsAsync(
        this OpenAIResponseClient client,
        string responseId,
        int? limit,
        string? order,
        string? after,
        string? before,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string?, string?, string?, RequestOptions?, AsyncCollectionResult> func = client.GetResponseInputItemsAsync;

        var funcResult = func.Try(responseId, limit, order, after, before, options);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>Attempts to synchronously get response input items with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The response client instance.</param>
    /// <param name="responseId">The response ID to get input items for.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="order">The order to return items in.</param>
    /// <param name="after">A cursor for pagination.</param>
    /// <param name="before">A cursor for pagination.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{CollectionResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<CollectionResult> TryGetResponseInputItems(
        this OpenAIResponseClient client,
        string responseId,
        int? limit,
        string? order,
        string? after,
        string? before,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string?, string?, string?, RequestOptions?, CollectionResult> func = client.GetResponseInputItems;

        var funcResult = func.Try(responseId, limit, order, after, before, options);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<CollectionResult>();
    }
}
