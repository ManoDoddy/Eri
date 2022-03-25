﻿using System.Linq.Expressions;

namespace Eri.MongoDB.Interfaces;

public interface IDbSet<TEntity, TId> 
    where TEntity : IEntity<TId> 
    where TId : IComparable<TId>, IEquatable<TId>
{
    IQueryable<TEntity> AsQueryable();

    IEnumerable<TEntity> FilterBy(
        Expression<Func<TEntity, bool>> filterExpression);

    IEnumerable<TProjected> FilterBy<TProjected>(
        Expression<Func<TEntity, bool>> filterExpression,
        Expression<Func<TEntity, TProjected>> projectionExpression);

    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filterExpression);

    Task<TEntity> FindByIdAsync(TId id);

    Task InsertAsync(TEntity document);

    Task InsertAsync(IEnumerable<TEntity> documents);

    Task ReplaceAsync(TEntity document);

    Task ReplaceAsync(IEnumerable<TEntity> documents);

    Task DeleteWhereAsync(Expression<Func<TEntity, bool>> filterExpression);

    Task DeleteAsync(TId id);

    Task DeleteAsync(IEnumerable<TId> ids);
}