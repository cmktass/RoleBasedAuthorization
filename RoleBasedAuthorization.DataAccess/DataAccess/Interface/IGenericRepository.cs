using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoleBasedAuthorization.DataAccess.DataAccess.Interface
{
    public interface IGenericRepository<TEntity> where TEntity: class,new()
    {
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
