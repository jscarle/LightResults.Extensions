using System.ClientModel;
using System.ClientModel.Primitives;
using LightResults.Extensions.ExceptionHandling;
using OpenAI.Images;

namespace LightResults.Extensions.OpenAI;

/// <summary>
/// Provides extension methods for <see cref="ImageClient"/> that integrate the <see cref="Result"/> pattern, enabling safe and expressive error handling
/// for OpenAI image operations. These methods wrap both synchronous and asynchronous image generation requests in <see cref="Result{T}"/> types, making it easy to
/// handle errors and successful responses without exceptions.
/// </summary>
public static class ImageClientExtensions
{
    /// <summary>Attempts to generate a single image asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="prompt">The text prompt describing the desired image.</param>
    /// <param name="options">Optional image generation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{GeneratedImage}"/>.</returns>
    public static async Task<Result<GeneratedImage>> TryGenerateImageAsync(
        this ImageClient client,
        string prompt,
        ImageGenerationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ImageGenerationOptions?, CancellationToken, Task<ClientResult<GeneratedImage>>> func = client.GenerateImageAsync;

        var funcResult = await func.TryAsync(prompt, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImage>();
    }

    /// <summary>Attempts to generate a single image synchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="prompt">The text prompt describing the desired image.</param>
    /// <param name="options">Optional image generation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{GeneratedImage}"/> representing the outcome.</returns>
    public static Result<GeneratedImage> TryGenerateImage(
        this ImageClient client,
        string prompt,
        ImageGenerationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ImageGenerationOptions?, CancellationToken, ClientResult<GeneratedImage>> func = client.GenerateImage;

        var funcResult = func.Try(prompt, options, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImage>();
    }

    /// <summary>Attempts to generate an image edit asynchronously from a stream and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="image">The image stream to edit.</param>
    /// <param name="imageFilename">The filename of the image.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{GeneratedImage}"/>.</returns>
    public static async Task<Result<GeneratedImage>> TryGenerateImageEditAsync(
        this ImageClient client,
        Stream image,
        string imageFilename,
        string prompt,
        ImageEditOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, string, ImageEditOptions?, CancellationToken, Task<ClientResult<GeneratedImage>>> func = client.GenerateImageEditAsync;

        var funcResult = await func.TryAsync(image, imageFilename, prompt, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImage>();
    }

    /// <summary>Attempts to generate an image edit synchronously from a stream and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="image">The image stream to edit.</param>
    /// <param name="imageFilename">The filename of the image.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{GeneratedImage}"/> representing the outcome.</returns>
    public static Result<GeneratedImage> TryGenerateImageEdit(
        this ImageClient client,
        Stream image,
        string imageFilename,
        string prompt,
        ImageEditOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, string, ImageEditOptions?, CancellationToken, ClientResult<GeneratedImage>> func = client.GenerateImageEdit;

        var funcResult = func.Try(image, imageFilename, prompt, options, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImage>();
    }

    /// <summary>Attempts to generate an image edit asynchronously from a file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="imageFilePath">The path to the image file to edit.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{GeneratedImage}"/>.</returns>
    public static async Task<Result<GeneratedImage>> TryGenerateImageEditAsync(
        this ImageClient client,
        string imageFilePath,
        string prompt,
        ImageEditOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, ImageEditOptions?, Task<ClientResult<GeneratedImage>>> func = client.GenerateImageEditAsync;

        var funcResult = await func.TryAsync(imageFilePath, prompt, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImage>();
    }

    /// <summary>Attempts to generate an image edit synchronously from a file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="imageFilePath">The path to the image file to edit.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <returns>A <see cref="Result{GeneratedImage}"/> representing the outcome.</returns>
    public static Result<GeneratedImage> TryGenerateImageEdit(this ImageClient client, string imageFilePath, string prompt, ImageEditOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, ImageEditOptions?, ClientResult<GeneratedImage>> func = client.GenerateImageEdit;

        var funcResult = func.Try(imageFilePath, prompt, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImage>();
    }

    /// <summary>Attempts to generate an image edit asynchronously from streams with mask and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="image">The image stream to edit.</param>
    /// <param name="imageFilename">The filename of the image.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="mask">The mask stream defining the editing area.</param>
    /// <param name="maskFilename">The filename of the mask.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{GeneratedImage}"/>.</returns>
    public static async Task<Result<GeneratedImage>> TryGenerateImageEditAsync(
        this ImageClient client,
        Stream image,
        string imageFilename,
        string prompt,
        Stream mask,
        string maskFilename,
        ImageEditOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, string, Stream, string, ImageEditOptions?, CancellationToken, Task<ClientResult<GeneratedImage>>> func =
            client.GenerateImageEditAsync;

        var funcResult = await func.TryAsync(image, imageFilename, prompt, mask, maskFilename, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImage>();
    }

    /// <summary>Attempts to generate an image edit synchronously from streams with mask and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="image">The image stream to edit.</param>
    /// <param name="imageFilename">The filename of the image.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="mask">The mask stream defining the editing area.</param>
    /// <param name="maskFilename">The filename of the mask.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{GeneratedImage}"/> representing the outcome.</returns>
    public static Result<GeneratedImage> TryGenerateImageEdit(
        this ImageClient client,
        Stream image,
        string imageFilename,
        string prompt,
        Stream mask,
        string maskFilename,
        ImageEditOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, string, Stream, string, ImageEditOptions?, CancellationToken, ClientResult<GeneratedImage>> func = client.GenerateImageEdit;

        var funcResult = func.Try(image, imageFilename, prompt, mask, maskFilename, options, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImage>();
    }

    /// <summary>Attempts to generate an image edit asynchronously from file paths with mask and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="imageFilePath">The path to the image file to edit.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="maskFilePath">The path to the mask file defining the editing area.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{GeneratedImage}"/>.</returns>
    public static async Task<Result<GeneratedImage>> TryGenerateImageEditAsync(
        this ImageClient client,
        string imageFilePath,
        string prompt,
        string maskFilePath,
        ImageEditOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, string, ImageEditOptions?, Task<ClientResult<GeneratedImage>>> func = client.GenerateImageEditAsync;

        var funcResult = await func.TryAsync(imageFilePath, prompt, maskFilePath, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImage>();
    }

    /// <summary>Attempts to generate an image edit synchronously from file paths with mask and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="imageFilePath">The path to the image file to edit.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="maskFilePath">The path to the mask file defining the editing area.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <returns>A <see cref="Result{GeneratedImage}"/> representing the outcome.</returns>
    public static Result<GeneratedImage> TryGenerateImageEdit(
        this ImageClient client,
        string imageFilePath,
        string prompt,
        string maskFilePath,
        ImageEditOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, string, ImageEditOptions?, ClientResult<GeneratedImage>> func = client.GenerateImageEdit;

        var funcResult = func.Try(imageFilePath, prompt, maskFilePath, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImage>();
    }

    /// <summary>Attempts to generate an image variation asynchronously from a stream and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="image">The image stream to create a variation from.</param>
    /// <param name="imageFilename">The filename of the image.</param>
    /// <param name="options">Optional image variation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{GeneratedImage}"/>.</returns>
    public static async Task<Result<GeneratedImage>> TryGenerateImageVariationAsync(
        this ImageClient client,
        Stream image,
        string imageFilename,
        ImageVariationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, ImageVariationOptions?, CancellationToken, Task<ClientResult<GeneratedImage>>> func = client.GenerateImageVariationAsync;

        var funcResult = await func.TryAsync(image, imageFilename, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImage>();
    }

    /// <summary>Attempts to generate an image variation synchronously from a stream and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="image">The image stream to create a variation from.</param>
    /// <param name="imageFilename">The filename of the image.</param>
    /// <param name="options">Optional image variation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{GeneratedImage}"/> representing the outcome.</returns>
    public static Result<GeneratedImage> TryGenerateImageVariation(
        this ImageClient client,
        Stream image,
        string imageFilename,
        ImageVariationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, ImageVariationOptions?, CancellationToken, ClientResult<GeneratedImage>> func = client.GenerateImageVariation;

        var funcResult = func.Try(image, imageFilename, options, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImage>();
    }

    /// <summary>Attempts to generate an image variation asynchronously from a file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="imageFilePath">The path to the image file to create a variation from.</param>
    /// <param name="options">Optional image variation options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{GeneratedImage}"/>.</returns>
    public static async Task<Result<GeneratedImage>> TryGenerateImageVariationAsync(
        this ImageClient client,
        string imageFilePath,
        ImageVariationOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ImageVariationOptions?, Task<ClientResult<GeneratedImage>>> func = client.GenerateImageVariationAsync;

        var funcResult = await func.TryAsync(imageFilePath, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImage>();
    }

    /// <summary>Attempts to generate an image variation synchronously from a file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="imageFilePath">The path to the image file to create a variation from.</param>
    /// <param name="options">Optional image variation options.</param>
    /// <returns>A <see cref="Result{GeneratedImage}"/> representing the outcome.</returns>
    public static Result<GeneratedImage> TryGenerateImageVariation(this ImageClient client, string imageFilePath, ImageVariationOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, ImageVariationOptions?, ClientResult<GeneratedImage>> func = client.GenerateImageVariation;

        var funcResult = func.Try(imageFilePath, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImage>();
    }

    /// <summary>Attempts to generate multiple images asynchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="prompt">The text prompt describing the desired images.</param>
    /// <param name="imageCount">The number of images to generate.</param>
    /// <param name="options">Optional image generation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{GeneratedImageCollection}"/>.</returns>
    public static async Task<Result<GeneratedImageCollection>> TryGenerateImagesAsync(
        this ImageClient client,
        string prompt,
        int imageCount,
        ImageGenerationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int, ImageGenerationOptions?, CancellationToken, Task<ClientResult<GeneratedImageCollection>>> func = client.GenerateImagesAsync;

        var funcResult = await func.TryAsync(prompt, imageCount, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImageCollection>();
    }

    /// <summary>Attempts to generate multiple images synchronously and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="prompt">The text prompt describing the desired images.</param>
    /// <param name="imageCount">The number of images to generate.</param>
    /// <param name="options">Optional image generation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{GeneratedImageCollection}"/> representing the outcome.</returns>
    public static Result<GeneratedImageCollection> TryGenerateImages(
        this ImageClient client,
        string prompt,
        int imageCount,
        ImageGenerationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int, ImageGenerationOptions?, CancellationToken, ClientResult<GeneratedImageCollection>> func = client.GenerateImages;

        var funcResult = func.Try(prompt, imageCount, options, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImageCollection>();
    }

    /// <summary>Attempts to generate multiple image edits asynchronously from a stream and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="image">The image stream to edit.</param>
    /// <param name="imageFilename">The filename of the image.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="imageCount">The number of edited images to generate.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{GeneratedImageCollection}"/>.</returns>
    public static async Task<Result<GeneratedImageCollection>> TryGenerateImageEditsAsync(
        this ImageClient client,
        Stream image,
        string imageFilename,
        string prompt,
        int imageCount,
        ImageEditOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, string, int, ImageEditOptions?, CancellationToken, Task<ClientResult<GeneratedImageCollection>>> func =
            client.GenerateImageEditsAsync;

        var funcResult = await func.TryAsync(image, imageFilename, prompt, imageCount, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImageCollection>();
    }

    /// <summary>Attempts to generate multiple image edits synchronously from a stream and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="image">The image stream to edit.</param>
    /// <param name="imageFilename">The filename of the image.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="imageCount">The number of edited images to generate.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{GeneratedImageCollection}"/> representing the outcome.</returns>
    public static Result<GeneratedImageCollection> TryGenerateImageEdits(
        this ImageClient client,
        Stream image,
        string imageFilename,
        string prompt,
        int imageCount,
        ImageEditOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, string, int, ImageEditOptions?, CancellationToken, ClientResult<GeneratedImageCollection>> func = client.GenerateImageEdits;

        var funcResult = func.Try(image, imageFilename, prompt, imageCount, options, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImageCollection>();
    }

    /// <summary>Attempts to generate multiple image edits asynchronously from a file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="imageFilePath">The path to the image file to edit.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="imageCount">The number of edited images to generate.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{GeneratedImageCollection}"/>.</returns>
    public static async Task<Result<GeneratedImageCollection>> TryGenerateImageEditsAsync(
        this ImageClient client,
        string imageFilePath,
        string prompt,
        int imageCount,
        ImageEditOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, int, ImageEditOptions?, Task<ClientResult<GeneratedImageCollection>>> func = client.GenerateImageEditsAsync;

        var funcResult = await func.TryAsync(imageFilePath, prompt, imageCount, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImageCollection>();
    }

    /// <summary>Attempts to generate multiple image edits synchronously from a file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="imageFilePath">The path to the image file to edit.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="imageCount">The number of edited images to generate.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <returns>A <see cref="Result{GeneratedImageCollection}"/> representing the outcome.</returns>
    public static Result<GeneratedImageCollection> TryGenerateImageEdits(
        this ImageClient client,
        string imageFilePath,
        string prompt,
        int imageCount,
        ImageEditOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, int, ImageEditOptions?, ClientResult<GeneratedImageCollection>> func = client.GenerateImageEdits;

        var funcResult = func.Try(imageFilePath, prompt, imageCount, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImageCollection>();
    }

    /// <summary>Attempts to generate multiple image edits asynchronously from streams with mask and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="image">The image stream to edit.</param>
    /// <param name="imageFilename">The filename of the image.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="mask">The mask stream defining the editing area.</param>
    /// <param name="maskFilename">The filename of the mask.</param>
    /// <param name="imageCount">The number of edited images to generate.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{GeneratedImageCollection}"/>.</returns>
    public static async Task<Result<GeneratedImageCollection>> TryGenerateImageEditsAsync(
        this ImageClient client,
        Stream image,
        string imageFilename,
        string prompt,
        Stream mask,
        string maskFilename,
        int imageCount,
        ImageEditOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, string, Stream, string, int, ImageEditOptions?, CancellationToken, Task<ClientResult<GeneratedImageCollection>>> func =
            client.GenerateImageEditsAsync;

        var funcResult = await func.TryAsync(image, imageFilename, prompt, mask, maskFilename, imageCount, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImageCollection>();
    }

    /// <summary>Attempts to generate multiple image edits synchronously from streams with mask and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="image">The image stream to edit.</param>
    /// <param name="imageFilename">The filename of the image.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="mask">The mask stream defining the editing area.</param>
    /// <param name="maskFilename">The filename of the mask.</param>
    /// <param name="imageCount">The number of edited images to generate.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{GeneratedImageCollection}"/> representing the outcome.</returns>
    public static Result<GeneratedImageCollection> TryGenerateImageEdits(
        this ImageClient client,
        Stream image,
        string imageFilename,
        string prompt,
        Stream mask,
        string maskFilename,
        int imageCount,
        ImageEditOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, string, Stream, string, int, ImageEditOptions?, CancellationToken, ClientResult<GeneratedImageCollection>> func =
            client.GenerateImageEdits;

        var funcResult = func.Try(image, imageFilename, prompt, mask, maskFilename, imageCount, options, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImageCollection>();
    }

    /// <summary>Attempts to generate multiple image edits asynchronously from file paths with mask and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="imageFilePath">The path to the image file to edit.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="maskFilePath">The path to the mask file defining the editing area.</param>
    /// <param name="imageCount">The number of edited images to generate.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{GeneratedImageCollection}"/>.</returns>
    public static async Task<Result<GeneratedImageCollection>> TryGenerateImageEditsAsync(
        this ImageClient client,
        string imageFilePath,
        string prompt,
        string maskFilePath,
        int imageCount,
        ImageEditOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, string, int, ImageEditOptions?, Task<ClientResult<GeneratedImageCollection>>> func = client.GenerateImageEditsAsync;

        var funcResult = await func.TryAsync(imageFilePath, prompt, maskFilePath, imageCount, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImageCollection>();
    }

    /// <summary>Attempts to generate multiple image edits synchronously from file paths with mask and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="imageFilePath">The path to the image file to edit.</param>
    /// <param name="prompt">The text prompt describing the desired changes.</param>
    /// <param name="maskFilePath">The path to the mask file defining the editing area.</param>
    /// <param name="imageCount">The number of edited images to generate.</param>
    /// <param name="options">Optional image edit options.</param>
    /// <returns>A <see cref="Result{GeneratedImageCollection}"/> representing the outcome.</returns>
    public static Result<GeneratedImageCollection> TryGenerateImageEdits(
        this ImageClient client,
        string imageFilePath,
        string prompt,
        string maskFilePath,
        int imageCount,
        ImageEditOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, string, string, int, ImageEditOptions?, ClientResult<GeneratedImageCollection>> func = client.GenerateImageEdits;

        var funcResult = func.Try(imageFilePath, prompt, maskFilePath, imageCount, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImageCollection>();
    }

    /// <summary>Attempts to generate multiple image variations asynchronously from a stream and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="image">The image stream to create variations from.</param>
    /// <param name="imageFilename">The filename of the image.</param>
    /// <param name="imageCount">The number of image variations to generate.</param>
    /// <param name="options">Optional image variation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{GeneratedImageCollection}"/>.</returns>
    public static async Task<Result<GeneratedImageCollection>> TryGenerateImageVariationsAsync(
        this ImageClient client,
        Stream image,
        string imageFilename,
        int imageCount,
        ImageVariationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, int, ImageVariationOptions?, CancellationToken, Task<ClientResult<GeneratedImageCollection>>> func =
            client.GenerateImageVariationsAsync;

        var funcResult = await func.TryAsync(image, imageFilename, imageCount, options, cancellationToken).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImageCollection>();
    }

    /// <summary>Attempts to generate multiple image variations synchronously from a stream and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="image">The image stream to create variations from.</param>
    /// <param name="imageFilename">The filename of the image.</param>
    /// <param name="imageCount">The number of image variations to generate.</param>
    /// <param name="options">Optional image variation options.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{GeneratedImageCollection}"/> representing the outcome.</returns>
    public static Result<GeneratedImageCollection> TryGenerateImageVariations(
        this ImageClient client,
        Stream image,
        string imageFilename,
        int imageCount,
        ImageVariationOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<Stream, string, int, ImageVariationOptions?, CancellationToken, ClientResult<GeneratedImageCollection>> func = client.GenerateImageVariations;

        var funcResult = func.Try(image, imageFilename, imageCount, options, cancellationToken);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImageCollection>();
    }

    /// <summary>Attempts to generate multiple image variations asynchronously from a file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="imageFilePath">The path to the image file to create variations from.</param>
    /// <param name="imageCount">The number of image variations to generate.</param>
    /// <param name="options">Optional image variation options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{GeneratedImageCollection}"/>.</returns>
    public static async Task<Result<GeneratedImageCollection>> TryGenerateImageVariationsAsync(
        this ImageClient client,
        string imageFilePath,
        int imageCount,
        ImageVariationOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int, ImageVariationOptions?, Task<ClientResult<GeneratedImageCollection>>> func = client.GenerateImageVariationsAsync;

        var funcResult = await func.TryAsync(imageFilePath, imageCount, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImageCollection>();
    }

    /// <summary>Attempts to generate multiple image variations synchronously from a file path and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="imageFilePath">The path to the image file to create variations from.</param>
    /// <param name="imageCount">The number of image variations to generate.</param>
    /// <param name="options">Optional image variation options.</param>
    /// <returns>A <see cref="Result{GeneratedImageCollection}"/> representing the outcome.</returns>
    public static Result<GeneratedImageCollection> TryGenerateImageVariations(
        this ImageClient client,
        string imageFilePath,
        int imageCount,
        ImageVariationOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<string, int, ImageVariationOptions?, ClientResult<GeneratedImageCollection>> func = client.GenerateImageVariations;

        var funcResult = func.Try(imageFilePath, imageCount, options);
        if (funcResult.IsSuccess(out var result))
            return Result.Success(result.Value);

        return funcResult.AsFailure<GeneratedImageCollection>();
    }

    /// <summary>Attempts to generate multiple images asynchronously with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="content">The binary content for image generation.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    public static async Task<Result<ClientResult>> TryGenerateImagesAsync(this ImageClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, Task<ClientResult>> func = client.GenerateImagesAsync;

        var funcResult = await func.TryAsync(content, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to generate multiple images synchronously with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="content">The binary content for image generation.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    public static Result<ClientResult> TryGenerateImages(this ImageClient client, BinaryContent content, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, RequestOptions?, ClientResult> func = client.GenerateImages;

        var funcResult = func.Try(content, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to generate multiple image edits asynchronously with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="content">The binary content for image editing.</param>
    /// <param name="contentType">The content type for the binary content.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    public static async Task<Result<ClientResult>> TryGenerateImageEditsAsync(
        this ImageClient client,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions?, Task<ClientResult>> func = client.GenerateImageEditsAsync;

        var funcResult = await func.TryAsync(content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to generate multiple image edits synchronously with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="content">The binary content for image editing.</param>
    /// <param name="contentType">The content type for the binary content.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    public static Result<ClientResult> TryGenerateImageEdits(this ImageClient client, BinaryContent content, string contentType, RequestOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions?, ClientResult> func = client.GenerateImageEdits;

        var funcResult = func.Try(content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to generate multiple image variations asynchronously with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="content">The binary content for image variation.</param>
    /// <param name="contentType">The content type for the binary content.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A task representing the asynchronous operation, containing a <see cref="Result{ClientResult}"/>.</returns>
    public static async Task<Result<ClientResult>> TryGenerateImageVariationsAsync(
        this ImageClient client,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions?, Task<ClientResult>> func = client.GenerateImageVariationsAsync;

        var funcResult = await func.TryAsync(content, contentType, options).ConfigureAwait(false);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }

    /// <summary>Attempts to generate multiple image variations synchronously with binary content and wraps the result in a <see cref="Result{T}"/>.</summary>
    /// <param name="client">The image client instance.</param>
    /// <param name="content">The binary content for image variation.</param>
    /// <param name="contentType">The content type for the binary content.</param>
    /// <param name="options">Optional request options.</param>
    /// <returns>A <see cref="Result{ClientResult}"/> representing the outcome.</returns>
    public static Result<ClientResult> TryGenerateImageVariations(
        this ImageClient client,
        BinaryContent content,
        string contentType,
        RequestOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(client);

        Func<BinaryContent, string, RequestOptions?, ClientResult> func = client.GenerateImageVariations;

        var funcResult = func.Try(content, contentType, options);
        if (funcResult.IsSuccess(out var clientResult))
            return Result.Success(clientResult);

        return funcResult.AsFailure<ClientResult>();
    }
}
