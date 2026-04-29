using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.Conversations;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides extension methods for <see cref="ConversationClient"/> that integrate the <see cref="Result"/> pattern, enabling
/// expressive and exception-free error handling for conversation operations.
/// </summary>
public static class ConversationClientExtensions
{
    /// <summary>Attempts to asynchronously create a conversation and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="content">The request payload.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A task that produces a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCreateConversationAsync(
        this ConversationClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CreateConversationAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously create a conversation and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="content">The request payload.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCreateConversation(
        this ConversationClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, ClientResult> func = client.CreateConversation;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously create conversation items and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="conversationId">The identifier of the conversation to update.</param>
    /// <param name="content">The request payload.</param>
    /// <param name="include">Optional item properties to include in the response.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A task that produces a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCreateConversationItemsAsync(
        this ConversationClient client,
        string conversationId,
        BinaryContent content,
        IEnumerable<IncludedConversationItemProperty>? include = null,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, IEnumerable<IncludedConversationItemProperty>?, RequestOptions?, Task<ClientResult>> func =
            client.CreateConversationItemsAsync;

        var funcResult = await func.TryAsync(conversationId, content, include, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously create conversation items and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="conversationId">The identifier of the conversation to update.</param>
    /// <param name="content">The request payload.</param>
    /// <param name="include">Optional item properties to include in the response.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCreateConversationItems(
        this ConversationClient client,
        string conversationId,
        BinaryContent content,
        IEnumerable<IncludedConversationItemProperty>? include = null,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, IEnumerable<IncludedConversationItemProperty>?, RequestOptions?, ClientResult> func =
            client.CreateConversationItems;

        var funcResult = func.Try(conversationId, content, include, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously delete a conversation and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="conversationId">The identifier of the conversation to delete.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A task that produces a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDeleteConversationAsync(
        this ConversationClient client,
        string conversationId,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, Task<ClientResult>> func = client.DeleteConversationAsync;

        var funcResult = await func.TryAsync(conversationId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously delete a conversation and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="conversationId">The identifier of the conversation to delete.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDeleteConversation(
        this ConversationClient client,
        string conversationId,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, ClientResult> func = client.DeleteConversation;

        var funcResult = func.Try(conversationId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously delete a conversation item and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="conversationId">The identifier of the conversation containing the item.</param>
    /// <param name="itemId">The identifier of the item to delete.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A task that produces a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDeleteConversationItemAsync(
        this ConversationClient client,
        string conversationId,
        string itemId,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions?, Task<ClientResult>> func = client.DeleteConversationItemAsync;

        var funcResult = await func.TryAsync(conversationId, itemId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously delete a conversation item and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="conversationId">The identifier of the conversation containing the item.</param>
    /// <param name="itemId">The identifier of the item to delete.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDeleteConversationItem(
        this ConversationClient client,
        string conversationId,
        string itemId,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions?, ClientResult> func = client.DeleteConversationItem;

        var funcResult = func.Try(conversationId, itemId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously retrieve a conversation and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="conversationId">The identifier of the conversation to retrieve.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A task that produces a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetConversationAsync(
        this ConversationClient client,
        string conversationId,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, Task<ClientResult>> func = client.GetConversationAsync;

        var funcResult = await func.TryAsync(conversationId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously retrieve a conversation and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="conversationId">The identifier of the conversation to retrieve.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetConversation(
        this ConversationClient client,
        string conversationId,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, ClientResult> func = client.GetConversation;

        var funcResult = func.Try(conversationId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously retrieve a conversation item and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="conversationId">The identifier of the conversation containing the item.</param>
    /// <param name="itemId">The identifier of the item to retrieve.</param>
    /// <param name="include">Optional item properties to include in the response.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A task that produces a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetConversationItemAsync(
        this ConversationClient client,
        string conversationId,
        string itemId,
        IEnumerable<IncludedConversationItemProperty>? include = null,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, IEnumerable<IncludedConversationItemProperty>?, RequestOptions?, Task<ClientResult>> func =
            client.GetConversationItemAsync;

        var funcResult = await func.TryAsync(conversationId, itemId, include, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously retrieve a conversation item and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="conversationId">The identifier of the conversation containing the item.</param>
    /// <param name="itemId">The identifier of the item to retrieve.</param>
    /// <param name="include">Optional item properties to include in the response.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetConversationItem(
        this ConversationClient client,
        string conversationId,
        string itemId,
        IEnumerable<IncludedConversationItemProperty>? include = null,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, IEnumerable<IncludedConversationItemProperty>?, RequestOptions?, ClientResult> func =
            client.GetConversationItem;

        var funcResult = func.Try(conversationId, itemId, include, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously retrieve conversation items and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="conversationId">The identifier of the conversation containing the items.</param>
    /// <param name="limit">An optional maximum number of items to return.</param>
    /// <param name="order">Optional sort order for the items.</param>
    /// <param name="after">A pagination cursor for fetching the next set of items.</param>
    /// <param name="include">Optional item properties to include in the response.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A task that produces a <see cref="Result{AsyncCollectionResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<AsyncCollectionResult>> TryGetConversationItemsAsync(
        this ConversationClient client,
        string conversationId,
        int? limit = null,
        string? order = null,
        string? after = null,
        IEnumerable<IncludedConversationItemProperty>? include = null,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string?, string?, IEnumerable<IncludedConversationItemProperty>?, RequestOptions?, AsyncCollectionResult> func =
            client.GetConversationItemsAsync;

        var funcResult = await Task.Run(() => func.Try(conversationId, limit, order, after, include, options)).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>Attempts to synchronously retrieve conversation items and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="conversationId">The identifier of the conversation containing the items.</param>
    /// <param name="limit">An optional maximum number of items to return.</param>
    /// <param name="order">Optional sort order for the items.</param>
    /// <param name="after">A pagination cursor for fetching the next set of items.</param>
    /// <param name="include">Optional item properties to include in the response.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A <see cref="Result{CollectionResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<CollectionResult> TryGetConversationItems(
        this ConversationClient client,
        string conversationId,
        int? limit = null,
        string? order = null,
        string? after = null,
        IEnumerable<IncludedConversationItemProperty>? include = null,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string?, string?, IEnumerable<IncludedConversationItemProperty>?, RequestOptions?, CollectionResult> func =
            client.GetConversationItems;

        var funcResult = func.Try(conversationId, limit, order, after, include, options);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>Attempts to asynchronously update a conversation and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="conversationId">The identifier of the conversation to update.</param>
    /// <param name="content">The request payload.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A task that produces a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryUpdateConversationAsync(
        this ConversationClient client,
        string conversationId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.UpdateConversationAsync;

        var funcResult = await func.TryAsync(conversationId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously update a conversation and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The conversation client instance.</param>
    /// <param name="conversationId">The identifier of the conversation to update.</param>
    /// <param name="content">The request payload.</param>
    /// <param name="options">Optional request options to override default client behaviors.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryUpdateConversation(
        this ConversationClient client,
        string conversationId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, ClientResult> func = client.UpdateConversation;

        var funcResult = func.Try(conversationId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }
}
