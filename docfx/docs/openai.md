# OpenAI

Provides extension methods that wrap OpenAI operations using LightResults.

The package targets OpenAI `v2.9.0` and provides `Try*` wrappers for all public methods on all OpenAI clients.

### Supported clients

- `AssistantClient`
- `AudioClient`
- `BatchClient`
- `ChatClient`
- `ContainerClient`
- `ConversationClient`
- `EmbeddingClient`
- `EvaluationClient`
- `FineTuningClient`
- `GraderClient`
- `ImageClient`
- `ModerationClient`
- `OpenAIClient`
- `OpenAIFileClient`
- `OpenAIModelClient`
- `RealtimeClient`
- `RealtimeSessionClient`
- `ResponsesClient`
- `VectorStoreClient`
- `VideoClient`

### Chat Completions example

```csharp
using OpenAI.Chat;
using LightResults.Extensions.OpenAI;

var client = new ChatClient("gpt-4.1", apiKey);

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
### Image Generation example

```csharp
using OpenAI.Images;
using LightResults.Extensions.OpenAI;

var imageClient = new ImageClient("gpt-4.1-image", apiKey);

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
