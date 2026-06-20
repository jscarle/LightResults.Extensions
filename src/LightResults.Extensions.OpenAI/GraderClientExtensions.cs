using LightResults.Extensions.ExceptionHandling;
using OpenAI.Graders;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides missing Try wrappers for <see cref="GraderClient"/> methods in OpenAI 2.11.0.
/// </summary>
public static class GraderClientExtensions
{
    /// <summary>
    /// Attempts to execute <c>RunGrader</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The GraderClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>RunGrader</c>.</param>
    /// <param name="options">Parameter forwarded to <c>RunGrader</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryRunGrader(
        this GraderClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            RequestOptions?,
            ClientResult> func = client.RunGrader;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>RunGraderAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The GraderClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>RunGraderAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>RunGraderAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryRunGraderAsync(
        this GraderClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            RequestOptions?,
            Task<ClientResult>> func = client.RunGraderAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>ValidateGrader</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The GraderClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>ValidateGrader</c>.</param>
    /// <param name="options">Parameter forwarded to <c>ValidateGrader</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryValidateGrader(
        this GraderClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            RequestOptions?,
            ClientResult> func = client.ValidateGrader;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>ValidateGraderAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The GraderClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>ValidateGraderAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>ValidateGraderAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryValidateGraderAsync(
        this GraderClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            RequestOptions?,
            Task<ClientResult>> func = client.ValidateGraderAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }
}
