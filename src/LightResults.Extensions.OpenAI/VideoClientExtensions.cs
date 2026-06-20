using LightResults.Extensions.ExceptionHandling;
using OpenAI.Videos;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides missing Try wrappers for <see cref="VideoClient"/> methods in OpenAI 2.11.0.
/// </summary>
public static class VideoClientExtensions
{
    /// <summary>
    /// Attempts to execute <c>CreateVideo</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VideoClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>CreateVideo</c>.</param>
    /// <param name="contentType">Parameter forwarded to <c>CreateVideo</c>.</param>
    /// <param name="options">Parameter forwarded to <c>CreateVideo</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCreateVideo(
        this VideoClient client,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            string,
            RequestOptions?,
            ClientResult> func = client.CreateVideo;

        var funcResult = func.Try(content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>CreateVideoAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VideoClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>CreateVideoAsync</c>.</param>
    /// <param name="contentType">Parameter forwarded to <c>CreateVideoAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>CreateVideoAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCreateVideoAsync(
        this VideoClient client,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            BinaryContent,
            string,
            RequestOptions?,
            Task<ClientResult>> func = client.CreateVideoAsync;

        var funcResult = await func.TryAsync(content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>CreateVideoRemix</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VideoClient instance.</param>
    /// <param name="videoId">Parameter forwarded to <c>CreateVideoRemix</c>.</param>
    /// <param name="content">Parameter forwarded to <c>CreateVideoRemix</c>.</param>
    /// <param name="contentType">Parameter forwarded to <c>CreateVideoRemix</c>.</param>
    /// <param name="options">Parameter forwarded to <c>CreateVideoRemix</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCreateVideoRemix(
        this VideoClient client,
        string videoId,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            BinaryContent,
            string,
            RequestOptions?,
            ClientResult> func = client.CreateVideoRemix;

        var funcResult = func.Try(videoId, content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>CreateVideoRemixAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VideoClient instance.</param>
    /// <param name="videoId">Parameter forwarded to <c>CreateVideoRemixAsync</c>.</param>
    /// <param name="content">Parameter forwarded to <c>CreateVideoRemixAsync</c>.</param>
    /// <param name="contentType">Parameter forwarded to <c>CreateVideoRemixAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>CreateVideoRemixAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCreateVideoRemixAsync(
        this VideoClient client,
        string videoId,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            BinaryContent,
            string,
            RequestOptions?,
            Task<ClientResult>> func = client.CreateVideoRemixAsync;

        var funcResult = await func.TryAsync(videoId, content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteVideo</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VideoClient instance.</param>
    /// <param name="videoId">Parameter forwarded to <c>DeleteVideo</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DeleteVideo</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDeleteVideo(
        this VideoClient client,
        string videoId,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions?,
            ClientResult> func = client.DeleteVideo;

        var funcResult = func.Try(videoId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteVideoAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VideoClient instance.</param>
    /// <param name="videoId">Parameter forwarded to <c>DeleteVideoAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DeleteVideoAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDeleteVideoAsync(
        this VideoClient client,
        string videoId,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions?,
            Task<ClientResult>> func = client.DeleteVideoAsync;

        var funcResult = await func.TryAsync(videoId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DownloadVideo</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VideoClient instance.</param>
    /// <param name="videoId">Parameter forwarded to <c>DownloadVideo</c>.</param>
    /// <param name="variant">Parameter forwarded to <c>DownloadVideo</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DownloadVideo</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDownloadVideo(
        this VideoClient client,
        string videoId,
        string? variant = null,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string?,
            RequestOptions?,
            ClientResult> func = client.DownloadVideo;

        var funcResult = func.Try(videoId, variant, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DownloadVideoAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VideoClient instance.</param>
    /// <param name="videoId">Parameter forwarded to <c>DownloadVideoAsync</c>.</param>
    /// <param name="variant">Parameter forwarded to <c>DownloadVideoAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DownloadVideoAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDownloadVideoAsync(
        this VideoClient client,
        string videoId,
        string? variant = null,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            string?,
            RequestOptions?,
            Task<ClientResult>> func = client.DownloadVideoAsync;

        var funcResult = await func.TryAsync(videoId, variant, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVideo</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VideoClient instance.</param>
    /// <param name="videoId">Parameter forwarded to <c>GetVideo</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVideo</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetVideo(
        this VideoClient client,
        string videoId,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions?,
            ClientResult> func = client.GetVideo;

        var funcResult = func.Try(videoId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVideoAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VideoClient instance.</param>
    /// <param name="videoId">Parameter forwarded to <c>GetVideoAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVideoAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetVideoAsync(
        this VideoClient client,
        string videoId,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            RequestOptions?,
            Task<ClientResult>> func = client.GetVideoAsync;

        var funcResult = await func.TryAsync(videoId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVideos</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VideoClient instance.</param>
    /// <param name="limit">Parameter forwarded to <c>GetVideos</c>.</param>
    /// <param name="order">Parameter forwarded to <c>GetVideos</c>.</param>
    /// <param name="after">Parameter forwarded to <c>GetVideos</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVideos</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<CollectionResult> TryGetVideos(
        this VideoClient client,
        int? limit = null,
        string? order = null,
        string? after = null,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            int?,
            string?,
            string?,
            RequestOptions?,
            CollectionResult> func = client.GetVideos;

        var funcResult = func.Try(limit, order, after, options);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVideosAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The VideoClient instance.</param>
    /// <param name="limit">Parameter forwarded to <c>GetVideosAsync</c>.</param>
    /// <param name="order">Parameter forwarded to <c>GetVideosAsync</c>.</param>
    /// <param name="after">Parameter forwarded to <c>GetVideosAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetVideosAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<AsyncCollectionResult> TryGetVideosAsync(
        this VideoClient client,
        int? limit = null,
        string? order = null,
        string? after = null,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            int?,
            string?,
            string?,
            RequestOptions?,
            AsyncCollectionResult> func = client.GetVideosAsync;

        var funcResult = func.Try(limit, order, after, options);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }
}
