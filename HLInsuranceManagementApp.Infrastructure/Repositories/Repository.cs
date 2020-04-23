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

        /// <summary>
        /// Add dynamic entity to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Add(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);

            await Context.SaveChangesAsync();

            return Convert.ToInt32(entity.GetType().GetProperty("Id").GetValue(entity)); ;
        }

        /// <summary>
        /// Add collection of entities to database
        /// </summary>
        /// <param name="entities"></param>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
            Context.SaveChanges();
        }

        /// <summary>
        /// Get entity from db using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Get all entity values from db
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetAll()
        {
            var query = Context.Set<TEntity>().AsQueryable();

            foreach (var property in Context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);

            return query.AsNoTracking().ToList();
        }

        /// <summary>
        /// Delete entity from db
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Remove collection of entities from db
        /// </summary>
        /// <param name="entities"></param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
