[![Banner](https://raw.githubusercontent.com/jscarle/LightResults/main/Banner.png)](https://github.com/jscarle/LightResults)

# LightResults Extensions

Extensions for [LightResults](https://github.com/jscarle/LightResults), an extremely light and modern Operation Result Pattern library for .NET.

[![main](https://img.shields.io/github/actions/workflow/status/jscarle/LightResults.Extensions/publish.yml?logo=github)](https://github.com/jscarle/LightResults.Extensions)

## OpenAI

Provides comprehensive an OpenAI (v2.7.0) integration with the Result pattern, offering extension methods that return `Result<T>` instead of throwing exceptions.

[![nuget](https://img.shields.io/nuget/v/LightResults.Extensions.OpenAI)](https://www.nuget.org/packages/LightResults.Extensions.OpenAI)
[![downloads](https://img.shields.io/nuget/dt/LightResults.Extensions.OpenAI)](https://www.nuget.org/packages/LightResults.Extensions.OpenAI)

## Documentation

Make sure to [read the docs](https://jscarle.github.io/LightResults.Extensions/) for the full API.

### Try overloads

This package provides a `Try` extension method version of all public methods for all OpenAI clients, wrapping operations in a `try { } catch { }` block. If an exception occurs, a failed result will be returned and the `Exception` will be added to the result as metadata.

**Supported Clients:**
- **Assistants** - `AssistantClient` extensions for AI assistants
- **Audio Processing** - `AudioClient` extensions for speech-to-text and text-to-speech
- **Batch Processing** - `BatchClient` extensions for batch operations
- **Chat Completions** - `ChatClient` extensions for chat completions and streaming
- **Conversations** - `ConversationClient` extensions for conversations
- **Embeddings** - `EmbeddingClient` extensions for text embeddings
- **Evaluations** - `EvaluationClient` extensions for model evaluations
- **File Operations** - `OpenAIFileClient` extensions for file uploads and management
- **Fine-tuning** - `FineTuningClient` extensions for model fine-tuning
- **Image Generation** - `ImageClient` extensions for image generation and editing
- **Responses** - `OpenAIResponseClient` extensions for responses and streaming
- **Vector Stores** - `VectorStoreClient` extensions for vector storage and retrieval

### Usage Examples

#### Chat Completions

```csharp
using OpenAI.Chat;
using LightResults.Extensions.OpenAI;

var client = new ChatClient("gpt-4o", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

// Simple chat completion
var result = await client.TryCompleteChatAsync("What is the meaning of life?");
if (result.IsSuccess(out var completion))
{
    Console.WriteLine($"Response: {completion.Content[0].Text}");
}
else if (result.IsFailure(out var error))
{
    Console.WriteLine($"Error: {error.Message}");
}

// Chat with multiple messages
var messages = new List<ChatMessage>
{
    new SystemChatMessage("You are a helpful assistant."),
    new UserChatMessage("Explain quantum computing in simple terms.")
};

var chatResult = await client.TryCompleteChatAsync(messages);
if (chatResult.IsSuccess(out var chatCompletion))
{
    Console.WriteLine($"Response: {chatCompletion.Content[0].Text}");
}
```

#### Embeddings

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

#### Image Generation

```csharp
using OpenAI.Images;
using LightResults.Extensions.OpenAI;

var imageClient = new ImageClient("dall-e-3", apiKey);

// Generate image
var imageResult = await imageClient.TryGenerateImageAsync(
    "A serene landscape with mountains and a lake at sunset");

if (imageResult.IsSuccess(out var image))
{
    Console.WriteLine($"Generated image URL: {image.ImageUri}");
}

// Generate multiple images
var imagesResult = await imageClient.TryGenerateImagesAsync(
    "A cute cat wearing a hat", imageCount: 2);

if (imagesResult.IsSuccess(out var images))
{
    foreach (var generatedImage in images)
    {
        Console.WriteLine($"Image URL: {generatedImage.ImageUri}");
    }
}
```

#### Audio Processing

```csharp
using OpenAI.Audio;
using LightResults.Extensions.OpenAI;

var audioClient = new AudioClient("whisper-1", apiKey);

// Transcribe audio
var audioData = File.ReadAllBytes("audio.mp3");
var transcriptionResult = await audioClient.TryTranscribeAudioAsync(audioData, "audio.mp3");
if (transcriptionResult.IsSuccess(out var transcription))
{
    Console.WriteLine($"Transcription: {transcription.Text}");
}

// Generate speech
var speechClient = new AudioClient("tts-1", apiKey);
var speechResult = await speechClient.TryGenerateSpeechAsync("Hello, world!", GeneratedSpeechVoice.Alloy);
if (speechResult.IsSuccess(out var speechData))
{
    await File.WriteAllBytesAsync("output.mp3", speechData.ToArray());
}
```

#### File Operations

```csharp
using OpenAI.Files;
using LightResults.Extensions.OpenAI;

var fileClient = new OpenAIFileClient(apiKey);

// Upload file
var fileData = File.ReadAllBytes("document.txt");
var uploadResult = await fileClient.TryUploadFileAsync(fileData, "document.txt", FileUploadPurpose.Assistants);
if (uploadResult.IsSuccess(out var uploadedFile))
{
    Console.WriteLine($"Uploaded file ID: {uploadedFile.Id}");
}

// List files
var filesResult = await fileClient.TryGetFilesAsync();
if (filesResult.IsSuccess(out var files))
{
    foreach (var file in files)
    {
        Console.WriteLine($"File: {file.Filename} (ID: {file.Id})");
    }
}
```

### Error Handling

All extension methods wrap operations in a `try { } catch { }` block and return `Result<T>` types for safe error handling:

```csharp
var result = await client.TryCompleteChatAsync("Hello!");
if (result.IsFailure(out var error))
{
    var ex = error.Exception;

    // Handle specific exception types
    if (ex is ClientResultException clientException)
    {
        Console.WriteLine($"API Error: {clientException.Message}");
    }
    else if (ex is TaskCanceledException)
    {
        Console.WriteLine("Request was cancelled");
    }
    else
    {
        Console.WriteLine($"Unexpected error: {ex?.Message ?? error.Message}");
    }
}
```

### Getting the Exception

```csharp
var result = await client.TryCompleteChatAsync("Hello!");
if (result.IsFailure(out var error))
{
    var ex = error.Exception;
    // Do something with the base exception type or...

    if (ex is ClientResultException clientResultException)
    {
        // Handle OpenAI-specific errors
        Console.WriteLine($"OpenAI API Error: {clientResultException.Message}");
    }
}
```
