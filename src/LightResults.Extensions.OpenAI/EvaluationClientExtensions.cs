using System.ClientModel;
using System.ClientModel.Primitives;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.Evals;
using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides extension methods for <see cref="EvaluationClient"/> that integrate the <see cref="Result"/> pattern, enabling safe and expressive error
/// handling for OpenAI evaluation operations. These methods wrap both synchronous and asynchronous evaluation requests in <see cref="Result{T}"/> types, making it
/// easy to handle errors and successful responses without exceptions.
/// </summary>
public static class EvaluationClientExtensions
{
    /// <summary>Attempts to retrieve evaluations synchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="limit">The optional limit.</param>
    /// <param name="orderBy">The field to order by.</param>
    /// <param name="order">The order direction.</param>
    /// <param name="after">The pagination cursor.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetEvaluations(
        this EvaluationClient client,
        int? limit,
        string orderBy,
        string order,
        string after,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<int?, string, string, string, RequestOptions, ClientResult> func = client.GetEvaluations;

        var funcResult = func.Try(limit, orderBy, order, after, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve evaluations asynchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="limit">The optional limit.</param>
    /// <param name="orderBy">The field to order by.</param>
    /// <param name="order">The order direction.</param>
    /// <param name="after">The pagination cursor.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetEvaluationsAsync(
        this EvaluationClient client,
        int? limit,
        string orderBy,
        string order,
        string after,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<int?, string, string, string, RequestOptions, Task<ClientResult>> func = client.GetEvaluationsAsync;

        var funcResult = await func.TryAsync(limit, orderBy, order, after, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to create an evaluation synchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="content">The evaluation binary content.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCreateEvaluation(this EvaluationClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, ClientResult> func = client.CreateEvaluation;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to create an evaluation asynchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="content">The evaluation binary content.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCreateEvaluationAsync(this EvaluationClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CreateEvaluationAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve a specific evaluation synchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetEvaluation(this EvaluationClient client, string evaluationId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, ClientResult> func = client.GetEvaluation;

        var funcResult = func.Try(evaluationId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve a specific evaluation asynchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetEvaluationAsync(this EvaluationClient client, string evaluationId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, Task<ClientResult>> func = client.GetEvaluationAsync;

        var funcResult = await func.TryAsync(evaluationId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to update a specific evaluation synchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="content">The evaluation binary content.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryUpdateEvaluation(
        this EvaluationClient client,
        string evaluationId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, ClientResult> func = client.UpdateEvaluation;

        var funcResult = func.Try(evaluationId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to update a specific evaluation asynchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="content">The evaluation binary content.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryUpdateEvaluationAsync(
        this EvaluationClient client,
        string evaluationId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.UpdateEvaluationAsync;

        var funcResult = await func.TryAsync(evaluationId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to delete a specific evaluation synchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDeleteEvaluation(this EvaluationClient client, string evaluationId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, ClientResult> func = client.DeleteEvaluation;

        var funcResult = func.Try(evaluationId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to delete a specific evaluation asynchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDeleteEvaluationAsync(this EvaluationClient client, string evaluationId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, Task<ClientResult>> func = client.DeleteEvaluationAsync;

        var funcResult = await func.TryAsync(evaluationId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve evaluation runs synchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="limit">The optional limit.</param>
    /// <param name="order">The order direction.</param>
    /// <param name="after">The pagination cursor.</param>
    /// <param name="evaluationRunStatus">The evaluation run status.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetEvaluationRuns(
        this EvaluationClient client,
        string evaluationId,
        int? limit,
        string order,
        string after,
        string evaluationRunStatus,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string, string, string, RequestOptions, ClientResult> func = client.GetEvaluationRuns;

        var funcResult = func.Try(evaluationId, limit, order, after, evaluationRunStatus, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve evaluation runs asynchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="limit">The optional limit.</param>
    /// <param name="order">The order direction.</param>
    /// <param name="after">The pagination cursor.</param>
    /// <param name="evaluationRunStatus">The evaluation run status.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetEvaluationRunsAsync(
        this EvaluationClient client,
        string evaluationId,
        int? limit,
        string order,
        string after,
        string evaluationRunStatus,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string, string, string, RequestOptions, Task<ClientResult>> func = client.GetEvaluationRunsAsync;

        var funcResult = await func.TryAsync(evaluationId, limit, order, after, evaluationRunStatus, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to create an evaluation run synchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="content">The evaluation run binary content.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCreateEvaluationRun(
        this EvaluationClient client,
        string evaluationId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, ClientResult> func = client.CreateEvaluationRun;

        var funcResult = func.Try(evaluationId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to create an evaluation run asynchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="content">The evaluation run binary content.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCreateEvaluationRunAsync(
        this EvaluationClient client,
        string evaluationId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CreateEvaluationRunAsync;

        var funcResult = await func.TryAsync(evaluationId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve a specific evaluation run synchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="evaluationRunId">The evaluation run ID.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetEvaluationRun(this EvaluationClient client, string evaluationId, string evaluationRunId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, ClientResult> func = client.GetEvaluationRun;

        var funcResult = func.Try(evaluationId, evaluationRunId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve a specific evaluation run asynchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="evaluationRunId">The evaluation run ID.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetEvaluationRunAsync(
        this EvaluationClient client,
        string evaluationId,
        string evaluationRunId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, Task<ClientResult>> func = client.GetEvaluationRunAsync;

        var funcResult = await func.TryAsync(evaluationId, evaluationRunId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to cancel a specific evaluation run synchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="evaluationRunId">The evaluation run ID.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCancelEvaluationRun(this EvaluationClient client, string evaluationId, string evaluationRunId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, ClientResult> func = client.CancelEvaluationRun;

        var funcResult = func.Try(evaluationId, evaluationRunId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to cancel a specific evaluation run asynchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="evaluationRunId">The evaluation run ID.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCancelEvaluationRunAsync(
        this EvaluationClient client,
        string evaluationId,
        string evaluationRunId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, Task<ClientResult>> func = client.CancelEvaluationRunAsync;

        var funcResult = await func.TryAsync(evaluationId, evaluationRunId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to delete a specific evaluation run synchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="evaluationRunId">The evaluation run ID.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDeleteEvaluationRun(this EvaluationClient client, string evaluationId, string evaluationRunId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, ClientResult> func = client.DeleteEvaluationRun;

        var funcResult = func.Try(evaluationId, evaluationRunId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to delete a specific evaluation run asynchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="evaluationRunId">The evaluation run ID.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDeleteEvaluationRunAsync(
        this EvaluationClient client,
        string evaluationId,
        string evaluationRunId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, Task<ClientResult>> func = client.DeleteEvaluationRunAsync;

        var funcResult = await func.TryAsync(evaluationId, evaluationRunId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve evaluation run output items synchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="evaluationRunId">The evaluation run ID.</param>
    /// <param name="limit">The optional limit.</param>
    /// <param name="order">The order direction.</param>
    /// <param name="after">The pagination cursor.</param>
    /// <param name="outputItemStatus">The output item status.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetEvaluationRunOutputItems(
        this EvaluationClient client,
        string evaluationId,
        string evaluationRunId,
        int? limit,
        string order,
        string after,
        string outputItemStatus,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, int?, string, string, string, RequestOptions, ClientResult> func = client.GetEvaluationRunOutputItems;

        var funcResult = func.Try(evaluationId, evaluationRunId, limit, order, after, outputItemStatus, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve evaluation run output items asynchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="evaluationRunId">The evaluation run ID.</param>
    /// <param name="limit">The optional limit.</param>
    /// <param name="order">The order direction.</param>
    /// <param name="after">The pagination cursor.</param>
    /// <param name="outputItemStatus">The output item status.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetEvaluationRunOutputItemsAsync(
        this EvaluationClient client,
        string evaluationId,
        string evaluationRunId,
        int? limit,
        string order,
        string after,
        string outputItemStatus,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, int?, string, string, string, RequestOptions, Task<ClientResult>> func = client.GetEvaluationRunOutputItemsAsync;

        var funcResult = await func.TryAsync(evaluationId, evaluationRunId, limit, order, after, outputItemStatus, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve a specific evaluation run output item synchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="evaluationRunId">The evaluation run ID.</param>
    /// <param name="outputItemId">The output item ID.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetEvaluationRunOutputItem(
        this EvaluationClient client,
        string evaluationId,
        string evaluationRunId,
        string outputItemId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, string, RequestOptions, ClientResult> func = client.GetEvaluationRunOutputItem;

        var funcResult = func.Try(evaluationId, evaluationRunId, outputItemId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve a specific evaluation run output item asynchronously and wraps the result in a <see cref="Result{ClientResult}"/>.</summary>
    /// <param name="client">The evaluation client instance.</param>
    /// <param name="evaluationId">The evaluation ID.</param>
    /// <param name="evaluationRunId">The evaluation run ID.</param>
    /// <param name="outputItemId">The output item ID.</param>
    /// <param name="options">Request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetEvaluationRunOutputItemAsync(
        this EvaluationClient client,
        string evaluationId,
        string evaluationRunId,
        string outputItemId,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, string, RequestOptions, Task<ClientResult>> func = client.GetEvaluationRunOutputItemAsync;

        var funcResult = await func.TryAsync(evaluationId, evaluationRunId, outputItemId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }
}
