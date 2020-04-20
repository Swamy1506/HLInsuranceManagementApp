using HLInsuranceManagementApp.Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLInsuranceManagementApp.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly HLIMDataContext Context;

        public Repository(HLIMDataContext context)
        {
            Context = context;
        }

        public async Task<int> Add(TEntity entity)
        {
            var newId = 0;
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();

             //entity.GetType().GetProperty("Id").SetValue(entity, newId);

            return newId;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);

        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
