using System.ClientModel;
using System.ClientModel.Primitives;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.Assistants;

#if NET8_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;

#else
#pragma warning disable OPENAI001
#endif

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides extension methods for <see cref="AssistantClient"/> that integrate the <see cref="Result"/> pattern, enabling safe and expressive error
/// handling for OpenAI assistant operations. These methods wrap both synchronous and asynchronous assistant requests and streaming operations in
/// <see cref="Result{T}"/> types, making it easy to handle errors and successful responses without exceptions.
/// </summary>
public static class AssistantClientExtensions
{
    /// <summary>Attempts to asynchronously create an assistant and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="model">The default model for the assistant.</param>
    /// <param name="options">Optional creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{Assistant}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<Assistant>> TryCreateAssistantAsync(
        this AssistantClient client,
        string model,
        AssistantCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, AssistantCreationOptions?, CancellationToken, Task<ClientResult<Assistant>>> func = client.CreateAssistantAsync;

        var funcResult = await func.TryAsync(model, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<Assistant>();
    }

    /// <summary>Attempts to synchronously create an assistant and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="model">The default model for the assistant.</param>
    /// <param name="options">Optional creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{Assistant}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<Assistant> TryCreateAssistant(
        this AssistantClient client,
        string model,
        AssistantCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, AssistantCreationOptions?, CancellationToken, ClientResult<Assistant>> func = client.CreateAssistant;

        var funcResult = func.Try(model, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<Assistant>();
    }

    /// <summary>Attempts to asynchronously retrieve an assistant by ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{Assistant}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<Assistant>> TryGetAssistantAsync(
        this AssistantClient client,
        string assistantId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<Assistant>>> func = client.GetAssistantAsync;

        var funcResult = await func.TryAsync(assistantId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<Assistant>();
    }

    /// <summary>Attempts to synchronously retrieve an assistant by ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{Assistant}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<Assistant> TryGetAssistant(this AssistantClient client, string assistantId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<Assistant>> func = client.GetAssistant;

        var funcResult = func.Try(assistantId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<Assistant>();
    }

    /// <summary>Attempts to asynchronously modify an assistant and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to modify.</param>
    /// <param name="options">Modification options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{Assistant}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<Assistant>> TryModifyAssistantAsync(
        this AssistantClient client,
        string assistantId,
        AssistantModificationOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, AssistantModificationOptions, CancellationToken, Task<ClientResult<Assistant>>> func = client.ModifyAssistantAsync;

        var funcResult = await func.TryAsync(assistantId, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<Assistant>();
    }

    /// <summary>Attempts to synchronously modify an assistant and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to modify.</param>
    /// <param name="options">Modification options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{Assistant}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<Assistant> TryModifyAssistant(
        this AssistantClient client,
        string assistantId,
        AssistantModificationOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, AssistantModificationOptions, CancellationToken, ClientResult<Assistant>> func = client.ModifyAssistant;

        var funcResult = func.Try(assistantId, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<Assistant>();
    }

    /// <summary>Attempts to asynchronously delete an assistant and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AssistantDeletionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<AssistantDeletionResult>> TryDeleteAssistantAsync(
        this AssistantClient client,
        string assistantId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<AssistantDeletionResult>>> func = client.DeleteAssistantAsync;

        var funcResult = await func.TryAsync(assistantId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AssistantDeletionResult>();
    }

    /// <summary>Attempts to synchronously delete an assistant and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{AssistantDeletionResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<AssistantDeletionResult> TryDeleteAssistant(
        this AssistantClient client,
        string assistantId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<AssistantDeletionResult>> func = client.DeleteAssistant;

        var funcResult = func.Try(assistantId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AssistantDeletionResult>();
    }

    /// <summary>Attempts to asynchronously create a thread and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="options">Thread creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AssistantThread}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<AssistantThread>> TryCreateThreadAsync(
        this AssistantClient client,
        ThreadCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ThreadCreationOptions?, CancellationToken, Task<ClientResult<AssistantThread>>> func = client.CreateThreadAsync;

        var funcResult = await func.TryAsync(options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AssistantThread>();
    }

    /// <summary>Attempts to synchronously create a thread and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="options">Thread creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{AssistantThread}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<AssistantThread> TryCreateThread(
        this AssistantClient client,
        ThreadCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ThreadCreationOptions?, CancellationToken, ClientResult<AssistantThread>> func = client.CreateThread;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AssistantThread>();
    }

    /// <summary>Attempts to asynchronously retrieve a thread by ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AssistantThread}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<AssistantThread>> TryGetThreadAsync(
        this AssistantClient client,
        string threadId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<AssistantThread>>> func = client.GetThreadAsync;

        var funcResult = await func.TryAsync(threadId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AssistantThread>();
    }

    /// <summary>Attempts to synchronously retrieve a thread by ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{AssistantThread}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<AssistantThread> TryGetThread(this AssistantClient client, string threadId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<AssistantThread>> func = client.GetThread;

        var funcResult = func.Try(threadId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AssistantThread>();
    }

    /// <summary>Attempts to asynchronously modify a thread and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to modify.</param>
    /// <param name="options">Thread modification options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AssistantThread}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<AssistantThread>> TryModifyThreadAsync(
        this AssistantClient client,
        string threadId,
        ThreadModificationOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ThreadModificationOptions, CancellationToken, Task<ClientResult<AssistantThread>>> func = client.ModifyThreadAsync;

        var funcResult = await func.TryAsync(threadId, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AssistantThread>();
    }

    /// <summary>Attempts to synchronously modify a thread and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to modify.</param>
    /// <param name="options">Thread modification options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{AssistantThread}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<AssistantThread> TryModifyThread(
        this AssistantClient client,
        string threadId,
        ThreadModificationOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ThreadModificationOptions, CancellationToken, ClientResult<AssistantThread>> func = client.ModifyThread;

        var funcResult = func.Try(threadId, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AssistantThread>();
    }

    /// <summary>Attempts to asynchronously delete a thread and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ThreadDeletionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ThreadDeletionResult>> TryDeleteThreadAsync(
        this AssistantClient client,
        string threadId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<ThreadDeletionResult>>> func = client.DeleteThreadAsync;

        var funcResult = await func.TryAsync(threadId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadDeletionResult>();
    }

    /// <summary>Attempts to synchronously delete a thread and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{ThreadDeletionResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ThreadDeletionResult> TryDeleteThread(this AssistantClient client, string threadId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<ThreadDeletionResult>> func = client.DeleteThread;

        var funcResult = func.Try(threadId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadDeletionResult>();
    }

    /// <summary>Attempts to asynchronously create a message in a thread and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to associate the message with.</param>
    /// <param name="role">The role for the message.</param>
    /// <param name="content">The content items for the message.</param>
    /// <param name="options">Additional message options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ThreadMessage}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ThreadMessage>> TryCreateMessageAsync(
        this AssistantClient client,
        string threadId,
        MessageRole role,
        IEnumerable<MessageContent> content,
        MessageCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, MessageRole, IEnumerable<MessageContent>, MessageCreationOptions?, CancellationToken, Task<ClientResult<ThreadMessage>>> func =
            client.CreateMessageAsync;

        var funcResult = await func.TryAsync(threadId, role, content, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadMessage>();
    }

    /// <summary>Attempts to synchronously create a message in a thread and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to associate the message with.</param>
    /// <param name="role">The role for the message.</param>
    /// <param name="content">The content items for the message.</param>
    /// <param name="options">Additional message options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{ThreadMessage}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ThreadMessage> TryCreateMessage(
        this AssistantClient client,
        string threadId,
        MessageRole role,
        IEnumerable<MessageContent> content,
        MessageCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, MessageRole, IEnumerable<MessageContent>, MessageCreationOptions?, CancellationToken, ClientResult<ThreadMessage>> func =
            client.CreateMessage;

        var funcResult = func.Try(threadId, role, content, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadMessage>();
    }

    /// <summary>Attempts to asynchronously retrieve a message by ID in a thread and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve the message from.</param>
    /// <param name="messageId">The message ID to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ThreadMessage}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ThreadMessage>> TryGetMessageAsync(
        this AssistantClient client,
        string threadId,
        string messageId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, Task<ClientResult<ThreadMessage>>> func = client.GetMessageAsync;

        var funcResult = await func.TryAsync(threadId, messageId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadMessage>();
    }

    /// <summary>Attempts to synchronously retrieve a message by ID in a thread and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve the message from.</param>
    /// <param name="messageId">The message ID to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{ThreadMessage}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ThreadMessage> TryGetMessage(
        this AssistantClient client,
        string threadId,
        string messageId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, ClientResult<ThreadMessage>> func = client.GetMessage;

        var funcResult = func.Try(threadId, messageId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadMessage>();
    }

    /// <summary>Attempts to asynchronously modify a message and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID associated with the message.</param>
    /// <param name="messageId">The message ID to modify.</param>
    /// <param name="options">Modification options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ThreadMessage}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ThreadMessage>> TryModifyMessageAsync(
        this AssistantClient client,
        string threadId,
        string messageId,
        MessageModificationOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, MessageModificationOptions, CancellationToken, Task<ClientResult<ThreadMessage>>> func = client.ModifyMessageAsync;

        var funcResult = await func.TryAsync(threadId, messageId, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadMessage>();
    }

    /// <summary>Attempts to synchronously modify a message and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID associated with the message.</param>
    /// <param name="messageId">The message ID to modify.</param>
    /// <param name="options">Modification options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{ThreadMessage}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ThreadMessage> TryModifyMessage(
        this AssistantClient client,
        string threadId,
        string messageId,
        MessageModificationOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, MessageModificationOptions, CancellationToken, ClientResult<ThreadMessage>> func = client.ModifyMessage;

        var funcResult = func.Try(threadId, messageId, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadMessage>();
    }

    /// <summary>Attempts to asynchronously delete a message and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID associated with the message.</param>
    /// <param name="messageId">The message ID to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{MessageDeletionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<MessageDeletionResult>> TryDeleteMessageAsync(
        this AssistantClient client,
        string threadId,
        string messageId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, Task<ClientResult<MessageDeletionResult>>> func = client.DeleteMessageAsync;

        var funcResult = await func.TryAsync(threadId, messageId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<MessageDeletionResult>();
    }

    /// <summary>Attempts to synchronously delete a message and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID associated with the message.</param>
    /// <param name="messageId">The message ID to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{MessageDeletionResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<MessageDeletionResult> TryDeleteMessage(
        this AssistantClient client,
        string threadId,
        string messageId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, ClientResult<MessageDeletionResult>> func = client.DeleteMessage;

        var funcResult = func.Try(threadId, messageId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<MessageDeletionResult>();
    }

    /// <summary>Attempts to asynchronously create a run and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to evaluate.</param>
    /// <param name="assistantId">The assistant ID to use.</param>
    /// <param name="options">Run creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ThreadRun}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ThreadRun>> TryCreateRunAsync(
        this AssistantClient client,
        string threadId,
        string assistantId,
        RunCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RunCreationOptions?, CancellationToken, Task<ClientResult<ThreadRun>>> func = client.CreateRunAsync;

        var funcResult = await func.TryAsync(threadId, assistantId, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadRun>();
    }

    /// <summary>Attempts to synchronously create a run and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to evaluate.</param>
    /// <param name="assistantId">The assistant ID to use.</param>
    /// <param name="options">Run creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{ThreadRun}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ThreadRun> TryCreateRun(
        this AssistantClient client,
        string threadId,
        string assistantId,
        RunCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RunCreationOptions?, CancellationToken, ClientResult<ThreadRun>> func = client.CreateRun;

        var funcResult = func.Try(threadId, assistantId, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadRun>();
    }

    /// <summary>Attempts to asynchronously create a streaming run and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to evaluate.</param>
    /// <param name="assistantId">The assistant ID to use.</param>
    /// <param name="options">Run creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingUpdate}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<StreamingUpdate>>> TryCreateRunStreamingAsync(
        this AssistantClient client,
        string threadId,
        string assistantId,
        RunCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RunCreationOptions?, CancellationToken, AsyncCollectionResult<StreamingUpdate>> func = client.CreateRunStreamingAsync;

        var funcResult = func.Try(threadId, assistantId, options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingUpdate>>>();
    }

    /// <summary>Attempts to synchronously create a streaming run and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to evaluate.</param>
    /// <param name="assistantId">The assistant ID to use.</param>
    /// <param name="options">Run creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingUpdate}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<StreamingUpdate>>> TryCreateRunStreaming(
        this AssistantClient client,
        string threadId,
        string assistantId,
        RunCreationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RunCreationOptions?, CancellationToken, CollectionResult<StreamingUpdate>> func = client.CreateRunStreaming;

        var funcResult = func.Try(threadId, assistantId, options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingUpdate>>>();
    }

    /// <summary>Attempts to asynchronously create a thread and run, and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to use.</param>
    /// <param name="threadOptions">Thread creation options.</param>
    /// <param name="runOptions">Run creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ThreadRun}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ThreadRun>> TryCreateThreadAndRunAsync(
        this AssistantClient client,
        string assistantId,
        ThreadCreationOptions? threadOptions = null,
        RunCreationOptions? runOptions = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ThreadCreationOptions?, RunCreationOptions?, CancellationToken, Task<ClientResult<ThreadRun>>> func = client.CreateThreadAndRunAsync;

        var funcResult = await func.TryAsync(assistantId, threadOptions, runOptions, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadRun>();
    }

    /// <summary>Attempts to synchronously create a thread and run, and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to use.</param>
    /// <param name="threadOptions">Thread creation options.</param>
    /// <param name="runOptions">Run creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{ThreadRun}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ThreadRun> TryCreateThreadAndRun(
        this AssistantClient client,
        string assistantId,
        ThreadCreationOptions? threadOptions = null,
        RunCreationOptions? runOptions = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ThreadCreationOptions?, RunCreationOptions?, CancellationToken, ClientResult<ThreadRun>> func = client.CreateThreadAndRun;

        var funcResult = func.Try(assistantId, threadOptions, runOptions, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadRun>();
    }

    /// <summary>Attempts to asynchronously create a thread and run with streaming, and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to use.</param>
    /// <param name="threadOptions">Thread creation options.</param>
    /// <param name="runOptions">Run creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingUpdate}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<StreamingUpdate>>> TryCreateThreadAndRunStreamingAsync(
        this AssistantClient client,
        string assistantId,
        ThreadCreationOptions? threadOptions = null,
        RunCreationOptions? runOptions = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ThreadCreationOptions?, RunCreationOptions?, CancellationToken, AsyncCollectionResult<StreamingUpdate>> func =
            client.CreateThreadAndRunStreamingAsync;

        var funcResult = func.Try(assistantId, threadOptions, runOptions, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingUpdate>>>();
    }

    /// <summary>Attempts to synchronously create a thread and run with streaming, and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to use.</param>
    /// <param name="threadOptions">Thread creation options.</param>
    /// <param name="runOptions">Run creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingUpdate}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<StreamingUpdate>>> TryCreateThreadAndRunStreaming(
        this AssistantClient client,
        string assistantId,
        ThreadCreationOptions? threadOptions = null,
        RunCreationOptions? runOptions = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ThreadCreationOptions?, RunCreationOptions?, CancellationToken, CollectionResult<StreamingUpdate>> func =
            client.CreateThreadAndRunStreaming;

        var funcResult = func.Try(assistantId, threadOptions, runOptions, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingUpdate>>>();
    }

    /// <summary>Attempts to asynchronously cancel a run and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to cancel.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ThreadRun}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ThreadRun>> TryCancelRunAsync(
        this AssistantClient client,
        string threadId,
        string runId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, Task<ClientResult<ThreadRun>>> func = client.CancelRunAsync;

        var funcResult = await func.TryAsync(threadId, runId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadRun>();
    }

    /// <summary>Attempts to synchronously cancel a run and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to cancel.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{ThreadRun}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ThreadRun> TryCancelRun(this AssistantClient client, string threadId, string runId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, ClientResult<ThreadRun>> func = client.CancelRun;

        var funcResult = func.Try(threadId, runId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadRun>();
    }

    /// <summary>Attempts to asynchronously retrieve assistants and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="options">Assistant collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{Assistant}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<Assistant>>> TryGetAssistantsAsync(
        this AssistantClient client,
        AssistantCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<AssistantCollectionOptions?, CancellationToken, AsyncCollectionResult<Assistant>> func = client.GetAssistantsAsync;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<Assistant>>>();
    }

    /// <summary>Attempts to asynchronously retrieve assistants with continuation token and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="firstPageToken">The continuation token for the first page.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{Assistant}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<Assistant>>> TryGetAssistantsAsync(
        this AssistantClient client,
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ContinuationToken, CancellationToken, AsyncCollectionResult<Assistant>> func = client.GetAssistantsAsync;

        var funcResult = func.Try(firstPageToken, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<Assistant>>>();
    }

    /// <summary>Attempts to synchronously retrieve assistants and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="options">Assistant collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{Assistant}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<Assistant>>> TryGetAssistants(
        this AssistantClient client,
        AssistantCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<AssistantCollectionOptions?, CancellationToken, CollectionResult<Assistant>> func = client.GetAssistants;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<Assistant>>>();
    }

    /// <summary>Attempts to synchronously retrieve assistants with continuation token and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="firstPageToken">The continuation token for the first page.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{Assistant}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<Assistant>>> TryGetAssistants(
        this AssistantClient client,
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ContinuationToken, CancellationToken, CollectionResult<Assistant>> func = client.GetAssistants;

        var funcResult = func.Try(firstPageToken, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<Assistant>>>();
    }

    /// <summary>Attempts to asynchronously retrieve messages and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve messages from.</param>
    /// <param name="options">Message collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{ThreadMessage}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<ThreadMessage>>> TryGetMessagesAsync(
        this AssistantClient client,
        string threadId,
        MessageCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, MessageCollectionOptions?, CancellationToken, AsyncCollectionResult<ThreadMessage>> func = client.GetMessagesAsync;

        var funcResult = func.Try(threadId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<ThreadMessage>>>();
    }

    /// <summary>Attempts to asynchronously retrieve messages with continuation token and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="firstPageToken">The continuation token for the first page.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{ThreadMessage}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<ThreadMessage>>> TryGetMessagesAsync(
        this AssistantClient client,
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ContinuationToken, CancellationToken, AsyncCollectionResult<ThreadMessage>> func = client.GetMessagesAsync;

        var funcResult = func.Try(firstPageToken, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<ThreadMessage>>>();
    }

    /// <summary>Attempts to synchronously retrieve messages and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve messages from.</param>
    /// <param name="options">Message collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{ThreadMessage}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<ThreadMessage>>> TryGetMessages(
        this AssistantClient client,
        string threadId,
        MessageCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, MessageCollectionOptions?, CancellationToken, CollectionResult<ThreadMessage>> func = client.GetMessages;

        var funcResult = func.Try(threadId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<ThreadMessage>>>();
    }

    /// <summary>Attempts to synchronously retrieve messages with continuation token and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="firstPageToken">The continuation token for the first page.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{ThreadMessage}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<ThreadMessage>>> TryGetMessages(
        this AssistantClient client,
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ContinuationToken, CancellationToken, CollectionResult<ThreadMessage>> func = client.GetMessages;

        var funcResult = func.Try(firstPageToken, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<ThreadMessage>>>();
    }

    /// <summary>Attempts to asynchronously retrieve a run by ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ThreadRun}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ThreadRun>> TryGetRunAsync(
        this AssistantClient client,
        string threadId,
        string runId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, Task<ClientResult<ThreadRun>>> func = client.GetRunAsync;

        var funcResult = await func.TryAsync(threadId, runId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadRun>();
    }

    /// <summary>Attempts to synchronously retrieve a run by ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{ThreadRun}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ThreadRun> TryGetRun(this AssistantClient client, string threadId, string runId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, CancellationToken, ClientResult<ThreadRun>> func = client.GetRun;

        var funcResult = func.Try(threadId, runId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadRun>();
    }

    /// <summary>Attempts to asynchronously retrieve runs and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve runs from.</param>
    /// <param name="options">Run collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{ThreadRun}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<ThreadRun>>> TryGetRunsAsync(
        this AssistantClient client,
        string threadId,
        RunCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RunCollectionOptions?, CancellationToken, AsyncCollectionResult<ThreadRun>> func = client.GetRunsAsync;

        var funcResult = func.Try(threadId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<ThreadRun>>>();
    }

    /// <summary>Attempts to asynchronously retrieve runs with continuation token and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="firstPageToken">The continuation token for the first page.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{ThreadRun}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<ThreadRun>>> TryGetRunsAsync(
        this AssistantClient client,
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ContinuationToken, CancellationToken, AsyncCollectionResult<ThreadRun>> func = client.GetRunsAsync;

        var funcResult = func.Try(firstPageToken, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<ThreadRun>>>();
    }

    /// <summary>Attempts to synchronously retrieve runs and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve runs from.</param>
    /// <param name="options">Run collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{ThreadRun}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<ThreadRun>>> TryGetRuns(
        this AssistantClient client,
        string threadId,
        RunCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RunCollectionOptions?, CancellationToken, CollectionResult<ThreadRun>> func = client.GetRuns;

        var funcResult = func.Try(threadId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<ThreadRun>>>();
    }

    /// <summary>Attempts to synchronously retrieve runs with continuation token and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="firstPageToken">The continuation token for the first page.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{ThreadRun}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<ThreadRun>>> TryGetRuns(
        this AssistantClient client,
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ContinuationToken, CancellationToken, CollectionResult<ThreadRun>> func = client.GetRuns;

        var funcResult = func.Try(firstPageToken, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<ThreadRun>>>();
    }

    /// <summary>Attempts to asynchronously retrieve a run step by ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID containing the step.</param>
    /// <param name="stepId">The step ID to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{RunStep}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<RunStep>> TryGetRunStepAsync(
        this AssistantClient client,
        string threadId,
        string runId,
        string stepId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, string, CancellationToken, Task<ClientResult<RunStep>>> func = client.GetRunStepAsync;

        var funcResult = await func.TryAsync(threadId, runId, stepId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<RunStep>();
    }

    /// <summary>Attempts to synchronously retrieve a run step by ID and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID containing the step.</param>
    /// <param name="stepId">The step ID to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{RunStep}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<RunStep> TryGetRunStep(
        this AssistantClient client,
        string threadId,
        string runId,
        string stepId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, string, CancellationToken, ClientResult<RunStep>> func = client.GetRunStep;

        var funcResult = func.Try(threadId, runId, stepId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<RunStep>();
    }

    /// <summary>Attempts to asynchronously retrieve run steps and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to retrieve steps from.</param>
    /// <param name="options">Run step collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{RunStep}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<RunStep>>> TryGetRunStepsAsync(
        this AssistantClient client,
        string threadId,
        string runId,
        RunStepCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RunStepCollectionOptions?, CancellationToken, AsyncCollectionResult<RunStep>> func = client.GetRunStepsAsync;

        var funcResult = func.Try(threadId, runId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<RunStep>>>();
    }

    /// <summary>Attempts to asynchronously retrieve run steps with continuation token and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="firstPageToken">The continuation token for the first page.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{RunStep}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<RunStep>>> TryGetRunStepsAsync(
        this AssistantClient client,
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ContinuationToken, CancellationToken, AsyncCollectionResult<RunStep>> func = client.GetRunStepsAsync;

        var funcResult = func.Try(firstPageToken, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<RunStep>>>();
    }

    /// <summary>Attempts to synchronously retrieve run steps and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to retrieve steps from.</param>
    /// <param name="options">Run step collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{RunStep}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<RunStep>>> TryGetRunSteps(
        this AssistantClient client,
        string threadId,
        string runId,
        RunStepCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RunStepCollectionOptions?, CancellationToken, CollectionResult<RunStep>> func = client.GetRunSteps;

        var funcResult = func.Try(threadId, runId, options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<RunStep>>>();
    }

    /// <summary>Attempts to synchronously retrieve run steps with continuation token and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="firstPageToken">The continuation token for the first page.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{RunStep}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<RunStep>>> TryGetRunSteps(
        this AssistantClient client,
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ContinuationToken, CancellationToken, CollectionResult<RunStep>> func = client.GetRunSteps;

        var funcResult = func.Try(firstPageToken, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<RunStep>>>();
    }

    /// <summary>Attempts to asynchronously submit tool outputs to a run and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to submit tool outputs to.</param>
    /// <param name="toolOutputs">The tool outputs to submit.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ThreadRun}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ThreadRun>> TrySubmitToolOutputsToRunAsync(
        this AssistantClient client,
        string threadId,
        string runId,
        IEnumerable<ToolOutput> toolOutputs,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, IEnumerable<ToolOutput>, CancellationToken, Task<ClientResult<ThreadRun>>> func = client.SubmitToolOutputsToRunAsync;

        var funcResult = await func.TryAsync(threadId, runId, toolOutputs, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadRun>();
    }

    /// <summary>Attempts to synchronously submit tool outputs to a run and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to submit tool outputs to.</param>
    /// <param name="toolOutputs">The tool outputs to submit.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{ThreadRun}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ThreadRun> TrySubmitToolOutputsToRun(
        this AssistantClient client,
        string threadId,
        string runId,
        IEnumerable<ToolOutput> toolOutputs,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, IEnumerable<ToolOutput>, CancellationToken, ClientResult<ThreadRun>> func = client.SubmitToolOutputsToRun;

        var funcResult = func.Try(threadId, runId, toolOutputs, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ThreadRun>();
    }

    /// <summary>Attempts to asynchronously submit tool outputs to a run with streaming and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to submit tool outputs to.</param>
    /// <param name="toolOutputs">The tool outputs to submit.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingUpdate}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<StreamingUpdate>>> TrySubmitToolOutputsToRunStreamingAsync(
        this AssistantClient client,
        string threadId,
        string runId,
        IEnumerable<ToolOutput> toolOutputs,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, IEnumerable<ToolOutput>, CancellationToken, AsyncCollectionResult<StreamingUpdate>> func =
            client.SubmitToolOutputsToRunStreamingAsync;

        var funcResult = func.Try(threadId, runId, toolOutputs, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingUpdate>>>();
    }

    /// <summary>Attempts to synchronously submit tool outputs to a run with streaming and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to submit tool outputs to.</param>
    /// <param name="toolOutputs">The tool outputs to submit.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingUpdate}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<StreamingUpdate>>> TrySubmitToolOutputsToRunStreaming(
        this AssistantClient client,
        string threadId,
        string runId,
        IEnumerable<ToolOutput> toolOutputs,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, IEnumerable<ToolOutput>, CancellationToken, CollectionResult<StreamingUpdate>> func = client.SubmitToolOutputsToRunStreaming;

        var funcResult = func.Try(threadId, runId, toolOutputs, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingUpdate>>>();
    }

    /// <summary>Attempts to asynchronously create an assistant with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryCreateAssistantAsync(this AssistantClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CreateAssistantAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously create an assistant with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryCreateAssistant(this AssistantClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, ClientResult> func = client.CreateAssistant;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously retrieve an assistant with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to retrieve.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryGetAssistantAsync(this AssistantClient client, string assistantId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, Task<ClientResult>> func = client.GetAssistantAsync;

        var funcResult = await func.TryAsync(assistantId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously retrieve an assistant with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to retrieve.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryGetAssistant(this AssistantClient client, string assistantId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, ClientResult> func = client.GetAssistant;

        var funcResult = func.Try(assistantId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously modify an assistant with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to modify.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryModifyAssistantAsync(
        this AssistantClient client,
        string assistantId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.ModifyAssistantAsync;

        var funcResult = await func.TryAsync(assistantId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously modify an assistant with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to modify.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryModifyAssistant(
        this AssistantClient client,
        string assistantId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, ClientResult> func = client.ModifyAssistant;

        var funcResult = func.Try(assistantId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously delete an assistant with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to delete.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryDeleteAssistantAsync(this AssistantClient client, string assistantId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, Task<ClientResult>> func = client.DeleteAssistantAsync;

        var funcResult = await func.TryAsync(assistantId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously delete an assistant with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="assistantId">The assistant ID to delete.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryDeleteAssistant(this AssistantClient client, string assistantId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, ClientResult> func = client.DeleteAssistant;

        var funcResult = func.Try(assistantId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously modify a run with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to modify.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryModifyRunAsync(
        this AssistantClient client,
        string threadId,
        string runId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.ModifyRunAsync;

        var funcResult = await func.TryAsync(threadId, runId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously modify a run with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to modify.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryModifyRun(
        this AssistantClient client,
        string threadId,
        string runId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, BinaryContent, RequestOptions?, ClientResult> func = client.ModifyRun;

        var funcResult = func.Try(threadId, runId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously cancel a run with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to cancel.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryCancelRunAsync(this AssistantClient client, string threadId, string runId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, Task<ClientResult>> func = client.CancelRunAsync;

        var funcResult = await func.TryAsync(threadId, runId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously cancel a run with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to cancel.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryCancelRun(this AssistantClient client, string threadId, string runId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, ClientResult> func = client.CancelRun;

        var funcResult = func.Try(threadId, runId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously create a thread with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryCreateThreadAsync(this AssistantClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CreateThreadAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously create a thread with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryCreateThread(this AssistantClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, ClientResult> func = client.CreateThread;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously create a thread and run with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryCreateThreadAndRunAsync(
        this AssistantClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CreateThreadAndRunAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously create a thread and run with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryCreateThreadAndRun(this AssistantClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, ClientResult> func = client.CreateThreadAndRun;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously submit tool outputs to a run with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to submit tool outputs to.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TrySubmitToolOutputsToRunAsync(
        this AssistantClient client,
        string threadId,
        string runId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.SubmitToolOutputsToRunAsync;

        var funcResult = await func.TryAsync(threadId, runId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously submit tool outputs to a run with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to submit tool outputs to.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TrySubmitToolOutputsToRun(
        this AssistantClient client,
        string threadId,
        string runId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, BinaryContent, RequestOptions?, ClientResult> func = client.SubmitToolOutputsToRun;

        var funcResult = func.Try(threadId, runId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously create a message with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to associate the message with.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryCreateMessageAsync(
        this AssistantClient client,
        string threadId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CreateMessageAsync;

        var funcResult = await func.TryAsync(threadId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously create a message with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to associate the message with.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryCreateMessage(this AssistantClient client, string threadId, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, ClientResult> func = client.CreateMessage;

        var funcResult = func.Try(threadId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously retrieve a message with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve the message from.</param>
    /// <param name="messageId">The message ID to retrieve.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryGetMessageAsync(this AssistantClient client, string threadId, string messageId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, Task<ClientResult>> func = client.GetMessageAsync;

        var funcResult = await func.TryAsync(threadId, messageId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously retrieve a message with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve the message from.</param>
    /// <param name="messageId">The message ID to retrieve.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryGetMessage(this AssistantClient client, string threadId, string messageId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, ClientResult> func = client.GetMessage;

        var funcResult = func.Try(threadId, messageId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously modify a message with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID associated with the message.</param>
    /// <param name="messageId">The message ID to modify.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryModifyMessageAsync(
        this AssistantClient client,
        string threadId,
        string messageId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.ModifyMessageAsync;

        var funcResult = await func.TryAsync(threadId, messageId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously modify a message with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID associated with the message.</param>
    /// <param name="messageId">The message ID to modify.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryModifyMessage(
        this AssistantClient client,
        string threadId,
        string messageId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, BinaryContent, RequestOptions?, ClientResult> func = client.ModifyMessage;

        var funcResult = func.Try(threadId, messageId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously delete a message with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID associated with the message.</param>
    /// <param name="messageId">The message ID to delete.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryDeleteMessageAsync(this AssistantClient client, string threadId, string messageId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, Task<ClientResult>> func = client.DeleteMessageAsync;

        var funcResult = await func.TryAsync(threadId, messageId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously delete a message with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID associated with the message.</param>
    /// <param name="messageId">The message ID to delete.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryDeleteMessage(this AssistantClient client, string threadId, string messageId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, ClientResult> func = client.DeleteMessage;

        var funcResult = func.Try(threadId, messageId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously retrieve a thread with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryGetThreadAsync(this AssistantClient client, string threadId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, Task<ClientResult>> func = client.GetThreadAsync;

        var funcResult = await func.TryAsync(threadId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously retrieve a thread with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryGetThread(this AssistantClient client, string threadId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, ClientResult> func = client.GetThread;

        var funcResult = func.Try(threadId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously modify a thread with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to modify.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryModifyThreadAsync(
        this AssistantClient client,
        string threadId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.ModifyThreadAsync;

        var funcResult = await func.TryAsync(threadId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously modify a thread with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to modify.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryModifyThread(this AssistantClient client, string threadId, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, ClientResult> func = client.ModifyThread;

        var funcResult = func.Try(threadId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously delete a thread with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to delete.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryDeleteThreadAsync(this AssistantClient client, string threadId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, Task<ClientResult>> func = client.DeleteThreadAsync;

        var funcResult = await func.TryAsync(threadId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously delete a thread with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to delete.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryDeleteThread(this AssistantClient client, string threadId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, ClientResult> func = client.DeleteThread;

        var funcResult = func.Try(threadId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously retrieve a run with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to retrieve.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryGetRunAsync(this AssistantClient client, string threadId, string runId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, Task<ClientResult>> func = client.GetRunAsync;

        var funcResult = await func.TryAsync(threadId, runId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously retrieve a run with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to retrieve.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryGetRun(this AssistantClient client, string threadId, string runId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, ClientResult> func = client.GetRun;

        var funcResult = func.Try(threadId, runId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously retrieve a run step with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID containing the step.</param>
    /// <param name="stepId">The step ID to retrieve.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryGetRunStepAsync(
        this AssistantClient client,
        string threadId,
        string runId,
        string stepId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, string, RequestOptions, Task<ClientResult>> func = client.GetRunStepAsync;

        var funcResult = await func.TryAsync(threadId, runId, stepId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously retrieve a run step with request options and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID containing the step.</param>
    /// <param name="stepId">The step ID to retrieve.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryGetRunStep(this AssistantClient client, string threadId, string runId, string stepId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, string, RequestOptions, ClientResult> func = client.GetRunStep;

        var funcResult = func.Try(threadId, runId, stepId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to asynchronously retrieve assistants with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="limit">The optional limit.</param>
    /// <param name="order">The order direction.</param>
    /// <param name="after">The pagination cursor after.</param>
    /// <param name="before">The pagination cursor before.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AsyncCollectionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<AsyncCollectionResult>> TryGetAssistantsAsync(
        this AssistantClient client,
        int? limit,
        string order,
        string after,
        string before,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<int?, string, string, string, RequestOptions, AsyncCollectionResult> func = client.GetAssistantsAsync;

        var funcResult = await Task.Run(() => func.Try(limit, order, after, before, options)).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>Attempts to synchronously retrieve assistants with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="limit">The optional limit.</param>
    /// <param name="order">The order direction.</param>
    /// <param name="after">The pagination cursor after.</param>
    /// <param name="before">The pagination cursor before.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{CollectionResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<CollectionResult> TryGetAssistants(
        this AssistantClient client,
        int? limit,
        string order,
        string after,
        string before,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<int?, string, string, string, RequestOptions, CollectionResult> func = client.GetAssistants;

        var funcResult = func.Try(limit, order, after, before, options);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>Attempts to asynchronously retrieve messages with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve messages from.</param>
    /// <param name="limit">The optional limit.</param>
    /// <param name="order">The order direction.</param>
    /// <param name="after">The pagination cursor after.</param>
    /// <param name="before">The pagination cursor before.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AsyncCollectionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<AsyncCollectionResult>> TryGetMessagesAsync(
        this AssistantClient client,
        string threadId,
        int? limit,
        string order,
        string after,
        string before,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string, string, string, RequestOptions, AsyncCollectionResult> func = client.GetMessagesAsync;

        var funcResult = await Task.Run(() => func.Try(threadId, limit, order, after, before, options)).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>Attempts to synchronously retrieve messages with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve messages from.</param>
    /// <param name="limit">The optional limit.</param>
    /// <param name="order">The order direction.</param>
    /// <param name="after">The pagination cursor after.</param>
    /// <param name="before">The pagination cursor before.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{CollectionResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<CollectionResult> TryGetMessages(
        this AssistantClient client,
        string threadId,
        int? limit,
        string order,
        string after,
        string before,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string, string, string, RequestOptions, CollectionResult> func = client.GetMessages;

        var funcResult = func.Try(threadId, limit, order, after, before, options);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>Attempts to asynchronously retrieve runs with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve runs from.</param>
    /// <param name="limit">The optional limit.</param>
    /// <param name="order">The order direction.</param>
    /// <param name="after">The pagination cursor after.</param>
    /// <param name="before">The pagination cursor before.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AsyncCollectionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<AsyncCollectionResult>> TryGetRunsAsync(
        this AssistantClient client,
        string threadId,
        int? limit,
        string order,
        string after,
        string before,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string, string, string, RequestOptions, AsyncCollectionResult> func = client.GetRunsAsync;

        var funcResult = await Task.Run(() => func.Try(threadId, limit, order, after, before, options)).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>Attempts to synchronously retrieve runs with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to retrieve runs from.</param>
    /// <param name="limit">The optional limit.</param>
    /// <param name="order">The order direction.</param>
    /// <param name="after">The pagination cursor after.</param>
    /// <param name="before">The pagination cursor before.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{CollectionResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<CollectionResult> TryGetRuns(
        this AssistantClient client,
        string threadId,
        int? limit,
        string order,
        string after,
        string before,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string, string, string, RequestOptions, CollectionResult> func = client.GetRuns;

        var funcResult = func.Try(threadId, limit, order, after, before, options);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>Attempts to asynchronously retrieve run steps with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to retrieve steps from.</param>
    /// <param name="limit">The optional limit.</param>
    /// <param name="order">The order direction.</param>
    /// <param name="after">The pagination cursor after.</param>
    /// <param name="before">The pagination cursor before.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AsyncCollectionResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<AsyncCollectionResult>> TryGetRunStepsAsync(
        this AssistantClient client,
        string threadId,
        string runId,
        int? limit,
        string order,
        string after,
        string before,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, int?, string, string, string, RequestOptions, AsyncCollectionResult> func = client.GetRunStepsAsync;

        var funcResult = await Task.Run(() => func.Try(threadId, runId, limit, order, after, before, options)).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>Attempts to synchronously retrieve run steps with pagination parameters and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID containing the run.</param>
    /// <param name="runId">The run ID to retrieve steps from.</param>
    /// <param name="limit">The optional limit.</param>
    /// <param name="order">The order direction.</param>
    /// <param name="after">The pagination cursor after.</param>
    /// <param name="before">The pagination cursor before.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{CollectionResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<CollectionResult> TryGetRunSteps(
        this AssistantClient client,
        string threadId,
        string runId,
        int? limit,
        string order,
        string after,
        string before,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, int?, string, string, string, RequestOptions, CollectionResult> func = client.GetRunSteps;

        var funcResult = func.Try(threadId, runId, limit, order, after, before, options);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>Attempts to asynchronously create a run with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to evaluate.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryCreateRunAsync(
        this AssistantClient client,
        string threadId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CreateRunAsync;

        var funcResult = await func.TryAsync(threadId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to synchronously create a run with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The assistant client instance.</param>
    /// <param name="threadId">The thread ID to evaluate.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryCreateRun(this AssistantClient client, string threadId, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, ClientResult> func = client.CreateRun;

        var funcResult = func.Try(threadId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }
}
