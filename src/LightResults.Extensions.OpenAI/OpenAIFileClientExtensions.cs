using System.ClientModel;
using System.ClientModel.Primitives;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.Files;
using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

// ReSharper disable InconsistentNaming

/// <summary>
/// Provides extension methods for <see cref="OpenAIFileClient"/> that integrate the <see cref="Result"/> pattern, enabling safe and expressive error
/// handling for OpenAI file operations. These methods wrap both synchronous and asynchronous file requests in <see cref="Result{T}"/> types, making it easy to
/// handle errors and successful responses without exceptions.
/// </summary>
public static class OpenAIFileClientExtensions
{
    /// <summary>Attempts to add an upload part and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="uploadId">The upload identifier.</param>
    /// <param name="content">The binary content to upload.</param>
    /// <param name="contentType">The content type of the upload part.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryAddUploadPart(
        this OpenAIFileClient client,
        string uploadId,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, string, RequestOptions?, ClientResult> func = client.AddUploadPart;

        var funcResult = func.Try(uploadId, content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to add an upload part asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="uploadId">The upload identifier.</param>
    /// <param name="content">The binary content to upload.</param>
    /// <param name="contentType">The content type of the upload part.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryAddUploadPartAsync(
        this OpenAIFileClient client,
        string uploadId,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, string, RequestOptions?, Task<ClientResult>> func = client.AddUploadPartAsync;

        var funcResult = await func.TryAsync(uploadId, content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to cancel an upload and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="uploadId">The upload identifier.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCancelUpload(this OpenAIFileClient client, string uploadId, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, ClientResult> func = client.CancelUpload;

        var funcResult = func.Try(uploadId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to cancel an upload asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="uploadId">The upload identifier.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCancelUploadAsync(this OpenAIFileClient client, string uploadId, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, Task<ClientResult>> func = client.CancelUploadAsync;

        var funcResult = await func.TryAsync(uploadId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to complete an upload and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="uploadId">The upload identifier.</param>
    /// <param name="content">The binary content to complete the upload.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCompleteUpload(this OpenAIFileClient client, string uploadId, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, ClientResult> func = client.CompleteUpload;

        var funcResult = func.Try(uploadId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to complete an upload asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="uploadId">The upload identifier.</param>
    /// <param name="content">The binary content to complete the upload.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCompleteUploadAsync(
        this OpenAIFileClient client,
        string uploadId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CompleteUploadAsync;

        var funcResult = await func.TryAsync(uploadId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to create an upload and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="content">The binary content to create the upload.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCreateUpload(this OpenAIFileClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, ClientResult> func = client.CreateUpload;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to create an upload asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="content">The binary content to create the upload.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCreateUploadAsync(this OpenAIFileClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, Task<ClientResult>> func = client.CreateUploadAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to delete a file and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{FileDeletionResult}"/> representing the outcome.</returns>
    public static Result<FileDeletionResult> TryDeleteFile(this OpenAIFileClient client, string fileId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<FileDeletionResult>> func = client.DeleteFile;

        var funcResult = func.Try(fileId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<FileDeletionResult>();
    }

    /// <summary>Attempts to delete a file and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    public static Result<ClientResult> TryDeleteFile(this OpenAIFileClient client, string fileId, RequestOptions? options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, ClientResult> func = client.DeleteFile;

        var funcResult = func.Try(fileId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to delete a file asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{FileDeletionResult}"/>.</returns>
    public static async Task<Result<FileDeletionResult>> TryDeleteFileAsync(
        this OpenAIFileClient client,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<FileDeletionResult>>> func = client.DeleteFileAsync;

        var funcResult = await func.TryAsync(fileId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<FileDeletionResult>();
    }

    /// <summary>Attempts to delete a file asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    public static async Task<Result<ClientResult>> TryDeleteFileAsync(this OpenAIFileClient client, string fileId, RequestOptions? options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, Task<ClientResult>> func = client.DeleteFileAsync;

        var funcResult = await func.TryAsync(fileId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to download a file and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{BinaryData}"/> representing the outcome.</returns>
    public static Result<BinaryData> TryDownloadFile(this OpenAIFileClient client, string fileId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<BinaryData>> func = client.DownloadFile;

        var funcResult = func.Try(fileId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<BinaryData>();
    }

    /// <summary>Attempts to download a file and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    public static Result<ClientResult> TryDownloadFile(this OpenAIFileClient client, string fileId, RequestOptions? options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, ClientResult> func = client.DownloadFile;

        var funcResult = func.Try(fileId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to download a file asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{BinaryData}"/>.</returns>
    public static async Task<Result<BinaryData>> TryDownloadFileAsync(
        this OpenAIFileClient client,
        string fileId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<BinaryData>>> func = client.DownloadFileAsync;

        var funcResult = await func.TryAsync(fileId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<BinaryData>();
    }

    /// <summary>Attempts to download a file asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    public static async Task<Result<ClientResult>> TryDownloadFileAsync(this OpenAIFileClient client, string fileId, RequestOptions? options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, Task<ClientResult>> func = client.DownloadFileAsync;

        var funcResult = await func.TryAsync(fileId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to get a file and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{OpenAIFile}"/> representing the outcome.</returns>
    public static Result<OpenAIFile> TryGetFile(this OpenAIFileClient client, string fileId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, ClientResult<OpenAIFile>> func = client.GetFile;

        var funcResult = func.Try(fileId, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIFile>();
    }

    /// <summary>Attempts to get a file and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    public static Result<ClientResult> TryGetFile(this OpenAIFileClient client, string fileId, RequestOptions? options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, ClientResult> func = client.GetFile;

        var funcResult = func.Try(fileId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to get a file asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{OpenAIFile}"/>.</returns>
    public static async Task<Result<OpenAIFile>> TryGetFileAsync(this OpenAIFileClient client, string fileId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, CancellationToken, Task<ClientResult<OpenAIFile>>> func = client.GetFileAsync;

        var funcResult = await func.TryAsync(fileId, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIFile>();
    }

    /// <summary>Attempts to get a file asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="fileId">The file identifier.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    public static async Task<Result<ClientResult>> TryGetFileAsync(this OpenAIFileClient client, string fileId, RequestOptions? options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, Task<ClientResult>> func = client.GetFileAsync;

        var funcResult = await func.TryAsync(fileId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to get files and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{OpenAIFileCollection}"/> representing the outcome.</returns>
    public static Result<OpenAIFileCollection> TryGetFiles(this OpenAIFileClient client, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<CancellationToken, ClientResult<OpenAIFileCollection>> func = client.GetFiles;

        var funcResult = func.Try(cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIFileCollection>();
    }

    /// <summary>Attempts to get files by purpose and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="purpose">The file purpose filter.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{OpenAIFileCollection}"/> representing the outcome.</returns>
    public static Result<OpenAIFileCollection> TryGetFiles(this OpenAIFileClient client, FilePurpose purpose, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<FilePurpose, CancellationToken, ClientResult<OpenAIFileCollection>> func = client.GetFiles;

        var funcResult = func.Try(purpose, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIFileCollection>();
    }

    /// <summary>Attempts to get files by purpose and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="purpose">The file purpose filter as string.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    public static Result<ClientResult> TryGetFiles(this OpenAIFileClient client, string purpose, RequestOptions? options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, ClientResult> func = client.GetFiles;

        var funcResult = func.Try(purpose, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to get files asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{OpenAIFileCollection}"/>.</returns>
    public static async Task<Result<OpenAIFileCollection>> TryGetFilesAsync(this OpenAIFileClient client, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<CancellationToken, Task<ClientResult<OpenAIFileCollection>>> func = client.GetFilesAsync;

        var funcResult = await func.TryAsync(cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIFileCollection>();
    }

    /// <summary>Attempts to get files by purpose asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="purpose">The file purpose filter.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{OpenAIFileCollection}"/>.</returns>
    public static async Task<Result<OpenAIFileCollection>> TryGetFilesAsync(
        this OpenAIFileClient client,
        FilePurpose purpose,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<FilePurpose, CancellationToken, Task<ClientResult<OpenAIFileCollection>>> func = client.GetFilesAsync;

        var funcResult = await func.TryAsync(purpose, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIFileCollection>();
    }

    /// <summary>Attempts to get files by purpose asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="purpose">The file purpose filter as string.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    public static async Task<Result<ClientResult>> TryGetFilesAsync(this OpenAIFileClient client, string purpose, RequestOptions? options)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, Task<ClientResult>> func = client.GetFilesAsync;

        var funcResult = await func.TryAsync(purpose, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to upload a file from stream and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="file">The file stream to upload.</param>
    /// <param name="filename">The filename for the upload.</param>
    /// <param name="purpose">The purpose of the file upload.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{OpenAIFile}"/> representing the outcome.</returns>
    public static Result<OpenAIFile> TryUploadFile(
        this OpenAIFileClient client,
        Stream file,
        string filename,
        FileUploadPurpose purpose,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, FileUploadPurpose, CancellationToken, ClientResult<OpenAIFile>> func = client.UploadFile;

        var funcResult = func.Try(file, filename, purpose, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIFile>();
    }

    /// <summary>Attempts to upload a file from binary data and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="file">The binary data to upload.</param>
    /// <param name="filename">The filename for the upload.</param>
    /// <param name="purpose">The purpose of the file upload.</param>
    /// <returns>A <see cref="Result{OpenAIFile}"/> representing the outcome.</returns>
    public static Result<OpenAIFile> TryUploadFile(this OpenAIFileClient client, BinaryData file, string filename, FileUploadPurpose purpose)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryData, string, FileUploadPurpose, ClientResult<OpenAIFile>> func = client.UploadFile;

        var funcResult = func.Try(file, filename, purpose);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIFile>();
    }

    /// <summary>Attempts to upload a file from file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="filePath">The path to the file to upload.</param>
    /// <param name="purpose">The purpose of the file upload.</param>
    /// <returns>A <see cref="Result{OpenAIFile}"/> representing the outcome.</returns>
    public static Result<OpenAIFile> TryUploadFile(this OpenAIFileClient client, string filePath, FileUploadPurpose purpose)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, FileUploadPurpose, ClientResult<OpenAIFile>> func = client.UploadFile;

        var funcResult = func.Try(filePath, purpose);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIFile>();
    }

    /// <summary>Attempts to upload a file with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="content">The binary content to upload.</param>
    /// <param name="contentType">The content type of the file.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    public static Result<ClientResult> TryUploadFile(this OpenAIFileClient client, BinaryContent content, string contentType, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions?, ClientResult> func = client.UploadFile;

        var funcResult = func.Try(content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to upload a file from stream asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="file">The file stream to upload.</param>
    /// <param name="filename">The filename for the upload.</param>
    /// <param name="purpose">The purpose of the file upload.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{OpenAIFile}"/>.</returns>
    public static async Task<Result<OpenAIFile>> TryUploadFileAsync(
        this OpenAIFileClient client,
        Stream file,
        string filename,
        FileUploadPurpose purpose,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, FileUploadPurpose, CancellationToken, Task<ClientResult<OpenAIFile>>> func = client.UploadFileAsync;

        var funcResult = await func.TryAsync(file, filename, purpose, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIFile>();
    }

    /// <summary>Attempts to upload a file from binary data asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="file">The binary data to upload.</param>
    /// <param name="filename">The filename for the upload.</param>
    /// <param name="purpose">The purpose of the file upload.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{OpenAIFile}"/>.</returns>
    public static async Task<Result<OpenAIFile>> TryUploadFileAsync(this OpenAIFileClient client, BinaryData file, string filename, FileUploadPurpose purpose)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryData, string, FileUploadPurpose, Task<ClientResult<OpenAIFile>>> func = client.UploadFileAsync;

        var funcResult = await func.TryAsync(file, filename, purpose).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIFile>();
    }

    /// <summary>Attempts to upload a file from file path asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="filePath">The path to the file to upload.</param>
    /// <param name="purpose">The purpose of the file upload.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{OpenAIFile}"/>.</returns>
    public static async Task<Result<OpenAIFile>> TryUploadFileAsync(this OpenAIFileClient client, string filePath, FileUploadPurpose purpose)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, FileUploadPurpose, Task<ClientResult<OpenAIFile>>> func = client.UploadFileAsync;

        var funcResult = await func.TryAsync(filePath, purpose).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIFile>();
    }

    /// <summary>Attempts to upload a file with binary content asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The OpenAI file client instance.</param>
    /// <param name="content">The binary content to upload.</param>
    /// <param name="contentType">The content type of the file.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    public static async Task<Result<ClientResult>> TryUploadFileAsync(
        this OpenAIFileClient client,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions?, Task<ClientResult>> func = client.UploadFileAsync;

        var funcResult = await func.TryAsync(content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

/// <summary>
    /// Attempts to execute <c>GetFiles</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIFileClient instance.</param>
    /// <param name="purpose">Parameter forwarded to <c>GetFiles</c>.</param>
    /// <param name="limit">Parameter forwarded to <c>GetFiles</c>.</param>
    /// <param name="order">Parameter forwarded to <c>GetFiles</c>.</param>
    /// <param name="after">Parameter forwarded to <c>GetFiles</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetFiles</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetFiles(
        this OpenAIFileClient client,
        string purpose,
        int? limit,
        string order,
        string after,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            int?,
            string,
            string,
            RequestOptions,
            ClientResult> func = client.GetFiles;

        var funcResult = func.Try(purpose, limit, order, after, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>
    /// Attempts to execute <c>GetFilesAsync</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIFileClient instance.</param>
    /// <param name="purpose">Parameter forwarded to <c>GetFilesAsync</c>.</param>
    /// <param name="limit">Parameter forwarded to <c>GetFilesAsync</c>.</param>
    /// <param name="order">Parameter forwarded to <c>GetFilesAsync</c>.</param>
    /// <param name="after">Parameter forwarded to <c>GetFilesAsync</c>.</param>
    /// <param name="options">Parameter forwarded to <c>GetFilesAsync</c>.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetFilesAsync(
        this OpenAIFileClient client,
        string purpose,
        int? limit,
        string order,
        string after,
        RequestOptions options
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            int?,
            string,
            string,
            RequestOptions,
            Task<ClientResult>> func = client.GetFilesAsync;

        var funcResult = await func.TryAsync(purpose, limit, order, after, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }
}
