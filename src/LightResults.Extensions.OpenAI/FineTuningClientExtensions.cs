using System.ClientModel;
using System.ClientModel.Primitives;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.FineTuning;

#if NET8_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;

#else
#pragma warning disable OPENAI001
#endif

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides extension methods for <see cref="FineTuningClient"/> that integrate the <see cref="Result"/> pattern, enabling safe and expressive error
/// handling for OpenAI fine-tuning operations. These methods wrap both synchronous and asynchronous fine-tuning requests in <see cref="Result{T}"/> types, making
/// it easy to handle errors and successful responses without exceptions.
/// </summary>
public static class FineTuningClientExtensions
{
    /// <summary>Attempts to fine-tune a model asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="baseModel">The base model to fine-tune.</param>
    /// <param name="trainingFileId">The ID of the training file.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the fine-tuning job is completed.</param>
    /// <param name="options">Optional fine-tuning options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{FineTuningJob}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<FineTuningJob>> TryFineTuneAsync(
        this FineTuningClient client,
        string baseModel,
        string trainingFileId,
        bool waitUntilCompleted,
        FineTuningOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, bool, FineTuningOptions?, CancellationToken, Task<FineTuningJob>> func = client.FineTuneAsync;

        var funcResult = await func.TryAsync(baseModel, trainingFileId, waitUntilCompleted, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<FineTuningJob>();
    }

    /// <summary>Attempts to fine-tune a model synchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="baseModel">The base model to fine-tune.</param>
    /// <param name="trainingFileId">The ID of the training file.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the fine-tuning job is completed.</param>
    /// <param name="options">Optional fine-tuning options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{FineTuningJob}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<FineTuningJob> TryFineTune(
        this FineTuningClient client,
        string baseModel,
        string trainingFileId,
        bool waitUntilCompleted,
        FineTuningOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, bool, FineTuningOptions?, CancellationToken, FineTuningJob> func = client.FineTune;

        var funcResult = func.Try(baseModel, trainingFileId, waitUntilCompleted, options, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<FineTuningJob>();
    }

    /// <summary>Attempts to fine-tune a model asynchronously with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the fine-tuning job is completed.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{FineTuningJob}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<FineTuningJob>> TryFineTuneAsync(
        this FineTuningClient client,
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, bool, RequestOptions?, Task<FineTuningJob>> func = client.FineTuneAsync;

        var funcResult = await func.TryAsync(content, waitUntilCompleted, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<FineTuningJob>();
    }

    /// <summary>Attempts to fine-tune a model synchronously with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="waitUntilCompleted">Whether to wait until the fine-tuning job is completed.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{FineTuningJob}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<FineTuningJob> TryFineTune(
        this FineTuningClient client,
        BinaryContent content,
        bool waitUntilCompleted,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, bool, RequestOptions?, FineTuningJob> func = client.FineTune;

        var funcResult = func.Try(content, waitUntilCompleted, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<FineTuningJob>();
    }

    /// <summary>Attempts to retrieve a fine-tuning job asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="jobId">The ID of the fine-tuning job to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{FineTuningJob}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<FineTuningJob>> TryGetJobAsync(this FineTuningClient client, string jobId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<FineTuningJob>> func = client.GetJobAsync;

        var funcResult = await func.TryAsync(jobId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<FineTuningJob>();
    }

    /// <summary>Attempts to retrieve a fine-tuning job synchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="jobId">The ID of the fine-tuning job to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{FineTuningJob}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<FineTuningJob> TryGetJob(this FineTuningClient client, string jobId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, FineTuningJob> func = client.GetJob;

        var funcResult = func.Try(jobId, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<FineTuningJob>();
    }

    /// <summary>Attempts to retrieve fine-tuning jobs asynchronously and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="options">Fine-tuning job collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{FineTuningJob}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IAsyncEnumerable<Result<FineTuningJob>>> TryGetJobsAsync(
        this FineTuningClient client,
        FineTuningJobCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<FineTuningJobCollectionOptions?, CancellationToken, AsyncCollectionResult<FineTuningJob>> func = client.GetJobsAsync;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<FineTuningJob>>>();
    }

    /// <summary>Attempts to retrieve fine-tuning jobs synchronously and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="options">Fine-tuning job collection options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{FineTuningJob}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<IEnumerable<Result<FineTuningJob>>> TryGetJobs(
        this FineTuningClient client,
        FineTuningJobCollectionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<FineTuningJobCollectionOptions?, CancellationToken, CollectionResult<FineTuningJob>> func = client.GetJobs;

        var funcResult = func.Try(options, cancellationToken);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<FineTuningJob>>>();
    }

    /// <summary>Attempts to create a fine-tuning checkpoint permission asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="fineTunedModelCheckpoint">The fine-tuned model checkpoint identifier.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryCreateFineTuningCheckpointPermissionAsync(
        this FineTuningClient client,
        string fineTunedModelCheckpoint,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CreateFineTuningCheckpointPermissionAsync;

        var funcResult = await func.TryAsync(fineTunedModelCheckpoint, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to create a fine-tuning checkpoint permission synchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="fineTunedModelCheckpoint">The fine-tuned model checkpoint identifier.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryCreateFineTuningCheckpointPermission(
        this FineTuningClient client,
        string fineTunedModelCheckpoint,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, ClientResult> func = client.CreateFineTuningCheckpointPermission;

        var funcResult = func.Try(fineTunedModelCheckpoint, content, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to delete a fine-tuning checkpoint permission asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="fineTunedModelCheckpoint">The fine-tuned model checkpoint identifier.</param>
    /// <param name="permissionId">The permission ID to delete.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryDeleteFineTuningCheckpointPermissionAsync(
        this FineTuningClient client,
        string fineTunedModelCheckpoint,
        string permissionId,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions?, Task<ClientResult>> func = client.DeleteFineTuningCheckpointPermissionAsync;

        var funcResult = await func.TryAsync(fineTunedModelCheckpoint, permissionId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to delete a fine-tuning checkpoint permission synchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="fineTunedModelCheckpoint">The fine-tuned model checkpoint identifier.</param>
    /// <param name="permissionId">The permission ID to delete.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryDeleteFineTuningCheckpointPermission(
        this FineTuningClient client,
        string fineTunedModelCheckpoint,
        string permissionId,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions?, ClientResult> func = client.DeleteFineTuningCheckpointPermission;

        var funcResult = func.Try(fineTunedModelCheckpoint, permissionId, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to get fine-tuning checkpoint permissions asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="fineTunedModelCheckpoint">The fine-tuned model checkpoint identifier.</param>
    /// <param name="after">A cursor for use in pagination.</param>
    /// <param name="limit">A limit on the number of objects to be returned.</param>
    /// <param name="order">Sort order by the created_at timestamp of the objects.</param>
    /// <param name="projectId">The project ID to filter by.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryGetFineTuningCheckpointPermissionsAsync(
        this FineTuningClient client,
        string fineTunedModelCheckpoint,
        string? after = null,
        int? limit = null,
        string? order = null,
        string? projectId = null,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string?, int?, string?, string?, RequestOptions?, Task<ClientResult>> func = client.GetFineTuningCheckpointPermissionsAsync;

        var funcResult = await func.TryAsync(fineTunedModelCheckpoint, after, limit, order, projectId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to get fine-tuning checkpoint permissions synchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="fineTunedModelCheckpoint">The fine-tuned model checkpoint identifier.</param>
    /// <param name="after">A cursor for use in pagination.</param>
    /// <param name="limit">A limit on the number of objects to be returned.</param>
    /// <param name="order">Sort order by the created_at timestamp of the objects.</param>
    /// <param name="projectId">The project ID to filter by.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryGetFineTuningCheckpointPermissions(
        this FineTuningClient client,
        string fineTunedModelCheckpoint,
        string? after = null,
        int? limit = null,
        string? order = null,
        string? projectId = null,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string?, int?, string?, string?, RequestOptions?, ClientResult> func = client.GetFineTuningCheckpointPermissions;

        var funcResult = func.Try(fineTunedModelCheckpoint, after, limit, order, projectId, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to pause a fine-tuning job asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="fineTuningJobId">The ID of the fine-tuning job to pause.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryPauseFineTuningJobAsync(
        this FineTuningClient client,
        string fineTuningJobId,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, Task<ClientResult>> func = client.PauseFineTuningJobAsync;

        var funcResult = await func.TryAsync(fineTuningJobId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to pause a fine-tuning job synchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="fineTuningJobId">The ID of the fine-tuning job to pause.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryPauseFineTuningJob(this FineTuningClient client, string fineTuningJobId, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, ClientResult> func = client.PauseFineTuningJob;

        var funcResult = func.Try(fineTuningJobId, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to resume a fine-tuning job asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="fineTuningJobId">The ID of the fine-tuning job to resume.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static async Task<Result<ClientResult>> TryResumeFineTuningJobAsync(
        this FineTuningClient client,
        string fineTuningJobId,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, Task<ClientResult>> func = client.ResumeFineTuningJobAsync;

        var funcResult = await func.TryAsync(fineTuningJobId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to resume a fine-tuning job synchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The fine-tuning client instance.</param>
    /// <param name="fineTuningJobId">The ID of the fine-tuning job to resume.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
#if NET8_0_OR_GREATER
    [Experimental("OPENAI001")]
#endif
    public static Result<ClientResult> TryResumeFineTuningJob(this FineTuningClient client, string fineTuningJobId, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, ClientResult> func = client.ResumeFineTuningJob;

        var funcResult = func.Try(fineTuningJobId, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result);

        return funcResult.AsFailure<ClientResult>();
    }
}
