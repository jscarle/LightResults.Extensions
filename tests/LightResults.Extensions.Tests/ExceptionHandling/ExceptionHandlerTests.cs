using Shouldly;
using LightResults.Extensions.ExceptionHandling;
using Xunit;

namespace LightResults.Extensions.Tests.ExceptionHandling;

public sealed class ExceptionHandlerTests
{
    [Fact]
    public void Try_ActionSucceeds_ShouldReturnSuccessResult()
    {
        // Arrange
        var executed = false;
        void Action() => executed = true;

        // Act
        var result = ExceptionHandler.Try(Action);

        // Assert
        result.IsSuccess().ShouldBeTrue();
        executed.ShouldBeTrue();
    }

    [Fact]
    public void Try_ActionThrowsException_ShouldReturnFailureResultWithException()
    {
        // Arrange
        const string errorMessage = "Test exception";
        void Action() => throw new InvalidOperationException(errorMessage);

        // Act
        var result = ExceptionHandler.Try(Action);

        // Assert
        result.IsSuccess().ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        var error = result.Errors.First();
        error.Message.ShouldBe($"InvalidOperationException: {errorMessage}");
        error.Metadata.ContainsKey("Exception").ShouldBeTrue();
        error.Metadata["Exception"].ShouldBeOfType<InvalidOperationException>();
    }

    [Fact]
    public void Try_ActionWithArguments_ShouldExecuteSuccessfully()
    {
        // Arrange
        var receivedValue = 0;
        void Action(int value) => receivedValue = value;
        const int expectedValue = 42;

        // Act
        var result = ExceptionHandler.Try(Action, expectedValue);

        // Assert
        result.IsSuccess().ShouldBeTrue();
        receivedValue.ShouldBe(expectedValue);
    }

    [Fact]
    public void Try_FuncSucceeds_ShouldReturnSuccessResultWithValue()
    {
        // Arrange
        const int expectedValue = 42;
        int Func() => expectedValue;

        // Act
        var result = ExceptionHandler.Try((Func<int>)Func);

        // Assert
        result.IsSuccess(out var value).ShouldBeTrue();
        value.ShouldBe(expectedValue);
    }

    [Fact]
    public void Try_FuncThrowsException_ShouldReturnFailureResult()
    {
        // Arrange
        const string errorMessage = "Test exception";
        int Func() => throw new ArgumentException(errorMessage);

        // Act
        var result = ExceptionHandler.Try((Func<int>)Func);

        // Assert
        result.IsSuccess().ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        var error = result.Errors.First();
        error.Message.ShouldBe($"ArgumentException: {errorMessage}");
        error.Metadata.ContainsKey("Exception").ShouldBeTrue();
        error.Metadata["Exception"].ShouldBeOfType<ArgumentException>();
    }

    [Fact]
    public void Try_FuncWithArguments_ShouldReturnCorrectValue()
    {
        // Arrange
        string Func(int intValue) => intValue.ToString();

        // Act
        var result = ExceptionHandler.Try((Func<int, string>)Func, 42);

        // Assert
        result.IsSuccess(out var value).ShouldBeTrue();
        value.ShouldBe("42");
    }

    [Fact]
    public void Try_DifferentExceptionTypes_ShouldCaptureCorrectExceptionInfo()
    {
        // Test different exception types
        var exceptions = new Exception[]
        {
            new ArgumentException("Invalid argument"),
            new InvalidOperationException("Invalid operation"),
            new NotSupportedException("Not supported")
        };

        foreach (var exception in exceptions)
        {
            // Arrange
            void Action() => throw exception;

            // Act
            var result = ExceptionHandler.Try(Action);

            // Assert
            result.IsSuccess().ShouldBeFalse();
            var error = result.Errors.First();
            error.Message.ShouldStartWith(exception.GetType().Name);
            error.Metadata["Exception"].ShouldBe(exception);
        }
    }

    [Fact]
    public void Try_ExceptionWithInnerException_ShouldCaptureOuterException()
    {
        // Arrange
        var innerException = new ArgumentException("Inner exception");
        var outerException = new InvalidOperationException("Outer exception", innerException);
        void Action() => throw outerException;

        // Act
        var result = ExceptionHandler.Try(Action);

        // Assert
        result.IsSuccess().ShouldBeFalse();
        var error = result.Errors.First();
        error.Message.ShouldBe("InvalidOperationException: Outer exception");
        error.Metadata["Exception"].ShouldBe(outerException);
    }

    [Fact]
    public async Task TryAsync_TaskSucceeds_ShouldReturnSuccessResult()
    {
        // Arrange
        var executed = false;
        var task = Task.Run(() => executed = true);

        // Act
        var result = await ExceptionHandler.TryAsync(task);

        // Assert
        result.IsSuccess().ShouldBeTrue();
        executed.ShouldBeTrue();
    }

    [Fact]
    public async Task TryAsync_TaskThrowsException_ShouldReturnFailureResult()
    {
        // Arrange
        const string errorMessage = "Async test exception";
        var task = Task.FromException(new InvalidOperationException(errorMessage));

        // Act
        var result = await ExceptionHandler.TryAsync(task);

        // Assert
        result.IsSuccess().ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        var error = result.Errors.First();
        error.Message.ShouldBe($"InvalidOperationException: {errorMessage}");
        error.Metadata.ContainsKey("Exception").ShouldBeTrue();
        error.Metadata["Exception"].ShouldBeOfType<InvalidOperationException>();
    }

    [Fact]
    public async Task TryAsync_TaskWithResult_ShouldReturnSuccessResultWithValue()
    {
        // Arrange
        const int expectedValue = 42;
        var task = Task.FromResult(expectedValue);

        // Act
        var result = await ExceptionHandler.TryAsync(task);

        // Assert
        result.IsSuccess(out var value).ShouldBeTrue();
        value.ShouldBe(expectedValue);
    }

    [Fact]
    public async Task TryAsync_TaskWithResultThrowsException_ShouldReturnFailureResult()
    {
        // Arrange
        const string errorMessage = "Task result exception";
        var task = Task.FromException<int>(new ArgumentException(errorMessage));

        // Act
        var result = await ExceptionHandler.TryAsync(task);

        // Assert
        result.IsSuccess().ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        var error = result.Errors.First();
        error.Message.ShouldBe($"ArgumentException: {errorMessage}");
        error.Metadata["Exception"].ShouldBeOfType<ArgumentException>();
    }

    [Fact]
    public async Task TryAsync_ValueTaskSucceeds_ShouldReturnSuccessResult()
    {
        // Arrange
        var executed = false;
        var valueTask = new ValueTask(Task.Run(() => executed = true));

        // Act
        var result = await ExceptionHandler.TryAsync(valueTask);

        // Assert
        result.IsSuccess().ShouldBeTrue();
        executed.ShouldBeTrue();
    }

    [Fact]
    public async Task TryAsync_ValueTaskWithResult_ShouldReturnSuccessResultWithValue()
    {
        // Arrange
        const string expectedValue = "Hello ValueTask";
        var valueTask = new ValueTask<string>(expectedValue);

        // Act
        var result = await ExceptionHandler.TryAsync(valueTask);

        // Assert
        result.IsSuccess(out var value).ShouldBeTrue();
        value.ShouldBe(expectedValue);
    }
}
