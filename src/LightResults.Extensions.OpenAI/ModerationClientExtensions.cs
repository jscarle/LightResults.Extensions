using LightResults.Extensions.ExceptionHandling;
using OpenAI.Moderations;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides missing Try wrappers for <see cref="ModerationClient"/> methods in OpenAI 2.9.0.
/// </summary>
public static class ModerationClientExtensions
{
    /// <summary>
    /// Attempts to execute <c>ClassifyInputs</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ModerationClient instance.</param>
    /// <param name="inputParts">Parameter forwarded to <c>ClassifyInputs</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>ClassifyInputs</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ModerationResult> TryClassifyInputs(
        this ModerationClient client,
        IEnumerable<ModerationInputPart> inputParts,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            IEnumerable<ModerationInputPart>,
            CancellationToken,
            ClientResult<ModerationResult>> func = client.ClassifyInputs;

        var funcResult = func.Try(inputParts, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ModerationResult>();
    }

    /// <summary>
    /// Attempts to execute <c>ClassifyInputs</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ModerationClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>ClassifyInputs</c>.</param>
    /// <param name="options">Parameter forwarded to <c>ClassifyInputs</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryClassifyInputs(
        this ModerationClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            RequestOptions?,
            ClientResult> func = client.ClassifyInputs;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>ClassifyInputsAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ModerationClient instance.</param>
    /// <param name="inputParts">Parameter forwarded to <c>ClassifyInputsAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>ClassifyInputsAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ModerationResult>> TryClassifyInputsAsync(
        this ModerationClient client,
        IEnumerable<ModerationInputPart> inputParts,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            IEnumerable<ModerationInputPart>,
            CancellationToken,
            Task<ClientResult<ModerationResult>>> func = client.ClassifyInputsAsync;

        var funcResult = await func.TryAsync(inputParts, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ModerationResult>();
    }

    /// <summary>
    /// Attempts to execute <c>ClassifyInputsAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ModerationClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>ClassifyInputsAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>ClassifyInputsAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryClassifyInputsAsync(
        this ModerationClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            RequestOptions?,
            Task<ClientResult>> func = client.ClassifyInputsAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>ClassifyText</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ModerationClient instance.</param>
    /// <param name="input">Parameter forwarded to <c>ClassifyText</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>ClassifyText</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<ModerationResult> TryClassifyText(
        this ModerationClient client,
        string input,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            CancellationToken,
            ClientResult<ModerationResult>> func = client.ClassifyText;

        var funcResult = func.Try(input, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ModerationResult>();
    }

    /// <summary>
    /// Attempts to execute <c>ClassifyText</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ModerationClient instance.</param>
    /// <param name="inputs">Parameter forwarded to <c>ClassifyText</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>ClassifyText</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<ModerationResultCollection> TryClassifyText(
        this ModerationClient client,
        IEnumerable<string> inputs,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            IEnumerable<string>,
            CancellationToken,
            ClientResult<ModerationResultCollection>> func = client.ClassifyText;

        var funcResult = func.Try(inputs, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ModerationResultCollection>();
    }

    /// <summary>
    /// Attempts to execute <c>ClassifyText</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ModerationClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>ClassifyText</c>.</param>
    /// <param name="options">Parameter forwarded to <c>ClassifyText</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<ClientResult> TryClassifyText(
        this ModerationClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            RequestOptions?,
            ClientResult> func = client.ClassifyText;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>ClassifyTextAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ModerationClient instance.</param>
    /// <param name="input">Parameter forwarded to <c>ClassifyTextAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>ClassifyTextAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static async Task<Result<ModerationResult>> TryClassifyTextAsync(
        this ModerationClient client,
        string input,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            CancellationToken,
            Task<ClientResult<ModerationResult>>> func = client.ClassifyTextAsync;

        var funcResult = await func.TryAsync(input, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ModerationResult>();
    }

    /// <summary>
    /// Attempts to execute <c>ClassifyTextAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ModerationClient instance.</param>
    /// <param name="inputs">Parameter forwarded to <c>ClassifyTextAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>ClassifyTextAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static async Task<Result<ModerationResultCollection>> TryClassifyTextAsync(
        this ModerationClient client,
        IEnumerable<string> inputs,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            IEnumerable<string>,
            CancellationToken,
            Task<ClientResult<ModerationResultCollection>>> func = client.ClassifyTextAsync;

        var funcResult = await func.TryAsync(inputs, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ModerationResultCollection>();
    }

    /// <summary>
    /// Attempts to execute <c>ClassifyTextAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The ModerationClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>ClassifyTextAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>ClassifyTextAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static async Task<Result<ClientResult>> TryClassifyTextAsync(
        this ModerationClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            RequestOptions?,
            Task<ClientResult>> func = client.ClassifyTextAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }
}
