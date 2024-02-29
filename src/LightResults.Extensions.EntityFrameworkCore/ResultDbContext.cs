using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LightResults.Extensions.EntityFrameworkCore;

/// <inheritdoc cref="DbContext" />
public class ResultDbContext : DbContext
{
    private const string ExceptionKey = "Exception";

    /// <inheritdoc cref="DbContext()" />
    public ResultDbContext()
    {
    }

    /// <inheritdoc cref="DbContext(DbContextOptions)" />
    public ResultDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <inheritdoc cref="DbContext.AddAsync(object, CancellationToken)" />
    public new async ValueTask<Result<EntityEntry>> AddAsync(object entity, CancellationToken cancellationToken = new())
    {
        try
        {
            var result = await base.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            return Result<EntityEntry>.Ok(result);
        }
        catch (Exception ex)
        {
            return HandleException<EntityEntry>(ex);
        }
    }

    /// <inheritdoc cref="DbContext.AddAsync{TEntity}(TEntity, CancellationToken)" />
    public new async ValueTask<Result<EntityEntry<TEntity>>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = new()) where TEntity : class
    {
        try
        {
            var result = await base.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            return Result<EntityEntry<TEntity>>.Ok(result);
        }
        catch (Exception ex)
        {
            return HandleException<EntityEntry<TEntity>>(ex);
        }
    }

    /// <inheritdoc cref="DbContext.AddRangeAsync(IEnumerable{object}, CancellationToken)" />
    public new async Task<Result> AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = new())
    {
        try
        {
            await base.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return HandleException(ex);
        }
    }

    /// <inheritdoc cref="DbContext.AddRangeAsync(object[])" />
    public new async Task<Result> AddRangeAsync(params object[] entities)
    {
        try
        {
            await base.AddRangeAsync(entities).ConfigureAwait(false);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return HandleException(ex);
        }
    }

    /// <inheritdoc cref="DbContext.Find(Type, object?[])" />
    public new Result<object?> Find(Type entityType, params object?[]? keyValues)
    {
        try
        {
            var result = base.Find(entityType, keyValues);
            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            return HandleException<object?>(ex);
        }
    }

    /// <inheritdoc cref="DbContext.Find{TEntity}(object?[])" />
    public new Result<TEntity?> Find<TEntity>(params object?[]? keyValues) where TEntity : class
    {
        try
        {
            var result = base.Find<TEntity>(keyValues);
            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            return HandleException<TEntity?>(ex);
        }
    }

    /// <inheritdoc cref="DbContext.FindAsync(Type, object?[])" />
    public new async ValueTask<Result<object?>> FindAsync(Type entityType, params object?[]? keyValues)
    {
        try
        {
            var result = await base.FindAsync(entityType, keyValues).ConfigureAwait(false);
            return Result<object?>.Ok(result);
        }
        catch (Exception ex)
        {
            return HandleException<object?>(ex);
        }
    }

    /// <inheritdoc cref="DbContext.FindAsync(Type, object?[], CancellationToken)" />
    public new async ValueTask<Result<object?>> FindAsync(Type entityType, object?[]? keyValues, CancellationToken cancellationToken)
    {
        try
        {
            var result = await base.FindAsync(entityType, keyValues, cancellationToken).ConfigureAwait(false);
            return Result<object?>.Ok(result);
        }
        catch (Exception ex)
        {
            return HandleException<object?>(ex);
        }
    }

    /// <inheritdoc cref="DbContext.FindAsync{TEntity}(object?[], CancellationToken)" />
    public new async ValueTask<Result<TEntity?>> FindAsync<TEntity>(object?[]? keyValues, CancellationToken cancellationToken) where TEntity : class
    {
        try
        {
            var result = await base.FindAsync<TEntity>(keyValues, cancellationToken).ConfigureAwait(false);
            return Result<TEntity?>.Ok(result);
        }
        catch (Exception ex)
        {
            return HandleException<TEntity?>(ex);
        }
    }

    /// <inheritdoc cref="DbContext.FindAsync{TEntity}(object?[])" />
    public new async ValueTask<Result<TEntity?>> FindAsync<TEntity>(params object?[]? keyValues) where TEntity : class
    {
        try
        {
            var result = await base.FindAsync<TEntity>(keyValues).ConfigureAwait(false);
            return Result<TEntity?>.Ok(result);
        }
        catch (Exception ex)
        {
            return HandleException<TEntity?>(ex);
        }
    }

    /// <inheritdoc cref="DbContext.SaveChanges()" />
    public new Result<int> SaveChanges()
    {
        try
        {
            var result = base.SaveChanges();
            return Result<int>.Ok(result);
        }
        catch (Exception ex)
        {
            return HandleException<int>(ex);
        }
    }

    /// <inheritdoc cref="DbContext.SaveChanges(bool)" />
    public new Result<int> SaveChanges(bool acceptAllChangesOnSuccess)
    {
        try
        {
            var result = base.SaveChanges(acceptAllChangesOnSuccess);
            return Result<int>.Ok(result);
        }
        catch (Exception ex)
        {
            return HandleException<int>(ex);
        }
    }

    /// <inheritdoc cref="DbContext.SaveChangesAsync(CancellationToken)" />
    public new async Task<Result<int>> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return Result<int>.Ok(result);
        }
        catch (Exception ex)
        {
            return HandleException<int>(ex);
        }
    }

    /// <inheritdoc cref="DbContext.SaveChangesAsync(bool, CancellationToken)" />
    public new async Task<Result<int>> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new())
    {
        try
        {
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken).ConfigureAwait(false);
            return Result<int>.Ok(result);
        }
        catch (Exception ex)
        {
            return HandleException<int>(ex);
        }
    }

    private static Result HandleException(Exception ex)
    {
        var error = GetExceptionError(ex);
        return Result.Fail(error);
    }

    private static Result<TResult> HandleException<TResult>(Exception ex)
    {
        var error = GetExceptionError(ex);
        return Result<TResult>.Fail(error);
    }

    private static Error GetExceptionError(Exception ex)
    {
        var message = GetExceptionMessage(ex);
        var error = new Error(message, (ExceptionKey, ex));
        return error;
    }

    private static string GetExceptionMessage(Exception ex)
    {
        return $"{ex.GetType().Name}: {ex.Message}";
    }
}
