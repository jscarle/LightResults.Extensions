using System.ClientModel;
using System.ClientModel.Primitives;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.Chat;
using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides extension methods for <see cref="ChatClient"/> that integrate the <see cref="Result"/> pattern, enabling safe and expressive error handling
/// for OpenAI chat operations. These methods wrap both synchronous and asynchronous chat requests and streaming operations in <see cref="Result{T}"/> types,
/// making it easy to handle errors and successful responses without exceptions.
/// </summary>
public static class ChatClientExtensions
{
    /// <summary>Attempts to complete a chat asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="messages">The chat messages to send.</param>
    /// <param name="options">Optional completion options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ChatCompletion}"/>.</returns>
    public static async Task<Result<ChatCompletion>> TryCompleteChatAsync(
        this ChatClient client,
        IEnumerable<ChatMessage> messages,
        ChatCompletionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<IEnumerable<ChatMessage>, ChatCompletionOptions?, CancellationToken, Task<ClientResult<ChatCompletion>>> func = client.CompleteChatAsync;

        var funcResult = await func.TryAsync(messages, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ChatCompletion>();
    }

    /// <summary>Attempts to complete a chat synchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="messages">The chat messages to send.</param>
    /// <param name="options">Optional completion options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{ChatCompletion}"/> representing the outcome.</returns>
    public static Result<ChatCompletion> TryCompleteChat(
        this ChatClient client,
        IEnumerable<ChatMessage> messages,
        ChatCompletionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<IEnumerable<ChatMessage>, ChatCompletionOptions?, CancellationToken, ClientResult<ChatCompletion>> func = client.CompleteChat;

        var funcResult = func.Try(messages, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ChatCompletion>();
    }

    /// <summary>Attempts to complete a chat asynchronously with a variable number of messages and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="messages">The chat messages to send.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ChatCompletion}"/>.</returns>
    public static async Task<Result<ChatCompletion>> TryCompleteChatAsync(this ChatClient client, params ChatMessage[] messages)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ChatMessage[], Task<ClientResult<ChatCompletion>>> func = client.CompleteChatAsync;

        var funcResult = await func.TryAsync(messages).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ChatCompletion>();
    }

    /// <summary>Attempts to complete a chat synchronously with a variable number of messages and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="messages">The chat messages to send.</param>
    /// <returns>A <see cref="Result{ChatCompletion}"/> representing the outcome.</returns>
    public static Result<ChatCompletion> TryCompleteChat(this ChatClient client, params ChatMessage[] messages)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ChatMessage[], ClientResult<ChatCompletion>> func = client.CompleteChat;

        var funcResult = func.Try(messages);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ChatCompletion>();
    }

    /// <summary>Attempts to complete a streaming chat asynchronously and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="messages">The chat messages to send.</param>
    /// <param name="options">Optional completion options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingChatCompletionUpdate}"/>.</returns>
    public static Result<IAsyncEnumerable<Result<StreamingChatCompletionUpdate>>> TryCompleteChatStreamingAsync(
        this ChatClient client,
        IEnumerable<ChatMessage> messages,
        ChatCompletionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<IEnumerable<ChatMessage>, ChatCompletionOptions?, CancellationToken, AsyncCollectionResult<StreamingChatCompletionUpdate>> func =
            client.CompleteChatStreamingAsync;

        var funcResult = func.Try(messages, options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingChatCompletionUpdate>>>();
    }

    /// <summary>Attempts to complete a streaming chat synchronously and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="messages">The chat messages to send.</param>
    /// <param name="options">Optional completion options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingChatCompletionUpdate}"/>.</returns>
    public static Result<IEnumerable<Result<StreamingChatCompletionUpdate>>> TryCompleteChatStreaming(
        this ChatClient client,
        IEnumerable<ChatMessage> messages,
        ChatCompletionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<IEnumerable<ChatMessage>, ChatCompletionOptions?, CancellationToken, CollectionResult<StreamingChatCompletionUpdate>> func =
            client.CompleteChatStreaming;

        var funcResult = func.Try(messages, options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingChatCompletionUpdate>>>();
    }

    /// <summary>
    /// Attempts to complete a streaming chat asynchronously with a variable number of messages and wraps the result as an asynchronous enumerable of
    /// <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="messages">The chat messages to send.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingChatCompletionUpdate}"/>.</returns>
    public static Result<IAsyncEnumerable<Result<StreamingChatCompletionUpdate>>> TryCompleteChatStreamingAsync(
        this ChatClient client,
        params ChatMessage[] messages
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ChatMessage[], AsyncCollectionResult<StreamingChatCompletionUpdate>> func = client.CompleteChatStreamingAsync;

        var funcResult = func.Try(messages);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult());

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingChatCompletionUpdate>>>();
    }

    /// <summary>
    /// Attempts to complete a streaming chat synchronously with a variable number of messages and wraps the result as an enumerable of
    /// <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="messages">The chat messages to send.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingChatCompletionUpdate}"/>.</returns>
    public static Result<IEnumerable<Result<StreamingChatCompletionUpdate>>> TryCompleteChatStreaming(this ChatClient client, params ChatMessage[] messages)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ChatMessage[], CollectionResult<StreamingChatCompletionUpdate>> func = client.CompleteChatStreaming;

        var funcResult = func.Try(messages);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingChatCompletionUpdate>>>();
    }

    /// <summary>Attempts to asynchronously retrieve a specific chat completion by its ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The ID of the chat completion to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ChatCompletion}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ChatCompletion>> TryGetChatCompletionAsync(
        this ChatClient client,
        string completionId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);
        Func<string, CancellationToken, Task<ClientResult<ChatCompletion>>> func = client.GetChatCompletionAsync;

        var funcResult = await func.TryAsync(completionId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ChatCompletion>();
    }

    /// <summary>Attempts to synchronously retrieve a specific chat completion by its ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The ID of the chat completion to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{ChatCompletion}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ChatCompletion> TryGetChatCompletion(this ChatClient client, string completionId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        Func<string, CancellationToken, ClientResult<ChatCompletion>> func = client.GetChatCompletion;

        var funcResult = func.Try(completionId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ChatCompletion>();
    }

    /// <summary>Attempts to asynchronously update chat completion metadata and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The ID of the chat completion to update.</param>
    /// <param name="metadata">The metadata values to apply.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ChatCompletion}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ChatCompletion>> TryUpdateChatCompletionAsync(
        this ChatClient client,
        string completionId,
        IDictionary<string, string?> metadata,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, IDictionary<string, string?>, CancellationToken, Task<ClientResult<ChatCompletion>>> func = client.UpdateChatCompletionAsync;

        var funcResult = await func.TryAsync(completionId, metadata, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ChatCompletion>();
    }

    /// <summary>Attempts to synchronously update chat completion metadata and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The ID of the chat completion to update.</param>
    /// <param name="metadata">The metadata values to apply.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{ChatCompletion}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ChatCompletion> TryUpdateChatCompletion(
        this ChatClient client,
        string completionId,
        IDictionary<string, string?> metadata,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, IDictionary<string, string?>, CancellationToken, ClientResult<ChatCompletion>> func = client.UpdateChatCompletion;

        var funcResult = func.Try(completionId, metadata, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ChatCompletion>();
    }

    /// <summary>Attempts to asynchronously delete a specific chat completion by its ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The ID of the chat completion to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ChatCompletionDeletionResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ChatCompletionDeletionResult>> TryDeleteChatCompletionAsync(
        this ChatClient client,
        string completionId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);
        Func<string, CancellationToken, Task<ClientResult<ChatCompletionDeletionResult>>> func = client.DeleteChatCompletionAsync;

        var funcResult = await func.TryAsync(completionId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ChatCompletionDeletionResult>();
    }

    /// <summary>Attempts to synchronously delete a specific chat completion by its ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The ID of the chat completion to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{ChatCompletionDeletionResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ChatCompletionDeletionResult> TryDeleteChatCompletion(
        this ChatClient client,
        string completionId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);
        Func<string, CancellationToken, ClientResult<ChatCompletionDeletionResult>> func = client.DeleteChatCompletion;

        var funcResult = func.Try(completionId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ChatCompletionDeletionResult>();
    }

    /// <summary>Attempts to asynchronously retrieve chat completions and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="options">Chat completion collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{ChatCompletion}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<ChatCompletion>>> TryGetChatCompletionsAsync(
        this ChatClient client,
        ChatCompletionCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ChatCompletionCollectionOptions?, CancellationToken, AsyncCollectionResult<ChatCompletion>> func = client.GetChatCompletionsAsync;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<ChatCompletion>>>();
    }

    /// <summary>Attempts to synchronously retrieve chat completions and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="options">Chat completion collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{ChatCompletion}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<ChatCompletion>>> TryGetChatCompletions(
        this ChatClient client,
        ChatCompletionCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ChatCompletionCollectionOptions?, CancellationToken, CollectionResult<ChatCompletion>> func = client.GetChatCompletions;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<ChatCompletion>>>();
    }

    /// <summary>Attempts to asynchronously retrieve chat completion messages and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The completion identifier.</param>
    /// <param name="options">Chat completion message collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{ChatCompletionMessageListDatum}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<ChatCompletionMessageListDatum>>> TryGetChatCompletionMessagesAsync(
        this ChatClient client,
        string completionId,
        ChatCompletionMessageCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ChatCompletionMessageCollectionOptions?, CancellationToken, AsyncCollectionResult<ChatCompletionMessageListDatum>> func =
            client.GetChatCompletionMessagesAsync;

        var funcResult = func.Try(completionId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<ChatCompletionMessageListDatum>>>();
    }

    /// <summary>Attempts to synchronously retrieve chat completion messages and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The completion identifier.</param>
    /// <param name="options">Chat completion message collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{ChatCompletionMessageListDatum}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<ChatCompletionMessageListDatum>>> TryGetChatCompletionMessages(
        this ChatClient client,
        string completionId,
        ChatCompletionMessageCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ChatCompletionMessageCollectionOptions?, CancellationToken, CollectionResult<ChatCompletionMessageListDatum>> func =
            client.GetChatCompletionMessages;

        var funcResult = func.Try(completionId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<ChatCompletionMessageListDatum>>>();
    }

    /// <summary>Attempts to complete a chat asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="content">The content to send as the body of the request.</param>
    /// <param name="options">Optional request options to override default client pipeline behaviors.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    public static async Task<Result<ClientResult>> TryCompleteChatAsync(this ChatClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CompleteChatAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to complete a chat synchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="content">The content to send as the body of the request.</param>
    /// <param name="options">Optional request options to override default client pipeline behaviors.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    public static Result<ClientResult> TryCompleteChat(this ChatClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, ClientResult> func = client.CompleteChat;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously delete a specific chat completion by its ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The ID of the chat completion to delete.</param>
    /// <param name="options">Optional request options to override default client pipeline behaviors.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDeleteChatCompletionAsync(this ChatClient client, string completionId, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, Task<ClientResult>> func = client.DeleteChatCompletionAsync;

        var funcResult = await func.TryAsync(completionId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously delete a specific chat completion by its ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The ID of the chat completion to delete.</param>
    /// <param name="options">Optional request options to override default client pipeline behaviors.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDeleteChatCompletion(this ChatClient client, string completionId, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, ClientResult> func = client.DeleteChatCompletion;

        var funcResult = func.Try(completionId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously retrieve a specific chat completion by its ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The ID of the chat completion to retrieve.</param>
    /// <param name="options">Optional request options to override default client pipeline behaviors.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetChatCompletionAsync(this ChatClient client, string completionId, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, Task<ClientResult>> func = client.GetChatCompletionAsync;

        var funcResult = await func.TryAsync(completionId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously retrieve a specific chat completion by its ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The ID of the chat completion to retrieve.</param>
    /// <param name="options">Optional request options to override default client pipeline behaviors.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetChatCompletion(this ChatClient client, string completionId, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, ClientResult> func = client.GetChatCompletion;

        var funcResult = func.Try(completionId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously update chat completion metadata using request content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The ID of the chat completion to update.</param>
    /// <param name="content">The binary content payload.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryUpdateChatCompletionAsync(
        this ChatClient client,
        string completionId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.UpdateChatCompletionAsync;

        var funcResult = await func.TryAsync(completionId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously update chat completion metadata using request content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The ID of the chat completion to update.</param>
    /// <param name="content">The binary content payload.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryUpdateChatCompletion(
        this ChatClient client,
        string completionId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, ClientResult> func = client.UpdateChatCompletion;

        var funcResult = func.Try(completionId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously retrieve chat completions with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="after">The pagination cursor for subsequent results.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="order">The sorting order.</param>
    /// <param name="metadata">Optional metadata filters.</param>
    /// <param name="model">The model filter.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AsyncCollectionResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<AsyncCollectionResult>> TryGetChatCompletionsAsync(
        this ChatClient client,
        string after,
        int? limit,
        string order,
        IDictionary<string, string?>? metadata,
        string model,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string, IDictionary<string, string?>?, string, RequestOptions, AsyncCollectionResult> func = client.GetChatCompletionsAsync;

        var funcResult = await Task.Run(() => func.Try(after, limit, order, metadata, model, options)).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>Attempts to synchronously retrieve chat completions with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="after">The pagination cursor for subsequent results.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="order">The sorting order.</param>
    /// <param name="metadata">Optional metadata filters.</param>
    /// <param name="model">The model filter.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{CollectionResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<CollectionResult> TryGetChatCompletions(
        this ChatClient client,
        string after,
        int? limit,
        string order,
        IDictionary<string, string?>? metadata,
        string model,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string, IDictionary<string, string?>?, string, RequestOptions, CollectionResult> func = client.GetChatCompletions;

        var funcResult = func.Try(after, limit, order, metadata, model, options);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>Attempts to asynchronously retrieve chat completion messages with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The completion identifier.</param>
    /// <param name="after">The pagination cursor for subsequent results.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="order">The sorting order.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AsyncCollectionResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<AsyncCollectionResult>> TryGetChatCompletionMessagesAsync(
        this ChatClient client,
        string completionId,
        string after,
        int? limit,
        string order,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, int?, string, RequestOptions, AsyncCollectionResult> func = client.GetChatCompletionMessagesAsync;

        var funcResult = await Task.Run(() => func.Try(completionId, after, limit, order, options)).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>Attempts to synchronously retrieve chat completion messages with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The chat client instance.</param>
    /// <param name="completionId">The completion identifier.</param>
    /// <param name="after">The pagination cursor for subsequent results.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="order">The sorting order.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{CollectionResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<CollectionResult> TryGetChatCompletionMessages(
        this ChatClient client,
        string completionId,
        string after,
        int? limit,
        string order,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, int?, string, RequestOptions, CollectionResult> func = client.GetChatCompletionMessages;

        var funcResult = func.Try(completionId, after, limit, order, options);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<CollectionResult>();
    }
}
