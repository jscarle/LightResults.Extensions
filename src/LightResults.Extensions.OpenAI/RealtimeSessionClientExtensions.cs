using LightResults.Extensions.ExceptionHandling;
using OpenAI.Realtime;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides Try wrappers for <see cref="RealtimeSessionClient"/> methods in OpenAI 2.15.0.
/// </summary>
public static class RealtimeSessionClientExtensions
{
    /// <summary>
    /// Attempts to execute <c>AddItemAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="item">Parameter forwarded to <c>AddItemAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>AddItemAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TryAddItemAsync(
        this RealtimeSessionClient client,
        RealtimeItem item,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            RealtimeItem,
            CancellationToken,
            Task> func = client.AddItemAsync;

        Func<Task> taskFunc = () => func(item, cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>AddItemAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="item">Parameter forwarded to <c>AddItemAsync</c>.</param>
    /// <param name="previousItemId">Parameter forwarded to <c>AddItemAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>AddItemAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TryAddItemAsync(
        this RealtimeSessionClient client,
        RealtimeItem item,
        string previousItemId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            RealtimeItem,
            string,
            CancellationToken,
            Task> func = client.AddItemAsync;

        Func<Task> taskFunc = () => func(item, previousItemId, cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>CancelResponseAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>CancelResponseAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TryCancelResponseAsync(
        this RealtimeSessionClient client,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            CancellationToken,
            Task> func = client.CancelResponseAsync;

        Func<Task> taskFunc = () => func(cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>ClearInputAudioAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>ClearInputAudioAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TryClearInputAudioAsync(
        this RealtimeSessionClient client,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            CancellationToken,
            Task> func = client.ClearInputAudioAsync;

        Func<Task> taskFunc = () => func(cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>CommitPendingAudioAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>CommitPendingAudioAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TryCommitPendingAudioAsync(
        this RealtimeSessionClient client,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            CancellationToken,
            Task> func = client.CommitPendingAudioAsync;

        Func<Task> taskFunc = () => func(cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>ConfigureConversationSessionAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="sessionOptions">Parameter forwarded to <c>ConfigureConversationSessionAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>ConfigureConversationSessionAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TryConfigureConversationSessionAsync(
        this RealtimeSessionClient client,
        RealtimeConversationSessionOptions sessionOptions,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            RealtimeConversationSessionOptions,
            CancellationToken,
            Task> func = client.ConfigureConversationSessionAsync;

        Func<Task> taskFunc = () => func(sessionOptions, cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>ConfigureTranscriptionSessionAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="sessionOptions">Parameter forwarded to <c>ConfigureTranscriptionSessionAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>ConfigureTranscriptionSessionAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TryConfigureTranscriptionSessionAsync(
        this RealtimeSessionClient client,
        RealtimeTranscriptionSessionOptions sessionOptions,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            RealtimeTranscriptionSessionOptions,
            CancellationToken,
            Task> func = client.ConfigureTranscriptionSessionAsync;

        Func<Task> taskFunc = () => func(sessionOptions, cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>DeleteItemAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="itemId">Parameter forwarded to <c>DeleteItemAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>DeleteItemAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TryDeleteItemAsync(
        this RealtimeSessionClient client,
        string itemId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            CancellationToken,
            Task> func = client.DeleteItemAsync;

        Func<Task> taskFunc = () => func(itemId, cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>Dispose</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static Result TryDispose(
        this RealtimeSessionClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Action func = client.Dispose;

        var funcResult = func.Try();
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>ReceiveUpdatesAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>ReceiveUpdatesAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static Result<IAsyncEnumerable<Result<RealtimeServerUpdate>>> TryReceiveUpdatesAsync(
        this RealtimeSessionClient client,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            CancellationToken,
            IAsyncEnumerable<RealtimeServerUpdate>> func = client.ReceiveUpdatesAsync;

        var funcResult = func.Try(cancellationToken);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<RealtimeServerUpdate>>>();
    }

    /// <summary>
    /// Attempts to execute <c>ReceiveUpdatesAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="options">Parameter forwarded to <c>ReceiveUpdatesAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static Result<IAsyncEnumerable<Result<ClientResult>>> TryReceiveUpdatesAsync(
        this RealtimeSessionClient client,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            RequestOptions,
            IAsyncEnumerable<ClientResult>> func = client.ReceiveUpdatesAsync;

        var funcResult = func.Try(options);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value.AsAsyncEnumerableResult());

        return funcResult.AsFailure<IAsyncEnumerable<Result<ClientResult>>>();
    }

    /// <summary>
    /// Attempts to execute <c>RequestItemRetrievalAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="itemId">Parameter forwarded to <c>RequestItemRetrievalAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>RequestItemRetrievalAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TryRequestItemRetrievalAsync(
        this RealtimeSessionClient client,
        string itemId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            CancellationToken,
            Task> func = client.RequestItemRetrievalAsync;

        Func<Task> taskFunc = () => func(itemId, cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>SendCommandAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="command">Parameter forwarded to <c>SendCommandAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>SendCommandAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TrySendCommandAsync(
        this RealtimeSessionClient client,
        RealtimeClientCommand command,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            RealtimeClientCommand,
            CancellationToken,
            Task> func = client.SendCommandAsync;

        Func<Task> taskFunc = () => func(command, cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>SendCommandAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="data">Parameter forwarded to <c>SendCommandAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>SendCommandAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TrySendCommandAsync(
        this RealtimeSessionClient client,
        BinaryData data,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryData,
            RequestOptions,
            Task> func = client.SendCommandAsync;

        Func<Task> taskFunc = () => func(data, options);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>SendInputAudioAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="audio">Parameter forwarded to <c>SendInputAudioAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>SendInputAudioAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TrySendInputAudioAsync(
        this RealtimeSessionClient client,
        Stream audio,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            Stream,
            CancellationToken,
            Task> func = client.SendInputAudioAsync;

        Func<Task> taskFunc = () => func(audio, cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>SendInputAudioAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="audio">Parameter forwarded to <c>SendInputAudioAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>SendInputAudioAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TrySendInputAudioAsync(
        this RealtimeSessionClient client,
        BinaryData audio,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryData,
            CancellationToken,
            Task> func = client.SendInputAudioAsync;

        Func<Task> taskFunc = () => func(audio, cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>StartResponseAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>StartResponseAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TryStartResponseAsync(
        this RealtimeSessionClient client,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            CancellationToken,
            Task> func = client.StartResponseAsync;

        Func<Task> taskFunc = () => func(cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>StartResponseAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="responseOptions">Parameter forwarded to <c>StartResponseAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>StartResponseAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TryStartResponseAsync(
        this RealtimeSessionClient client,
        RealtimeResponseOptions responseOptions,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            RealtimeResponseOptions,
            CancellationToken,
            Task> func = client.StartResponseAsync;

        Func<Task> taskFunc = () => func(responseOptions, cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }

    /// <summary>
    /// Attempts to execute <c>TruncateItemAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeSessionClient instance.</param>
    /// <param name="itemId">Parameter forwarded to <c>TruncateItemAsync</c>.</param>
    /// <param name="contentPartIndex">Parameter forwarded to <c>TruncateItemAsync</c>.</param>
    /// <param name="audioDuration">Parameter forwarded to <c>TruncateItemAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>TruncateItemAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result> TryTruncateItemAsync(
        this RealtimeSessionClient client,
        string itemId,
        int contentPartIndex,
        TimeSpan audioDuration,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            int,
            TimeSpan,
            CancellationToken,
            Task> func = client.TruncateItemAsync;

        Func<Task> taskFunc = () => func(itemId, contentPartIndex, audioDuration, cancellationToken);
        var funcResult = await taskFunc.TryAsync().ConfigureAwait(false);
        return funcResult;
    }
}
