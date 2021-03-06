﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HLInsuranceManagementApp.Infrastructure.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        List<TEntity> GetAll();

        Task<int> Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
