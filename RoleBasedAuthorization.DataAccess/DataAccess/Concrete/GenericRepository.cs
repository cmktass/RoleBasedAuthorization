using Microsoft.EntityFrameworkCore;
using RoleBasedAuthorization.DataAccess.DataAccess.Context;
using RoleBasedAuthorization.DataAccess.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoleBasedAuthorization.DataAccess.DataAccess.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity:class ,new()
    {
        private readonly AuthContext _authContext;

        public GenericRepository()
        {
            this._authContext = new AuthContext();
        }

        public async Task AddAsync(TEntity entity)
        {
            await this._authContext.Set<TEntity>().AddAsync(entity);
            await this._authContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await this._authContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await this._authContext.Set<TEntity>().FindAsync(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            this._authContext.Set<TEntity>().Remove(entity);
            await this._authContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            this._authContext.Set<TEntity>().Update(entity);
            await this._authContext.SaveChangesAsync();
        }
    }
}
