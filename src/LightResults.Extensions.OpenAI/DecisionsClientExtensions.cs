using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.Decisions;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides Try wrappers for <see cref="DecisionsClient"/> methods in OpenAI 2.15.0.
/// </summary>
public static class DecisionsClientExtensions
{
    /// <summary>Attempts to create a decision with binary content and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The decisions client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCreateDecision(this DecisionsClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, ClientResult> func = client.CreateDecision;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to create a decision with binary content asynchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The decisions client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCreateDecisionAsync(
        this DecisionsClient client,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CreateDecisionAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to create a decision and wraps the result in a <see cref="Result{DecisionResource}"/>.</summary>
    /// <param name="client">The decisions client instance.</param>
    /// <param name="creationOptions">The decision creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{DecisionResource}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<DecisionResource> TryCreateDecision(
        this DecisionsClient client,
        DecisionCreationOptions creationOptions,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<DecisionCreationOptions, CancellationToken, ClientResult<DecisionResource>> func = client.CreateDecision;

        var funcResult = func.Try(creationOptions, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<DecisionResource>();
    }

    /// <summary>Attempts to create a decision asynchronously and wraps the result in a <see cref="Result{DecisionResource}"/>.</summary>
    /// <param name="client">The decisions client instance.</param>
    /// <param name="creationOptions">The decision creation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{DecisionResource}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<DecisionResource>> TryCreateDecisionAsync(
        this DecisionsClient client,
        DecisionCreationOptions creationOptions,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<DecisionCreationOptions, CancellationToken, Task<ClientResult<DecisionResource>>> func = client.CreateDecisionAsync;

        var funcResult = await func.TryAsync(creationOptions, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<DecisionResource>();
    }
}
