using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ExampleContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ExampleContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> FindAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> FindById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) =>
            DbSet.FirstOrDefaultAsync(predicate);

        public async Task Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
