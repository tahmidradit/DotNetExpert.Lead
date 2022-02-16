using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.Repository.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        ValueTask<TEntity> GetByIdAsync(int id);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> GetAll(int skip, int limit);
        Task<IEnumerable<TEntity>> GetAllAsync(int skip, int limit);
        Task<IEnumerable<TEntity>> SearchAsync(string search, int skip, int limit);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        int Insert(TEntity entity);
        Task<int> InsertAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Remove(int id);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entity);
        Task<int> CountAsync();
        Task<int> CountAsync(string search);
    }
}
