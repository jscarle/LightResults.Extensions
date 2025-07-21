using System.ClientModel;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.Embeddings;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides extension methods for <see cref="EmbeddingClient"/> that integrate the <see cref="Result"/> pattern, enabling safe and expressive error
/// handling for OpenAI embedding operations. These methods wrap both synchronous and asynchronous embedding requests in <see cref="Result{T}"/> types, making it
/// easy to handle errors and successful responses without exceptions.
/// </summary>
public static class EmbeddingClientExtensions
{
    /// <summary>Attempts to asynchronously generate an embedding representing the text input and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The embedding client instance.</param>
    /// <param name="input">The text input to generate an embedding for.</param>
    /// <param name="options">The options to configure the embedding generation.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{OpenAIEmbedding}"/>.</returns>
    public static async Task<Result<OpenAIEmbedding>> TryGenerateEmbeddingAsync(
        this EmbeddingClient client,
        string input,
        EmbeddingGenerationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, EmbeddingGenerationOptions?, CancellationToken, Task<ClientResult<OpenAIEmbedding>>> func = client.GenerateEmbeddingAsync;

        var funcResult = await func.TryAsync(input, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIEmbedding>();
    }

    /// <summary>Attempts to synchronously generate an embedding representing the text input and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The embedding client instance.</param>
    /// <param name="input">The text input to generate an embedding for.</param>
    /// <param name="options">The options to configure the embedding generation.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{OpenAIEmbedding}"/> representing the outcome.</returns>
    public static Result<OpenAIEmbedding> TryGenerateEmbedding(
        this EmbeddingClient client,
        string input,
        EmbeddingGenerationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, EmbeddingGenerationOptions?, CancellationToken, ClientResult<OpenAIEmbedding>> func = client.GenerateEmbedding;

        var funcResult = func.Try(input, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIEmbedding>();
    }

    /// <summary>Attempts to asynchronously generate embeddings representing the text inputs and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The embedding client instance.</param>
    /// <param name="inputs">The text inputs to generate embeddings for.</param>
    /// <param name="options">The options to configure the embedding generation.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{OpenAIEmbeddingCollection}"/>.</returns>
    public static async Task<Result<OpenAIEmbeddingCollection>> TryGenerateEmbeddingsAsync(
        this EmbeddingClient client,
        IEnumerable<string> inputs,
        EmbeddingGenerationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<IEnumerable<string>, EmbeddingGenerationOptions?, CancellationToken, Task<ClientResult<OpenAIEmbeddingCollection>>> func =
            client.GenerateEmbeddingsAsync;

        var funcResult = await func.TryAsync(inputs, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIEmbeddingCollection>();
    }

    /// <summary>Attempts to synchronously generate embeddings representing the text inputs and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The embedding client instance.</param>
    /// <param name="inputs">The text inputs to generate embeddings for.</param>
    /// <param name="options">The options to configure the embedding generation.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{OpenAIEmbeddingCollection}"/> representing the outcome.</returns>
    public static Result<OpenAIEmbeddingCollection> TryGenerateEmbeddings(
        this EmbeddingClient client,
        IEnumerable<string> inputs,
        EmbeddingGenerationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<IEnumerable<string>, EmbeddingGenerationOptions?, CancellationToken, ClientResult<OpenAIEmbeddingCollection>> func = client.GenerateEmbeddings;

        var funcResult = func.Try(inputs, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIEmbeddingCollection>();
    }

    /// <summary>Attempts to asynchronously generate embeddings representing the tokenized text inputs and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The embedding client instance.</param>
    /// <param name="inputs">The tokenized text inputs to generate embeddings for.</param>
    /// <param name="options">The options to configure the embedding generation.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{OpenAIEmbeddingCollection}"/>.</returns>
    public static async Task<Result<OpenAIEmbeddingCollection>> TryGenerateEmbeddingsAsync(
        this EmbeddingClient client,
        IEnumerable<ReadOnlyMemory<int>> inputs,
        EmbeddingGenerationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<IEnumerable<ReadOnlyMemory<int>>, EmbeddingGenerationOptions?, CancellationToken, Task<ClientResult<OpenAIEmbeddingCollection>>> func =
            client.GenerateEmbeddingsAsync;

        var funcResult = await func.TryAsync(inputs, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIEmbeddingCollection>();
    }

    /// <summary>Attempts to synchronously generate embeddings representing the tokenized text inputs and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The embedding client instance.</param>
    /// <param name="inputs">The tokenized text inputs to generate embeddings for.</param>
    /// <param name="options">The options to configure the embedding generation.</param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns>A <see cref="Result{OpenAIEmbeddingCollection}"/> representing the outcome.</returns>
    public static Result<OpenAIEmbeddingCollection> TryGenerateEmbeddings(
        this EmbeddingClient client,
        IEnumerable<ReadOnlyMemory<int>> inputs,
        EmbeddingGenerationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<IEnumerable<ReadOnlyMemory<int>>, EmbeddingGenerationOptions?, CancellationToken, ClientResult<OpenAIEmbeddingCollection>> func =
            client.GenerateEmbeddings;

        var funcResult = func.Try(inputs, options, cancellationToken);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult.Value);

        return funcResult.AsFailure<OpenAIEmbeddingCollection>();
    }
}
