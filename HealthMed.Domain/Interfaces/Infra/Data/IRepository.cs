﻿using System;

namespace HealthMed.Domain.Interfaces.Infra.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        void AddList(List<TEntity> obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
