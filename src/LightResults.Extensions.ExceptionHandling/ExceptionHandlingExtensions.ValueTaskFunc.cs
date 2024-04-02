namespace LightResults.Extensions.ExceptionHandling;

public static partial class ExceptionHandlingExtensions
{
    /// <summary>Attempts to execute a func and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <param name="func">The func to attempt.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result> TryAsync(this Func<ValueTask> func)
    {
        return ExceptionHandler.TryAsync(func);
    }

    /// <summary>Attempts to execute a func and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <param name="func">The func to attempt.</param>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<TResult>(this Func<ValueTask<TResult>> func)
    {
        return ExceptionHandler.TryAsync(func);
    }

    /// <summary>Attempts to execute a func with a single argument and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, TResult>(this Func<T1, ValueTask<TResult>> func, T1 arg1)
    {
        return ExceptionHandler.TryAsync(func, arg1);
    }

    /// <summary>Attempts to execute a func with two arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, TResult>(this Func<T1, T2, ValueTask<TResult>> func, T1 arg1, T2 arg2)
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2);
    }

    /// <summary>Attempts to execute a func with three arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, T3, TResult>(this Func<T1, T2, T3, ValueTask<TResult>> func, T1 arg1, T2 arg2, T3 arg3)
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2, arg3);
    }

    /// <summary>Attempts to execute a func with four arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, T3, T4, TResult>(
        this Func<T1, T2, T3, T4, ValueTask<TResult>> func,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4
    )
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2, arg3, arg4);
    }

    /// <summary>Attempts to execute a func with five arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, T3, T4, T5, TResult>(
        this Func<T1, T2, T3, T4, T5, ValueTask<TResult>> func,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5
    )
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2, arg3, arg4, arg5);
    }

    /// <summary>Attempts to execute a func with six arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, T3, T4, T5, T6, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, ValueTask<TResult>> func,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6
    )
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2, arg3, arg4, arg5, arg6);
    }

    /// <summary>Attempts to execute a func with seven arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, T3, T4, T5, T6, T7, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, ValueTask<TResult>> func,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7
    )
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }

    /// <summary>Attempts to execute a func with eight arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, ValueTask<TResult>> func,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8
    )
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
    }

    /// <summary>Attempts to execute a func with nine arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <param name="arg9">The ninth argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, ValueTask<TResult>> func,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9
    )
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
    }

    /// <summary>Attempts to execute a func with ten arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <typeparam name="T10">The type of the tenth argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <param name="arg9">The ninth argument.</param>
    /// <param name="arg10">The tenth argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, ValueTask<TResult>> func,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10
    )
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
    }

    /// <summary>Attempts to execute a func with eleven arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <typeparam name="T10">The type of the tenth argument.</typeparam>
    /// <typeparam name="T11">The type of the eleventh argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <param name="arg9">The ninth argument.</param>
    /// <param name="arg10">The tenth argument.</param>
    /// <param name="arg11">The eleventh argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, ValueTask<TResult>> func,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11
    )
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
    }

    /// <summary>Attempts to execute a func with twelve arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <typeparam name="T10">The type of the tenth argument.</typeparam>
    /// <typeparam name="T11">The type of the eleventh argument.</typeparam>
    /// <typeparam name="T12">The type of the twelfth argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <param name="arg9">The ninth argument.</param>
    /// <param name="arg10">The tenth argument.</param>
    /// <param name="arg11">The eleventh argument.</param>
    /// <param name="arg12">The twelfth argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, ValueTask<TResult>> func,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12
    )
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
    }

    /// <summary>Attempts to execute a func with thirteen arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <typeparam name="T10">The type of the tenth argument.</typeparam>
    /// <typeparam name="T11">The type of the eleventh argument.</typeparam>
    /// <typeparam name="T12">The type of the twelfth argument.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <param name="arg9">The ninth argument.</param>
    /// <param name="arg10">The tenth argument.</param>
    /// <param name="arg11">The eleventh argument.</param>
    /// <param name="arg12">The twelfth argument.</param>
    /// <param name="arg13">The thirteenth argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, ValueTask<TResult>> func,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13
    )
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
    }

    /// <summary>Attempts to execute a func with fourteen arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <typeparam name="T10">The type of the tenth argument.</typeparam>
    /// <typeparam name="T11">The type of the eleventh argument.</typeparam>
    /// <typeparam name="T12">The type of the twelfth argument.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth argument.</typeparam>
    /// <typeparam name="T14">The type of the fourteenth argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <param name="arg9">The ninth argument.</param>
    /// <param name="arg10">The tenth argument.</param>
    /// <param name="arg11">The eleventh argument.</param>
    /// <param name="arg12">The twelfth argument.</param>
    /// <param name="arg13">The thirteenth argument.</param>
    /// <param name="arg14">The fourteenth argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, ValueTask<TResult>> func,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13,
        T14 arg14
    )
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
    }

    /// <summary>Attempts to execute a func with 15 arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <typeparam name="T10">The type of the tenth argument.</typeparam>
    /// <typeparam name="T11">The type of the eleventh argument.</typeparam>
    /// <typeparam name="T12">The type of the twelfth argument.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth argument.</typeparam>
    /// <typeparam name="T14">The type of the fourteenth argument.</typeparam>
    /// <typeparam name="T15">The type of the fifteenth argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <param name="arg9">The ninth argument.</param>
    /// <param name="arg10">The tenth argument.</param>
    /// <param name="arg11">The eleventh argument.</param>
    /// <param name="arg12">The twelfth argument.</param>
    /// <param name="arg13">The thirteenth argument.</param>
    /// <param name="arg14">The fourteenth argument.</param>
    /// <param name="arg15">The fifteenth argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, ValueTask<TResult>> func,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13,
        T14 arg14,
        T15 arg15
    )
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
    }

    /// <summary>Attempts to execute a func with sixteen arguments and returns a <see cref="ValueTask{Result}"/> indicating success or failure.
    /// <remarks>If an exception occurs, it is captured and converted to an error.</remarks>
    /// </summary>
    /// <typeparam name="T1">The type of the first argument.</typeparam>
    /// <typeparam name="T2">The type of the second argument.</typeparam>
    /// <typeparam name="T3">The type of the third argument.</typeparam>
    /// <typeparam name="T4">The type of the fourth argument.</typeparam>
    /// <typeparam name="T5">The type of the fifth argument.</typeparam>
    /// <typeparam name="T6">The type of the sixth argument.</typeparam>
    /// <typeparam name="T7">The type of the seventh argument.</typeparam>
    /// <typeparam name="T8">The type of the eighth argument.</typeparam>
    /// <typeparam name="T9">The type of the ninth argument.</typeparam>
    /// <typeparam name="T10">The type of the tenth argument.</typeparam>
    /// <typeparam name="T11">The type of the eleventh argument.</typeparam>
    /// <typeparam name="T12">The type of the twelfth argument.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth argument.</typeparam>
    /// <typeparam name="T14">The type of the fourteenth argument.</typeparam>
    /// <typeparam name="T15">The type of the fifteenth argument.</typeparam>
    /// <typeparam name="T16">The type of the sixteenth argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="func">The func to attempt.</param>
    /// <param name="arg1">The first argument.</param>
    /// <param name="arg2">The second argument.</param>
    /// <param name="arg3">The third argument.</param>
    /// <param name="arg4">The fourth argument.</param>
    /// <param name="arg5">The fifth argument.</param>
    /// <param name="arg6">The sixth argument.</param>
    /// <param name="arg7">The seventh argument.</param>
    /// <param name="arg8">The eighth argument.</param>
    /// <param name="arg9">The ninth argument.</param>
    /// <param name="arg10">The tenth argument.</param>
    /// <param name="arg11">The eleventh argument.</param>
    /// <param name="arg12">The twelfth argument.</param>
    /// <param name="arg13">The thirteenth argument.</param>
    /// <param name="arg14">The fourteenth argument.</param>
    /// <param name="arg15">The fifteenth argument.</param>
    /// <param name="arg16">The sixteenth argument.</param>
    /// <returns>A <see cref="ValueTask{Result}"/> indicating success or failure.</returns>
    public static ValueTask<Result<TResult>> TryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, ValueTask<TResult>> func,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        T5 arg5,
        T6 arg6,
        T7 arg7,
        T8 arg8,
        T9 arg9,
        T10 arg10,
        T11 arg11,
        T12 arg12,
        T13 arg13,
        T14 arg14,
        T15 arg15,
        T16 arg16
    )
    {
        return ExceptionHandler.TryAsync(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
    }
}
