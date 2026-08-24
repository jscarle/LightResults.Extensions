using LightResults.Extensions.ExceptionHandling;
using OpenAI.Skills;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides Try wrappers for <see cref="SkillClient"/> methods in OpenAI 2.13.0.
/// </summary>
public static class SkillClientExtensions
{
    /// <summary>
    /// Attempts to execute <c>DeleteSkill</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>DeleteSkill</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DeleteSkill</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDeleteSkill(this SkillClient client, string skillId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, ClientResult> func = client.DeleteSkill;

        var funcResult = func.Try(skillId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteSkillAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>DeleteSkillAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DeleteSkillAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDeleteSkillAsync(this SkillClient client, string skillId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, Task<ClientResult>> func = client.DeleteSkillAsync;

        var funcResult = await func.TryAsync(skillId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteSkillVersion</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>DeleteSkillVersion</c>.</param>
    /// <param name="version">Parameter forwarded to <c>DeleteSkillVersion</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DeleteSkillVersion</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDeleteSkillVersion(this SkillClient client, string skillId, string version, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, ClientResult> func = client.DeleteSkillVersion;

        var funcResult = func.Try(skillId, version, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DeleteSkillVersionAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>DeleteSkillVersionAsync</c>.</param>
    /// <param name="version">Parameter forwarded to <c>DeleteSkillVersionAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DeleteSkillVersionAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDeleteSkillVersionAsync(
        this SkillClient client,
        string skillId,
        string version,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, Task<ClientResult>> func = client.DeleteSkillVersionAsync;

        var funcResult = await func.TryAsync(skillId, version, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DownloadSkill</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>DownloadSkill</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DownloadSkill</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDownloadSkill(this SkillClient client, string skillId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, ClientResult> func = client.DownloadSkill;

        var funcResult = func.Try(skillId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DownloadSkillAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>DownloadSkillAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DownloadSkillAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDownloadSkillAsync(this SkillClient client, string skillId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, Task<ClientResult>> func = client.DownloadSkillAsync;

        var funcResult = await func.TryAsync(skillId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DownloadSkillVersion</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>DownloadSkillVersion</c>.</param>
    /// <param name="version">Parameter forwarded to <c>DownloadSkillVersion</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DownloadSkillVersion</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDownloadSkillVersion(this SkillClient client, string skillId, string version, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, ClientResult> func = client.DownloadSkillVersion;

        var funcResult = func.Try(skillId, version, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>DownloadSkillVersionAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>DownloadSkillVersionAsync</c>.</param>
    /// <param name="version">Parameter forwarded to <c>DownloadSkillVersionAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>DownloadSkillVersionAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDownloadSkillVersionAsync(
        this SkillClient client,
        string skillId,
        string version,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, Task<ClientResult>> func = client.DownloadSkillVersionAsync;

        var funcResult = await func.TryAsync(skillId, version, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetSkill</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>GetSkill</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetSkill</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetSkill(this SkillClient client, string skillId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, ClientResult> func = client.GetSkill;

        var funcResult = func.Try(skillId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetSkillAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>GetSkillAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetSkillAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetSkillAsync(this SkillClient client, string skillId, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions, Task<ClientResult>> func = client.GetSkillAsync;

        var funcResult = await func.TryAsync(skillId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetSkills</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="limit">Parameter forwarded to <c>GetSkills</c>.</param>
    /// <param name="order">Parameter forwarded to <c>GetSkills</c>.</param>
    /// <param name="after">Parameter forwarded to <c>GetSkills</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetSkills</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetSkills(this SkillClient client, int? limit, string order, string after, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<int?, string, string, RequestOptions, ClientResult> func = client.GetSkills;

        var funcResult = func.Try(limit, order, after, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetSkillsAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="limit">Parameter forwarded to <c>GetSkillsAsync</c>.</param>
    /// <param name="order">Parameter forwarded to <c>GetSkillsAsync</c>.</param>
    /// <param name="after">Parameter forwarded to <c>GetSkillsAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetSkillsAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetSkillsAsync(
        this SkillClient client,
        int? limit,
        string order,
        string after,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<int?, string, string, RequestOptions, Task<ClientResult>> func = client.GetSkillsAsync;

        var funcResult = await func.TryAsync(limit, order, after, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetSkillVersion</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>GetSkillVersion</c>.</param>
    /// <param name="version">Parameter forwarded to <c>GetSkillVersion</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetSkillVersion</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetSkillVersion(this SkillClient client, string skillId, string version, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, ClientResult> func = client.GetSkillVersion;

        var funcResult = func.Try(skillId, version, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetSkillVersionAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>GetSkillVersionAsync</c>.</param>
    /// <param name="version">Parameter forwarded to <c>GetSkillVersionAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetSkillVersionAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetSkillVersionAsync(
        this SkillClient client,
        string skillId,
        string version,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, RequestOptions, Task<ClientResult>> func = client.GetSkillVersionAsync;

        var funcResult = await func.TryAsync(skillId, version, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetSkillVersions</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>GetSkillVersions</c>.</param>
    /// <param name="limit">Parameter forwarded to <c>GetSkillVersions</c>.</param>
    /// <param name="order">Parameter forwarded to <c>GetSkillVersions</c>.</param>
    /// <param name="after">Parameter forwarded to <c>GetSkillVersions</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetSkillVersions</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetSkillVersions(
        this SkillClient client,
        string skillId,
        int? limit,
        string order,
        string after,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string, string, RequestOptions, ClientResult> func = client.GetSkillVersions;

        var funcResult = func.Try(skillId, limit, order, after, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetSkillVersionsAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>GetSkillVersionsAsync</c>.</param>
    /// <param name="limit">Parameter forwarded to <c>GetSkillVersionsAsync</c>.</param>
    /// <param name="order">Parameter forwarded to <c>GetSkillVersionsAsync</c>.</param>
    /// <param name="after">Parameter forwarded to <c>GetSkillVersionsAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetSkillVersionsAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetSkillVersionsAsync(
        this SkillClient client,
        string skillId,
        int? limit,
        string order,
        string after,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int?, string, string, RequestOptions, Task<ClientResult>> func = client.GetSkillVersionsAsync;

        var funcResult = await func.TryAsync(skillId, limit, order, after, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>UpdateSkill</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>UpdateSkill</c>.</param>
    /// <param name="content">Parameter forwarded to <c>UpdateSkill</c>.</param>
    /// <param name="contentType">Parameter forwarded to <c>UpdateSkill</c>.</param>
    /// <param name="options">Parameter forwarded to <c>UpdateSkill</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryUpdateSkill(
        this SkillClient client,
        string skillId,
        BinaryContent content,
        string contentType,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, string, RequestOptions, ClientResult> func = client.UpdateSkill;

        var funcResult = func.Try(skillId, content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>UpdateSkillAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>UpdateSkillAsync</c>.</param>
    /// <param name="content">Parameter forwarded to <c>UpdateSkillAsync</c>.</param>
    /// <param name="contentType">Parameter forwarded to <c>UpdateSkillAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>UpdateSkillAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryUpdateSkillAsync(
        this SkillClient client,
        string skillId,
        BinaryContent content,
        string contentType,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, string, RequestOptions, Task<ClientResult>> func = client.UpdateSkillAsync;

        var funcResult = await func.TryAsync(skillId, content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>UploadSkill</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>UploadSkill</c>.</param>
    /// <param name="contentType">Parameter forwarded to <c>UploadSkill</c>.</param>
    /// <param name="options">Parameter forwarded to <c>UploadSkill</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryUploadSkill(this SkillClient client, BinaryContent content, string contentType, RequestOptions options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions, ClientResult> func = client.UploadSkill;

        var funcResult = func.Try(content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>UploadSkillAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="content">Parameter forwarded to <c>UploadSkillAsync</c>.</param>
    /// <param name="contentType">Parameter forwarded to <c>UploadSkillAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>UploadSkillAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryUploadSkillAsync(
        this SkillClient client,
        BinaryContent content,
        string contentType,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions, Task<ClientResult>> func = client.UploadSkillAsync;

        var funcResult = await func.TryAsync(content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>UploadSkillVersion</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>UploadSkillVersion</c>.</param>
    /// <param name="content">Parameter forwarded to <c>UploadSkillVersion</c>.</param>
    /// <param name="contentType">Parameter forwarded to <c>UploadSkillVersion</c>.</param>
    /// <param name="options">Parameter forwarded to <c>UploadSkillVersion</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryUploadSkillVersion(
        this SkillClient client,
        string skillId,
        BinaryContent content,
        string contentType,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, string, RequestOptions, ClientResult> func = client.UploadSkillVersion;

        var funcResult = func.Try(skillId, content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>UploadSkillVersionAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The SkillClient instance.</param>
    /// <param name="skillId">Parameter forwarded to <c>UploadSkillVersionAsync</c>.</param>
    /// <param name="content">Parameter forwarded to <c>UploadSkillVersionAsync</c>.</param>
    /// <param name="contentType">Parameter forwarded to <c>UploadSkillVersionAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>UploadSkillVersionAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryUploadSkillVersionAsync(
        this SkillClient client,
        string skillId,
        BinaryContent content,
        string contentType,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, string, RequestOptions, Task<ClientResult>> func = client.UploadSkillVersionAsync;

        var funcResult = await func.TryAsync(skillId, content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }
}
