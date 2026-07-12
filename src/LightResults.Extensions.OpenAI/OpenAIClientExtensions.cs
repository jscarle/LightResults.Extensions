using LightResults.Extensions.ExceptionHandling;
using OpenAI;
using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Batch;
using OpenAI.Chat;
using OpenAI.Containers;
using OpenAI.Conversations;
using OpenAI.Embeddings;
using OpenAI.Evals;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Graders;
using OpenAI.Images;
using OpenAI.Models;
using OpenAI.Moderations;
using OpenAI.Realtime;
using OpenAI.Responses;
using OpenAI.Skills;
using OpenAI.VectorStores;
using OpenAI.Videos;
using System.Diagnostics.CodeAnalysis;
// ReSharper disable InconsistentNaming

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides Try wrappers for <see cref="OpenAIClient"/> methods in OpenAI 2.12.0.
/// </summary>
public static class OpenAIClientExtensions
{
    /// <summary>
    /// Attempts to execute <c>GetAssistantClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<AssistantClient> TryGetAssistantClient(
        this OpenAIClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<AssistantClient> func = client.GetAssistantClient;

        var funcResult = func.Try();
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<AssistantClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetAudioClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>GetAudioClient</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<AudioClient> TryGetAudioClient(
        this OpenAIClient client,
        string model
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            AudioClient> func = client.GetAudioClient;

        var funcResult = func.Try(model);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<AudioClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetBatchClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<BatchClient> TryGetBatchClient(
        this OpenAIClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BatchClient> func = client.GetBatchClient;

        var funcResult = func.Try();
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<BatchClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetChatClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>GetChatClient</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<ChatClient> TryGetChatClient(
        this OpenAIClient client,
        string model
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            ChatClient> func = client.GetChatClient;

        var funcResult = func.Try(model);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<ChatClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetContainerClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ContainerClient> TryGetContainerClient(
        this OpenAIClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ContainerClient> func = client.GetContainerClient;

        var funcResult = func.Try();
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<ContainerClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetConversationClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ConversationClient> TryGetConversationClient(
        this OpenAIClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ConversationClient> func = client.GetConversationClient;

        var funcResult = func.Try();
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<ConversationClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetEmbeddingClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>GetEmbeddingClient</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<EmbeddingClient> TryGetEmbeddingClient(
        this OpenAIClient client,
        string model
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            EmbeddingClient> func = client.GetEmbeddingClient;

        var funcResult = func.Try(model);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<EmbeddingClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetEvaluationClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<EvaluationClient> TryGetEvaluationClient(
        this OpenAIClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<EvaluationClient> func = client.GetEvaluationClient;

        var funcResult = func.Try();
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<EvaluationClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetFineTuningClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<FineTuningClient> TryGetFineTuningClient(
        this OpenAIClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<FineTuningClient> func = client.GetFineTuningClient;

        var funcResult = func.Try();
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<FineTuningClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetGraderClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<GraderClient> TryGetGraderClient(
        this OpenAIClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<GraderClient> func = client.GetGraderClient;

        var funcResult = func.Try();
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<GraderClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetImageClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>GetImageClient</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<ImageClient> TryGetImageClient(
        this OpenAIClient client,
        string model
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            ImageClient> func = client.GetImageClient;

        var funcResult = func.Try(model);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<ImageClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetModerationClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <param name="model">Parameter forwarded to <c>GetModerationClient</c>.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<ModerationClient> TryGetModerationClient(
        this OpenAIClient client,
        string model
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<
            string,
            ModerationClient> func = client.GetModerationClient;

        var funcResult = func.Try(model);
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<ModerationClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetOpenAIFileClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<OpenAIFileClient> TryGetOpenAIFileClient(
        this OpenAIClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<OpenAIFileClient> func = client.GetOpenAIFileClient;

        var funcResult = func.Try();
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<OpenAIFileClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetOpenAIModelClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <returns>The wrapped result.</returns>
    public static Result<OpenAIModelClient> TryGetOpenAIModelClient(
        this OpenAIClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<OpenAIModelClient> func = client.GetOpenAIModelClient;

        var funcResult = func.Try();
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<OpenAIModelClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetRealtimeClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI002")]
    public static Result<RealtimeClient> TryGetRealtimeClient(
        this OpenAIClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<RealtimeClient> func = client.GetRealtimeClient;

        var funcResult = func.Try();
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<RealtimeClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetResponsesClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<ResponsesClient> TryGetResponsesClient(
        this OpenAIClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<ResponsesClient> func = client.GetResponsesClient;

        var funcResult = func.Try();
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<ResponsesClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetSkillClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<SkillClient> TryGetSkillClient(
        this OpenAIClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<SkillClient> func = client.GetSkillClient;

        var funcResult = func.Try();
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<SkillClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVectorStoreClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<VectorStoreClient> TryGetVectorStoreClient(
        this OpenAIClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<VectorStoreClient> func = client.GetVectorStoreClient;

        var funcResult = func.Try();
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<VectorStoreClient>();
    }

    /// <summary>
    /// Attempts to execute <c>GetVideoClient</c> and wraps the outcome in a Result.
    /// </summary>
    /// <param name="client">The OpenAIClient instance.</param>
    /// <returns>The wrapped result.</returns>
    [Experimental("OPENAI001")]
    public static Result<VideoClient> TryGetVideoClient(
        this OpenAIClient client
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<VideoClient> func = client.GetVideoClient;

        var funcResult = func.Try();
        if (funcResult.IsSuccess(out var value))
            return Result.Success(value);

        return funcResult.AsFailure<VideoClient>();
    }
}
