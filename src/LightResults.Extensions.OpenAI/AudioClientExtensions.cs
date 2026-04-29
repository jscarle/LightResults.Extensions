using System.ClientModel;
using System.ClientModel.Primitives;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.Audio;

using System.Diagnostics.CodeAnalysis;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides extension methods for <see cref="AudioClient"/> that integrate the <see cref="Result"/> pattern, enabling safe and expressive error handling
/// for OpenAI audio operations. These methods wrap both synchronous and asynchronous audio requests and streaming operations in <see cref="Result{T}"/> types,
/// making it easy to handle errors and successful responses without exceptions.
/// </summary>
public static class AudioClientExtensions
{
    /// <summary>Attempts to generate speech asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="text">The text to generate audio for.</param>
    /// <param name="voice">The voice to use in the generated audio.</param>
    /// <param name="options">Optional generation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{BinaryData}"/>.</returns>
    public static async Task<Result<BinaryData>> TryGenerateSpeechAsync(
        this AudioClient client,
        string text,
        GeneratedSpeechVoice voice,
        SpeechGenerationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, GeneratedSpeechVoice, SpeechGenerationOptions?, CancellationToken, Task<ClientResult<BinaryData>>> func = client.GenerateSpeechAsync;

        var funcResult = await func.TryAsync(text, voice, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<BinaryData>();
    }

    /// <summary>Attempts to generate speech synchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="text">The text to generate audio for.</param>
    /// <param name="voice">The voice to use in the generated audio.</param>
    /// <param name="options">Optional generation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{BinaryData}"/> representing the outcome.</returns>
    public static Result<BinaryData> TryGenerateSpeech(
        this AudioClient client,
        string text,
        GeneratedSpeechVoice voice,
        SpeechGenerationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, GeneratedSpeechVoice, SpeechGenerationOptions?, CancellationToken, ClientResult<BinaryData>> func = client.GenerateSpeech;

        var funcResult = func.Try(text, voice, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<BinaryData>();
    }

    /// <summary>Attempts to generate speech synchronously with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="content">The binary content to generate speech from.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    public static Result<ClientResult> TryGenerateSpeech(this AudioClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, ClientResult> func = client.GenerateSpeech;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to generate speech asynchronously with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="content">The binary content to generate speech from.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    public static async Task<Result<ClientResult>> TryGenerateSpeechAsync(this AudioClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, Task<ClientResult>> func = client.GenerateSpeechAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to transcribe audio asynchronously from a stream and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audio">The audio stream to transcribe.</param>
    /// <param name="audioFilename">The filename associated with the audio stream.</param>
    /// <param name="options">Optional transcription options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AudioTranscription}"/>.</returns>
    public static async Task<Result<AudioTranscription>> TryTranscribeAudioAsync(
        this AudioClient client,
        Stream audio,
        string audioFilename,
        AudioTranscriptionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, AudioTranscriptionOptions?, CancellationToken, Task<ClientResult<AudioTranscription>>> func = client.TranscribeAudioAsync;

        var funcResult = await func.TryAsync(audio, audioFilename, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AudioTranscription>();
    }

    /// <summary>Attempts to transcribe audio synchronously from a stream and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audio">The audio stream to transcribe.</param>
    /// <param name="audioFilename">The filename associated with the audio stream.</param>
    /// <param name="options">Optional transcription options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{AudioTranscription}"/> representing the outcome.</returns>
    public static Result<AudioTranscription> TryTranscribeAudio(
        this AudioClient client,
        Stream audio,
        string audioFilename,
        AudioTranscriptionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, AudioTranscriptionOptions?, CancellationToken, ClientResult<AudioTranscription>> func = client.TranscribeAudio;

        var funcResult = func.Try(audio, audioFilename, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AudioTranscription>();
    }

    /// <summary>Attempts to transcribe audio synchronously with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="content">The binary content to transcribe.</param>
    /// <param name="contentType">The content type of the audio.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    public static Result<ClientResult> TryTranscribeAudio(this AudioClient client, BinaryContent content, string contentType, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions?, ClientResult> func = client.TranscribeAudio;

        var funcResult = func.Try(content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to transcribe audio asynchronously with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="content">The binary content to transcribe.</param>
    /// <param name="contentType">The content type of the audio.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    public static async Task<Result<ClientResult>> TryTranscribeAudioAsync(
        this AudioClient client,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions?, Task<ClientResult>> func = client.TranscribeAudioAsync;

        var funcResult = await func.TryAsync(content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to transcribe audio asynchronously from a file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audioFilePath">The path of the audio file to transcribe.</param>
    /// <param name="options">Optional transcription options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AudioTranscription}"/>.</returns>
    public static async Task<Result<AudioTranscription>> TryTranscribeAudioAsync(
        this AudioClient client,
        string audioFilePath,
        AudioTranscriptionOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, AudioTranscriptionOptions?, Task<ClientResult<AudioTranscription>>> func = client.TranscribeAudioAsync;

        var funcResult = await func.TryAsync(audioFilePath, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AudioTranscription>();
    }

    /// <summary>Attempts to transcribe audio synchronously from a file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audioFilePath">The path of the audio file to transcribe.</param>
    /// <param name="options">Optional transcription options.</param>
    /// <returns>A <see cref="Result{AudioTranscription}"/> representing the outcome.</returns>
    public static Result<AudioTranscription> TryTranscribeAudio(this AudioClient client, string audioFilePath, AudioTranscriptionOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, AudioTranscriptionOptions?, ClientResult<AudioTranscription>> func = client.TranscribeAudio;

        var funcResult = func.Try(audioFilePath, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AudioTranscription>();
    }

    /// <summary>
    /// Attempts to transcribe audio asynchronously with streaming from a stream and wraps the result as an asynchronous enumerable of <see cref="Result{T}"/>
    /// .
    /// </summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audio">The audio stream to transcribe.</param>
    /// <param name="audioFilename">The filename associated with the audio stream.</param>
    /// <param name="options">Optional transcription options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingAudioTranscriptionUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<StreamingAudioTranscriptionUpdate>>> TryTranscribeAudioStreamingAsync(
        this AudioClient client,
        Stream audio,
        string audioFilename,
        AudioTranscriptionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, AudioTranscriptionOptions?, CancellationToken, AsyncCollectionResult<StreamingAudioTranscriptionUpdate>> func =
            client.TranscribeAudioStreamingAsync;

        var funcResult = func.Try(audio, audioFilename, options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingAudioTranscriptionUpdate>>>();
    }

    /// <summary>Attempts to transcribe audio synchronously with streaming from a stream and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audio">The audio stream to transcribe.</param>
    /// <param name="audioFilename">The filename associated with the audio stream.</param>
    /// <param name="options">Optional transcription options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingAudioTranscriptionUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<StreamingAudioTranscriptionUpdate>>> TryTranscribeAudioStreaming(
        this AudioClient client,
        Stream audio,
        string audioFilename,
        AudioTranscriptionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, AudioTranscriptionOptions?, CancellationToken, CollectionResult<StreamingAudioTranscriptionUpdate>> func =
            client.TranscribeAudioStreaming;

        var funcResult = func.Try(audio, audioFilename, options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingAudioTranscriptionUpdate>>>();
    }

    /// <summary>
    /// Attempts to transcribe audio asynchronously with streaming from a file path and wraps the result as an asynchronous enumerable of
    /// <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audioFilePath">The path of the audio file to transcribe.</param>
    /// <param name="options">Optional transcription options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingAudioTranscriptionUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<StreamingAudioTranscriptionUpdate>>> TryTranscribeAudioStreamingAsync(
        this AudioClient client,
        string audioFilePath,
        AudioTranscriptionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, AudioTranscriptionOptions?, CancellationToken, AsyncCollectionResult<StreamingAudioTranscriptionUpdate>> func =
            client.TranscribeAudioStreamingAsync;

        var funcResult = func.Try(audioFilePath, options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingAudioTranscriptionUpdate>>>();
    }

    /// <summary>Attempts to transcribe audio synchronously with streaming from a file path and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audioFilePath">The path of the audio file to transcribe.</param>
    /// <param name="options">Optional transcription options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingAudioTranscriptionUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<StreamingAudioTranscriptionUpdate>>> TryTranscribeAudioStreaming(
        this AudioClient client,
        string audioFilePath,
        AudioTranscriptionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, AudioTranscriptionOptions?, CancellationToken, CollectionResult<StreamingAudioTranscriptionUpdate>> func = client.TranscribeAudioStreaming;

        var funcResult = func.Try(audioFilePath, options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingAudioTranscriptionUpdate>>>();
    }

    /// <summary>Attempts to translate audio asynchronously from a stream and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audio">The audio stream to translate.</param>
    /// <param name="audioFilename">The filename associated with the audio stream.</param>
    /// <param name="options">Optional translation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AudioTranslation}"/>.</returns>
    public static async Task<Result<AudioTranslation>> TryTranslateAudioAsync(
        this AudioClient client,
        Stream audio,
        string audioFilename,
        AudioTranslationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, AudioTranslationOptions?, CancellationToken, Task<ClientResult<AudioTranslation>>> func = client.TranslateAudioAsync;

        var funcResult = await func.TryAsync(audio, audioFilename, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AudioTranslation>();
    }

    /// <summary>Attempts to translate audio synchronously from a stream and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audio">The audio stream to translate.</param>
    /// <param name="audioFilename">The filename associated with the audio stream.</param>
    /// <param name="options">Optional translation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{AudioTranslation}"/> representing the outcome.</returns>
    public static Result<AudioTranslation> TryTranslateAudio(
        this AudioClient client,
        Stream audio,
        string audioFilename,
        AudioTranslationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, AudioTranslationOptions?, CancellationToken, ClientResult<AudioTranslation>> func = client.TranslateAudio;

        var funcResult = func.Try(audio, audioFilename, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AudioTranslation>();
    }

    /// <summary>Attempts to translate audio synchronously with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="content">The binary content to translate.</param>
    /// <param name="contentType">The content type of the audio.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    public static Result<ClientResult> TryTranslateAudio(this AudioClient client, BinaryContent content, string contentType, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions?, ClientResult> func = client.TranslateAudio;

        var funcResult = func.Try(content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to translate audio asynchronously with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="content">The binary content to translate.</param>
    /// <param name="contentType">The content type of the audio.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    public static async Task<Result<ClientResult>> TryTranslateAudioAsync(
        this AudioClient client,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions?, Task<ClientResult>> func = client.TranslateAudioAsync;

        var funcResult = await func.TryAsync(content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to translate audio asynchronously from a file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audioFilePath">The path of the audio file to translate.</param>
    /// <param name="options">Optional translation options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{AudioTranslation}"/>.</returns>
    public static async Task<Result<AudioTranslation>> TryTranslateAudioAsync(
        this AudioClient client,
        string audioFilePath,
        AudioTranslationOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, AudioTranslationOptions?, Task<ClientResult<AudioTranslation>>> func = client.TranslateAudioAsync;

        var funcResult = await func.TryAsync(audioFilePath, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AudioTranslation>();
    }

    /// <summary>Attempts to translate audio synchronously from a file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audioFilePath">The path of the audio file to translate.</param>
    /// <param name="options">Optional translation options.</param>
    /// <returns>A <see cref="Result{AudioTranslation}"/> representing the outcome.</returns>
    public static Result<AudioTranslation> TryTranslateAudio(this AudioClient client, string audioFilePath, AudioTranslationOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, AudioTranslationOptions?, ClientResult<AudioTranslation>> func = client.TranslateAudio;

        var funcResult = func.Try(audioFilePath, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<AudioTranslation>();
    }

    /// <summary>Attempts to create a custom voice and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="contentType">The content type for the request.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCreateVoice(this AudioClient client, BinaryContent content, string contentType, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions?, ClientResult> func = client.CreateVoice;

        var funcResult = func.Try(content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to create a custom voice asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="contentType">The content type for the request.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCreateVoiceAsync(
        this AudioClient client,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions?, Task<ClientResult>> func = client.CreateVoiceAsync;

        var funcResult = await func.TryAsync(content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to create voice consent and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="contentType">The content type for the request.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryCreateVoiceConsent(
        this AudioClient client,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions?, ClientResult> func = client.CreateVoiceConsent;

        var funcResult = func.Try(content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to create voice consent asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="contentType">The content type for the request.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryCreateVoiceConsentAsync(
        this AudioClient client,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions?, Task<ClientResult>> func = client.CreateVoiceConsentAsync;

        var funcResult = await func.TryAsync(content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve voice consent and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="consentId">The voice consent identifier.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryGetVoiceConsent(this AudioClient client, string consentId, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, ClientResult> func = client.GetVoiceConsent;

        var funcResult = func.Try(consentId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve voice consent asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="consentId">The voice consent identifier.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryGetVoiceConsentAsync(this AudioClient client, string consentId, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, Task<ClientResult>> func = client.GetVoiceConsentAsync;

        var funcResult = await func.TryAsync(consentId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to retrieve voice consents and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="after">A pagination cursor for subsequent results.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{CollectionResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<CollectionResult> TryGetVoiceConsents(
        this AudioClient client,
        string? after = null,
        int? limit = null,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string?, int?, RequestOptions?, CollectionResult> func = client.GetVoiceConsents;

        var funcResult = func.Try(after, limit, options);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<CollectionResult>();
    }

    /// <summary>Attempts to retrieve voice consents asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="after">A pagination cursor for subsequent results.</param>
    /// <param name="limit">The maximum number of items to return.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{AsyncCollectionResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<AsyncCollectionResult> TryGetVoiceConsentsAsync(
        this AudioClient client,
        string? after = null,
        int? limit = null,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string?, int?, RequestOptions?, AsyncCollectionResult> func = client.GetVoiceConsentsAsync;

        var funcResult = func.Try(after, limit, options);
        if (funcResult.IsSuccess(out var collectionResult))
            return Result.Success(collectionResult);

        return funcResult.AsFailure<AsyncCollectionResult>();
    }

    /// <summary>Attempts to update voice consent and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="consentId">The voice consent identifier.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryUpdateVoiceConsent(
        this AudioClient client,
        string consentId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, ClientResult> func = client.UpdateVoiceConsent;

        var funcResult = func.Try(consentId, content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to update voice consent asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="consentId">The voice consent identifier.</param>
    /// <param name="content">The binary content for the request.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryUpdateVoiceConsentAsync(
        this AudioClient client,
        string consentId,
        BinaryContent content,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, BinaryContent, RequestOptions?, Task<ClientResult>> func = client.UpdateVoiceConsentAsync;

        var funcResult = await func.TryAsync(consentId, content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to delete voice consent and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="consentId">The voice consent identifier.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<ClientResult> TryDeleteVoiceConsent(this AudioClient client, string consentId, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, ClientResult> func = client.DeleteVoiceConsent;

        var funcResult = func.Try(consentId, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to delete voice consent asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="consentId">The voice consent identifier.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<ClientResult>> TryDeleteVoiceConsentAsync(this AudioClient client, string consentId, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, RequestOptions?, Task<ClientResult>> func = client.DeleteVoiceConsentAsync;

        var funcResult = await func.TryAsync(consentId, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to generate speech with streaming updates and wraps the result as an enumerable of <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="text">The text to generate audio for.</param>
    /// <param name="voice">The voice to use in the generated audio.</param>
    /// <param name="options">Optional generation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an enumerable of <see cref="Result{StreamingSpeechUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IEnumerable<Result<StreamingSpeechUpdate>>> TryGenerateSpeechStreaming(
        this AudioClient client,
        string text,
        GeneratedSpeechVoice voice,
        SpeechGenerationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, GeneratedSpeechVoice, SpeechGenerationOptions?, CancellationToken, CollectionResult<StreamingSpeechUpdate>> func =
            client.GenerateSpeechStreaming;

        var funcResult = func.Try(text, voice, options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsEnumerableResult());

        return funcResult.AsFailure<IEnumerable<Result<StreamingSpeechUpdate>>>();
    }

    /// <summary>Attempts to generate speech with streaming updates asynchronously and wraps the result as an asynchronous enumerable.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="text">The text to generate audio for.</param>
    /// <param name="voice">The voice to use in the generated audio.</param>
    /// <param name="options">Optional generation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{T}"/> containing an asynchronous enumerable of <see cref="Result{StreamingSpeechUpdate}"/>.</returns>
    [Experimental("OPENAI001")]
    public static Result<IAsyncEnumerable<Result<StreamingSpeechUpdate>>> TryGenerateSpeechStreamingAsync(
        this AudioClient client,
        string text,
        GeneratedSpeechVoice voice,
        SpeechGenerationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, GeneratedSpeechVoice, SpeechGenerationOptions?, CancellationToken, AsyncCollectionResult<StreamingSpeechUpdate>> func =
            client.GenerateSpeechStreamingAsync;

        var funcResult = func.Try(text, voice, options, cancellationToken);
        if (funcResult.IsSuccess(out var streamResult))
            return Result.Success(streamResult.AsAsyncEnumerableResult(cancellationToken));

        return funcResult.AsFailure<IAsyncEnumerable<Result<StreamingSpeechUpdate>>>();
    }

    /// <summary>Attempts to transcribe audio with diarization and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audio">The audio stream to transcribe.</param>
    /// <param name="audioFilename">The filename associated with the audio stream.</param>
    /// <param name="options">Optional transcription options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{DiarizedAudioTranscription}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<DiarizedAudioTranscription> TryTranscribeAudioDiarized(
        this AudioClient client,
        Stream audio,
        string audioFilename,
        AudioTranscriptionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, AudioTranscriptionOptions?, CancellationToken, ClientResult<DiarizedAudioTranscription>> func =
            client.TranscribeAudioDiarized;

        var funcResult = func.Try(audio, audioFilename, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<DiarizedAudioTranscription>();
    }

    /// <summary>Attempts to transcribe audio with diarization from a file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audioFilePath">The path of the audio file to transcribe.</param>
    /// <param name="options">Optional transcription options.</param>
    /// <returns>A <see cref="Result{DiarizedAudioTranscription}"/> representing the outcome.</returns>
    [Experimental("OPENAI001")]
    public static Result<DiarizedAudioTranscription> TryTranscribeAudioDiarized(
        this AudioClient client,
        string audioFilePath,
        AudioTranscriptionOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, AudioTranscriptionOptions?, ClientResult<DiarizedAudioTranscription>> func = client.TranscribeAudioDiarized;

        var funcResult = func.Try(audioFilePath, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<DiarizedAudioTranscription>();
    }

    /// <summary>Attempts to transcribe audio with diarization asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audio">The audio stream to transcribe.</param>
    /// <param name="audioFilename">The filename associated with the audio stream.</param>
    /// <param name="options">Optional transcription options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{DiarizedAudioTranscription}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<DiarizedAudioTranscription>> TryTranscribeAudioDiarizedAsync(
        this AudioClient client,
        Stream audio,
        string audioFilename,
        AudioTranscriptionOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, AudioTranscriptionOptions?, CancellationToken, Task<ClientResult<DiarizedAudioTranscription>>> func =
            client.TranscribeAudioDiarizedAsync;

        var funcResult = await func.TryAsync(audio, audioFilename, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<DiarizedAudioTranscription>();
    }

    /// <summary>Attempts to transcribe audio with diarization asynchronously from a file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The audio client instance.</param>
    /// <param name="audioFilePath">The path of the audio file to transcribe.</param>
    /// <param name="options">Optional transcription options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{DiarizedAudioTranscription}"/>.</returns>
    [Experimental("OPENAI001")]
    public static async Task<Result<DiarizedAudioTranscription>> TryTranscribeAudioDiarizedAsync(
        this AudioClient client,
        string audioFilePath,
        AudioTranscriptionOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, AudioTranscriptionOptions?, Task<ClientResult<DiarizedAudioTranscription>>> func = client.TranscribeAudioDiarizedAsync;

        var funcResult = await func.TryAsync(audioFilePath, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<DiarizedAudioTranscription>();
    }
}
