﻿using Microsoft.EntityFrameworkCore;
using SampleZoo.DataLayer.Context;
using SampleZoo.Domain.Entities.Common;
using SampleZoo.Domain.IRepository;

namespace SampleZoo.DataLayer.Repository
{
    /// <summary>
    /// read /write repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class CrudRepository<TEntity, TKey> :
          IWriteRepository<TEntity, TKey>
        , IReadRepository<TEntity, TKey>
        , IDeleteRepository<TEntity, TKey>
        where TEntity : EntityId<TKey>, IAggregateRoot
        where TKey : struct
    {
        public required SampleZooDbContext _dbContext { protected get; init; }

        public async Task Add(TEntity entity)
        => await this._dbContext.AddAsync(entity);

        public void Update(TEntity entity)
        => _dbContext.Update(entity);

        public virtual async Task<TEntity?> GetAsTracking(TKey id)
        => await _dbContext.Set<TEntity>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));

        public virtual async Task<TEntity?> GetAsNoTracking(TKey id)
        => await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));

        public async Task<IEnumerable<TEntity>> GetList(int skip = 0, int take = 10)
        => await _dbContext.Set<TEntity>().AsNoTracking().OrderByDescending(t => t.Id).Skip(skip * take).Take(take).ToListAsync();

        public IQueryable<TEntity> GetQuerable()
       => _dbContext.Set<TEntity>().AsNoTracking().OrderByDescending(x => x.Id).AsQueryable();

        public async Task Delete(TKey key)
        {
            TEntity? value = await GetAsTracking(key);
            if (value is not null)
                _dbContext.Remove(value);
        }

        public void Delete(TEntity entity)
        => _dbContext.Remove(entity);

        public void Dispose()
        => _dbContext.Dispose();

        public async ValueTask DisposeAsync()
        => await _dbContext.DisposeAsync();

        public async Task SaveChanges()
        => await _dbContext.SaveChangesAsync();
    }
}
