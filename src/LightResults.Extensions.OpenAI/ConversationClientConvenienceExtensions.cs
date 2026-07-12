using LightResults.Extensions.ExceptionHandling;
using OpenAI.Conversations;
using System.ClientModel;
using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides Try wrappers for the convenience methods on <see cref="ConversationClient"/> in OpenAI 2.12.0.
/// </summary>
public static class ConversationClientConvenienceExtensions
{
    /// <summary>Attempts to create a conversation and wraps the outcome in a Result.</summary>
    /// <param name="client">The ConversationClient instance.</param>
    /// <param name="options">The creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ConversationResource> TryCreateConversation(
        this ConversationClient client,
        ConversationCreationOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ConversationCreationOptions, CancellationToken, ClientResult<ConversationResource>> func = client.CreateConversation;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ConversationResource>();
    }

    /// <summary>Attempts to create a conversation asynchronously and wraps the outcome in a Result.</summary>
    /// <param name="client">The ConversationClient instance.</param>
    /// <param name="options">The creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ConversationResource>> TryCreateConversationAsync(
        this ConversationClient client,
        ConversationCreationOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ConversationCreationOptions, CancellationToken, Task<ClientResult<ConversationResource>>> func = client.CreateConversationAsync;

        var funcResult = await func.TryAsync(options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ConversationResource>();
    }

    /// <summary>Attempts to delete a conversation and wraps the outcome in a Result.</summary>
    /// <param name="client">The ConversationClient instance.</param>
    /// <param name="conversationId">The conversation identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ConversationDeletionResult> TryDeleteConversation(
        this ConversationClient client,
        string conversationId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<ConversationDeletionResult>> func = client.DeleteConversation;

        var funcResult = func.Try(conversationId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ConversationDeletionResult>();
    }

    /// <summary>Attempts to delete a conversation asynchronously and wraps the outcome in a Result.</summary>
    /// <param name="client">The ConversationClient instance.</param>
    /// <param name="conversationId">The conversation identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ConversationDeletionResult>> TryDeleteConversationAsync(
        this ConversationClient client,
        string conversationId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<ConversationDeletionResult>>> func = client.DeleteConversationAsync;

        var funcResult = await func.TryAsync(conversationId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ConversationDeletionResult>();
    }

    /// <summary>Attempts to retrieve a conversation and wraps the outcome in a Result.</summary>
    /// <param name="client">The ConversationClient instance.</param>
    /// <param name="conversationId">The conversation identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ConversationResource> TryGetConversation(
        this ConversationClient client,
        string conversationId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<ConversationResource>> func = client.GetConversation;

        var funcResult = func.Try(conversationId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ConversationResource>();
    }

    /// <summary>Attempts to retrieve a conversation asynchronously and wraps the outcome in a Result.</summary>
    /// <param name="client">The ConversationClient instance.</param>
    /// <param name="conversationId">The conversation identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ConversationResource>> TryGetConversationAsync(
        this ConversationClient client,
        string conversationId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<ConversationResource>>> func = client.GetConversationAsync;

        var funcResult = await func.TryAsync(conversationId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ConversationResource>();
    }

    /// <summary>Attempts to update a conversation and wraps the outcome in a Result.</summary>
    /// <param name="client">The ConversationClient instance.</param>
    /// <param name="conversationId">The conversation identifier.</param>
    /// <param name="options">The update options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ConversationResource> TryUpdateConversation(
        this ConversationClient client,
        string conversationId,
        ConversationUpdateOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ConversationUpdateOptions, CancellationToken, ClientResult<ConversationResource>> func = client.UpdateConversation;

        var funcResult = func.Try(conversationId, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ConversationResource>();
    }

    /// <summary>Attempts to update a conversation asynchronously and wraps the outcome in a Result.</summary>
    /// <param name="client">The ConversationClient instance.</param>
    /// <param name="conversationId">The conversation identifier.</param>
    /// <param name="options">The update options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ConversationResource>> TryUpdateConversationAsync(
        this ConversationClient client,
        string conversationId,
        ConversationUpdateOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ConversationUpdateOptions, CancellationToken, Task<ClientResult<ConversationResource>>> func = client.UpdateConversationAsync;

        var funcResult = await func.TryAsync(conversationId, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ConversationResource>();
    }
}
