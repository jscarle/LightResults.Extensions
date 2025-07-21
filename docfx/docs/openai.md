# OpenAI

[![Banner](https://raw.githubusercontent.com/jscarle/LightResults/main/Banner.png)](https://github.com/jscarle/LightResults)

The `LightResults.Extensions.OpenAI` package provides seamless integration between LightResults and OpenAI services, offering extension methods that return `Result<T>` instead of throwing exceptions.

## Installation

```bash
dotnet add package LightResults.Extensions.OpenAI
```

## Overview

This extension wraps common OpenAI operations with the Result pattern, providing a more functional approach to error handling. Instead of dealing with exceptions, you get explicit success/failure results that you can pattern match on or chain with other operations.

## Features

- **Chat Completions**: Create chat completions with proper error handling
- **Embeddings**: Generate text embeddings with Result pattern
- **Image Generation**: Generate images using DALL-E with safe error handling
- **Async Support**: Full async/await support for all operations
- **Cancellation Support**: CancellationToken support for long-running operations

## Usage

### Basic Setup

```csharp
using OpenAI.Chat;
using LightResults.Extensions.OpenAI;

var client = new ChatClient("gpt-4o", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
```

### Chat Completions

```csharp
// Simple chat completion
var result = client.TryCompleteChat("What is the meaning of life?");
if (result.IsSuccess(out var completion))
{
    Console.WriteLine($"Response: {completion.Content[0].Text}");
}
else if (result.IsFailure(out var error))
{
    Console.WriteLine($"Error: {error.Message}");
}

// Async chat completion
var asyncResult = await client.TryCompleteChatAsync("Explain quantum computing");
if (asyncResult.IsSuccess(out var asyncCompletion))
{
    Console.WriteLine($"Response: {asyncCompletion.Content[0].Text}");
}
else if (asyncResult.IsFailure(out var asyncError))
{
    Console.WriteLine($"Error: {asyncError.Message}");
}

// Chat with multiple messages
var messages = new List<ChatMessage>
{
    new SystemChatMessage("You are a helpful assistant."),
    new UserChatMessage("What is artificial intelligence?")
};

var chatResult = await client.TryCompleteChatAsync(messages);
if (chatResult.IsSuccess(out var chatCompletion))
{
    Console.WriteLine($"Response: {chatCompletion.Content[0].Text}");
}
```

### Embeddings

```csharp
using OpenAI.Embeddings;
using LightResults.Extensions.OpenAI;

var embeddingClient = new EmbeddingClient("text-embedding-3-small", apiKey);

// Generate single embedding
var embeddingResult = await embeddingClient.TryGenerateEmbeddingAsync("Hello, world!");
if (embeddingResult.IsSuccess(out var embedding))
{
    var vector = embedding.ToFloats();
    Console.WriteLine($"Generated embedding with {vector.Length} dimensions");
}

// Generate multiple embeddings
var texts = new[] { "First text", "Second text", "Third text" };
var embeddingsResult = await embeddingClient.TryGenerateEmbeddingsAsync(texts);
if (embeddingsResult.IsSuccess(out var embeddings))
{
    Console.WriteLine($"Generated {embeddings.Count} embeddings");
}
```

### Image Generation

```csharp
using OpenAI.Images;
using LightResults.Extensions.OpenAI;

var imageClient = new ImageClient("dall-e-3", apiKey);

// Generate single image
var imageResult = await imageClient.TryGenerateImageAsync(
    "A serene landscape with mountains and a lake at sunset");

if (imageResult.IsSuccess(out var image))
{
    Console.WriteLine($"Generated image URL: {image.ImageUri}");
}

// Generate multiple images
var imagesResult = await imageClient.TryGenerateImagesAsync(
    "A cute cat wearing a hat", 
    imageCount: 2);

if (imagesResult.IsSuccess(out var images))
{
    foreach (var generatedImage in images)
    {
        Console.WriteLine($"Image URL: {generatedImage.ImageUri}");
    }
}
```

### Error Handling Patterns

```csharp
// Pattern matching with method calls
var result = await client.TryCompleteChatAsync("Hello!");
if (result.IsSuccess(out var completion))
{
    Console.WriteLine($"Success: {completion.Content[0].Text}");
}
else if (result.IsFailure(out var error))
{
    Console.WriteLine($"Failed: {error.Message}");
}

// Alternative pattern using separate checks
var chatResult = await client.TryCompleteChatAsync("Generate a creative story");
if (chatResult.IsSuccess())
{
    // Get the value safely
    if (chatResult.IsSuccess(out var story))
    {
        Console.WriteLine($"Generated story: {story.Content[0].Text}");
    }
}
else
{
    // Handle the error
    if (chatResult.IsFailure(out var error))
    {
        Console.WriteLine($"Story generation failed: {error.Message}");
    }
}
```

### Advanced Options

```csharp
// Chat completion with options
var options = new ChatCompletionOptions
{
    Temperature = 0.7f,
    MaxTokens = 150,
    ResponseFormat = ChatResponseFormat.Text
};

var result = await client.TryCompleteChatAsync("Be creative!", options);

// Embedding with custom dimensions
var embeddingOptions = new EmbeddingGenerationOptions 
{ 
    Dimensions = 512 
};

var embeddingResult = await embeddingClient.TryGenerateEmbeddingAsync(
    "Sample text", embeddingOptions);

// Image generation with custom settings
var imageOptions = new ImageGenerationOptions
{
    Quality = GeneratedImageQuality.High,
    Size = GeneratedImageSize.W1024xH1024,
    Style = GeneratedImageStyle.Vivid
};

var imageResult = await imageClient.TryGenerateImageAsync(
    "A futuristic cityscape", imageOptions);
```

## Best Practices

1. **Always check results**: Use `IsSuccess()` and `IsFailure()` methods to verify operation outcomes
2. **Use safe value access**: Use `IsSuccess(out var value)` to safely retrieve success values
3. **Use safe error access**: Use `IsFailure(out var error)` to safely retrieve error information
4. **Use async methods**: For better performance and responsiveness
5. **Handle cancellation**: Pass CancellationTokens for long-running operations
6. **Configure timeouts**: Set appropriate timeouts for your use case
7. **Log errors**: Capture and log errors for debugging and monitoring

## Configuration

You can configure the OpenAI client with custom settings:

```csharp
var client = new ChatClient(
    model: "gpt-4o",
    credential: new ApiKeyCredential(apiKey),
    options: new OpenAIClientOptions()
    {
        Endpoint = new Uri("https://your-custom-endpoint.com"),
        RetryPolicy = new RetryPolicy(maxRetries: 3)
    }
);
```

## Error Types

The extension captures various types of errors and wraps them in Result objects:

- **Authentication errors**: Invalid API key or permissions
- **Rate limiting**: Too many requests
- **Network errors**: Connection timeouts or failures
- **API errors**: Invalid parameters or service errors
- **Model errors**: Model not available or context length exceeded

## Thread Safety

All extension methods are thread-safe and can be used concurrently from multiple threads. 