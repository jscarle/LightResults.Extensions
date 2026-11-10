using LightResults.Extensions.ExceptionHandling;
using OpenAI.Realtime;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides Try wrappers for <see cref="RealtimeClient"/> methods in OpenAI 2.15.0.
/// </summary>
[SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
public static class RealtimeClientExtensions
{
    /// <summary>
    /// Attempts to execute <c>CreateRealtimeClientSecretAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>CreateRealtimeClientSecretAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>CreateRealtimeClientSecretAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result<ClientResult>> TryCreateRealtimeClientSecretAsync(
        this RealtimeClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            RequestOptions?,
            Task<ClientResult>> func = client.CreateRealtimeClientSecretAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>CreateRealtimeClientSecretAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeClient instance.</param>
    /// <param name="options">Parameter forwarded to <c>CreateRealtimeClientSecretAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>CreateRealtimeClientSecretAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result<CreateClientSecretResult>> TryCreateRealtimeClientSecretAsync(
        this RealtimeClient client,
        CreateClientSecretOptions options,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            CreateClientSecretOptions,
            CancellationToken,
            Task<ClientResult<CreateClientSecretResult>>> func = client.CreateRealtimeClientSecretAsync;

        var funcResult = await func.TryAsync(options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<CreateClientSecretResult>();
    }

    /// <summary>
    /// Attempts to execute <c>StartConversationSessionAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>StartConversationSessionAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>StartConversationSessionAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>StartConversationSessionAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result<RealtimeSessionClient>> TryStartConversationSessionAsync(
        this RealtimeClient client,
        string model,
        RealtimeSessionClientOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RealtimeSessionClientOptions?,
            CancellationToken,
            Task<RealtimeSessionClient>> func = client.StartConversationSessionAsync;

        var funcResult = await func.TryAsync(model, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<RealtimeSessionClient>();
    }

    /// <summary>
    /// Attempts to execute <c>StartSessionAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>StartSessionAsync</c>.</param>
    /// <param name="intent">Parameter forwarded to <c>StartSessionAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>StartSessionAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>StartSessionAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result<RealtimeSessionClient>> TryStartSessionAsync(
        this RealtimeClient client,
        string model,
        string intent,
        RealtimeSessionClientOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string,
            RealtimeSessionClientOptions?,
            CancellationToken,
            Task<RealtimeSessionClient>> func = client.StartSessionAsync;

        var funcResult = await func.TryAsync(model, intent, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<RealtimeSessionClient>();
    }

    /// <summary>
    /// Attempts to execute <c>StartTranscriptionSessionAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The RealtimeClient instance.</param>
    /// <param name="options">Parameter forwarded to <c>StartTranscriptionSessionAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>StartTranscriptionSessionAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static async Task<Result<RealtimeSessionClient>> TryStartTranscriptionSessionAsync(
        this RealtimeClient client,
        RealtimeSessionClientOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            RealtimeSessionClientOptions?,
            CancellationToken,
            Task<RealtimeSessionClient>> func = client.StartTranscriptionSessionAsync;

        var funcResult = await func.TryAsync(options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<RealtimeSessionClient>();
    }
}
