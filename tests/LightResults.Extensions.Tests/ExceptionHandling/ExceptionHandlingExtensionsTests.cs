using Shouldly;
using LightResults.Extensions.ExceptionHandling;
using Xunit;

namespace LightResults.Extensions.Tests.ExceptionHandling;

public sealed class ExceptionHandlingExtensionsTests
{
    [Fact]
    public void Try_ActionExtensionSucceeds_ShouldReturnSuccessResult()
    {
        // Arrange
        var executed = false;
        Action action = () => executed = true;

        // Act
        var result = action.Try();

        // Assert
        result.IsSuccess().ShouldBeTrue();
        executed.ShouldBeTrue();
    }

    [Fact]
    public void Try_ActionExtensionThrowsException_ShouldReturnFailureResult()
    {
        // Arrange
        const string errorMessage = "Extension test exception";
        Action action = () => throw new InvalidOperationException(errorMessage);

        // Act
        var result = action.Try();

        // Assert
        result.IsSuccess().ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        var error = result.Errors.First();
        error.Message.ShouldBe($"InvalidOperationException: {errorMessage}");
        error.Metadata.ContainsKey("Exception").ShouldBeTrue();
        error.Metadata["Exception"].ShouldBeOfType<InvalidOperationException>();
    }

    [Fact]
    public void Try_ActionWithArgumentsExtension_ShouldExecuteSuccessfully()
    {
        // Arrange
        var receivedValue = 0;
        Action<int> action = value => receivedValue = value;
        const int expectedValue = 99;

        // Act
        var result = action.Try(expectedValue);

        // Assert
        result.IsSuccess().ShouldBeTrue();
        receivedValue.ShouldBe(expectedValue);
    }

    [Fact]
    public void Try_FuncExtensionSucceeds_ShouldReturnSuccessResultWithValue()
    {
        // Arrange
        const string expectedValue = "Extension Result";
        var func = () => expectedValue;

        // Act
        var result = func.Try();

        // Assert
        result.IsSuccess(out var value).ShouldBeTrue();
        value.ShouldBe(expectedValue);
    }

    [Fact]
    public void Try_FuncExtensionThrowsException_ShouldReturnFailureResult()
    {
        // Arrange
        const string errorMessage = "Func extension exception";
        Func<int> func = () => throw new ArgumentException(errorMessage);

        // Act
        var result = func.Try();

        // Assert
        result.IsSuccess().ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        var error = result.Errors.First();
        error.Message.ShouldBe($"ArgumentException: {errorMessage}");
        error.Metadata["Exception"].ShouldBeOfType<ArgumentException>();
    }

    [Fact]
    public void Try_FuncWithArgumentsExtension_ShouldReturnCorrectValue()
    {
        // Arrange
        Func<int, double> func = intValue => Math.Sqrt(intValue);

        // Act
        var result = func.Try(16);

        // Assert
        result.IsSuccess(out var value).ShouldBeTrue();
        value.ShouldBe(4.0);
    }

    [Fact]
    public async Task TryAsync_TaskExtensionSucceeds_ShouldReturnSuccessResult()
    {
        // Arrange
        var executed = false;
        var task = Task.Run(() => executed = true);

        // Act
        var result = await task.TryAsync();

        // Assert
        result.IsSuccess().ShouldBeTrue();
        executed.ShouldBeTrue();
    }

    [Fact]
    public async Task TryAsync_TaskExtensionThrowsException_ShouldReturnFailureResult()
    {
        // Arrange
        const string errorMessage = "Task extension exception";
        var task = Task.FromException(new NotSupportedException(errorMessage));

        // Act
        var result = await task.TryAsync();

        // Assert
        result.IsSuccess().ShouldBeFalse();
        var error = result.Errors.First();
        error.Message.ShouldBe($"NotSupportedException: {errorMessage}");
        error.Metadata["Exception"].ShouldBeOfType<NotSupportedException>();
    }

    [Fact]
    public async Task TryAsync_TaskWithResultExtension_ShouldReturnSuccessResultWithValue()
    {
        // Arrange
        const bool expectedValue = true;
        var task = Task.FromResult(expectedValue);

        // Act
        var result = await task.TryAsync();

        // Assert
        result.IsSuccess(out var value).ShouldBeTrue();
        value.ShouldBe(expectedValue);
    }

    [Fact]
    public async Task TryAsync_ValueTaskExtensionSucceeds_ShouldReturnSuccessResult()
    {
        // Arrange
        var executed = false;
        var valueTask = new ValueTask(Task.Run(() => executed = true));

        // Act
        var result = await valueTask.TryAsync();

        // Assert
        result.IsSuccess().ShouldBeTrue();
        executed.ShouldBeTrue();
    }

    [Fact]
    public async Task TryAsync_ValueTaskWithResultExtension_ShouldReturnSuccessResultWithValue()
    {
        // Arrange
        var expectedValue = Guid.NewGuid();
        var valueTask = new ValueTask<Guid>(expectedValue);

        // Act
        var result = await valueTask.TryAsync();

        // Assert
        result.IsSuccess(out var value).ShouldBeTrue();
        value.ShouldBe(expectedValue);
    }

    [Fact]
    public void Try_ExtensionVsStaticMethod_ShouldProduceSameResult()
    {
        // Arrange
        const string errorMessage = "Consistency test";
        Action action = () => throw new InvalidOperationException(errorMessage);

        // Act
        var extensionResult = action.Try();
        var staticResult = ExceptionHandler.Try(action);

        // Assert
        extensionResult.IsSuccess().ShouldBe(staticResult.IsSuccess());
        extensionResult.Errors.Count.ShouldBe(staticResult.Errors.Count);

        var extensionError = extensionResult.Errors.First();
        var staticError = staticResult.Errors.First();
        extensionError.Message.ShouldBe(staticError.Message);
    }

    [Fact]
    public void Try_FuncExtensionVsStaticMethod_ShouldProduceSameResult()
    {
        // Arrange
        const int expectedValue = 123;
        var func = () => expectedValue;

        // Act
        var extensionResult = func.Try();
        var staticResult = ExceptionHandler.Try(func);

        // Assert
        extensionResult.IsSuccess().ShouldBe(staticResult.IsSuccess());
        extensionResult.IsSuccess(out var extValue).ShouldBeTrue();
        staticResult.IsSuccess(out var staticValue).ShouldBeTrue();
        extValue.ShouldBe(staticValue);
    }
}
