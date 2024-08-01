using Microsoft.EntityFrameworkCore;
using HealthMed.Domain.Interfaces.Infra.Data;
using HealthMed.Infra.Data.Context;
using System;

namespace HealthMed.Infra.Data.Configuration
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly HealthMedContext _dbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(HealthMedContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void AddList(List<TEntity> objs)
        {
            DbSet.AddRange(objs);
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
