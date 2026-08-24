using LightResults.Extensions.ExceptionHandling;
using OpenAI.Models;
using System.ClientModel;
using System.ClientModel.Primitives;
// ReSharper disable InconsistentNaming

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides Try wrappers for <see cref="OpenAIModelClient"/> methods in OpenAI 2.13.0.
/// </summary>
public static class OpenAIModelClientExtensions
{
    /// <summary>
    /// Attempts to execute <c>DeleteModel</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIModelClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>DeleteModel</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>DeleteModel</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<ModelDeletionResult> TryDeleteModel(
        this OpenAIModelClient client,
        string model,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            CancellationToken,
            ClientResult<ModelDeletionResult>> func = client.DeleteModel;

        var funcResult = func.Try(model, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ModelDeletionResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteModel</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIModelClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>DeleteModel</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DeleteModel</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<ClientResult> TryDeleteModel(
        this OpenAIModelClient client,
        string model,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions,
            ClientResult> func = client.DeleteModel;

        var funcResult = func.Try(model, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteModelAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIModelClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>DeleteModelAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>DeleteModelAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static async Task<Result<ModelDeletionResult>> TryDeleteModelAsync(
        this OpenAIModelClient client,
        string model,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            CancellationToken,
            Task<ClientResult<ModelDeletionResult>>> func = client.DeleteModelAsync;

        var funcResult = await func.TryAsync(model, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<ModelDeletionResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteModelAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIModelClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>DeleteModelAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DeleteModelAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static async Task<Result<ClientResult>> TryDeleteModelAsync(
        this OpenAIModelClient client,
        string model,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions,
            Task<ClientResult>> func = client.DeleteModelAsync;

        var funcResult = await func.TryAsync(model, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetModel</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIModelClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>GetModel</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetModel</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<OpenAIModel> TryGetModel(
        this OpenAIModelClient client,
        string model,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            CancellationToken,
            ClientResult<OpenAIModel>> func = client.GetModel;

        var funcResult = func.Try(model, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIModel>();
    }

    /// <summary>
    /// Attempts to execute <c>GetModel</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIModelClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>GetModel</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetModel</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<ClientResult> TryGetModel(
        this OpenAIModelClient client,
        string model,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions,
            ClientResult> func = client.GetModel;

        var funcResult = func.Try(model, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetModelAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIModelClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>GetModelAsync</c>.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetModelAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static async Task<Result<OpenAIModel>> TryGetModelAsync(
        this OpenAIModelClient client,
        string model,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            CancellationToken,
            Task<ClientResult<OpenAIModel>>> func = client.GetModelAsync;

        var funcResult = await func.TryAsync(model, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIModel>();
    }

    /// <summary>
    /// Attempts to execute <c>GetModelAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIModelClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>GetModelAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetModelAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static async Task<Result<ClientResult>> TryGetModelAsync(
        this OpenAIModelClient client,
        string model,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions,
            Task<ClientResult>> func = client.GetModelAsync;

        var funcResult = await func.TryAsync(model, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetModels</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIModelClient instance.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetModels</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<OpenAIModelCollection> TryGetModels(
        this OpenAIModelClient client,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            CancellationToken,
            ClientResult<OpenAIModelCollection>> func = client.GetModels;

        var funcResult = func.Try(cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIModelCollection>();
    }

    /// <summary>
    /// Attempts to execute <c>GetModels</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIModelClient instance.</param>
    /// <param name="options">Parameter forwarded to <c>GetModels</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<ClientResult> TryGetModels(
        this OpenAIModelClient client,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            RequestOptions,
            ClientResult> func = client.GetModels;

        var funcResult = func.Try(options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetModelsAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIModelClient instance.</param>
    /// <param name="cancellationToken">Parameter forwarded to <c>GetModelsAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static async Task<Result<OpenAIModelCollection>> TryGetModelsAsync(
        this OpenAIModelClient client,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            CancellationToken,
            Task<ClientResult<OpenAIModelCollection>>> func = client.GetModelsAsync;

        var funcResult = await func.TryAsync(cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIModelCollection>();
    }

    /// <summary>
    /// Attempts to execute <c>GetModelsAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIModelClient instance.</param>
    /// <param name="options">Parameter forwarded to <c>GetModelsAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static async Task<Result<ClientResult>> TryGetModelsAsync(
        this OpenAIModelClient client,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            RequestOptions,
            Task<ClientResult>> func = client.GetModelsAsync;

        var funcResult = await func.TryAsync(options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }
}
