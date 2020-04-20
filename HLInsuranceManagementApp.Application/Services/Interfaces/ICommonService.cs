using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HLInsuranceManagementApp.Application.Services.Interfaces
{
    public interface ICommonService<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        List<TEntity> GetAll();

        Task<int> Add(TEntity entity);
        void AddRange(List<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(List<TEntity> entities);
    }
}
