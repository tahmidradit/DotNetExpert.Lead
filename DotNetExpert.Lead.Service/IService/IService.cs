using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.Service.IService
{
    public interface IService<TEntity> where TEntity : class
    {
        int Insert(TEntity viewModel);
        void Update(TEntity viewModel);
        void Delete(TEntity viewModel);
        void Delete(int id);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(int skip, int limit);


        Task<int> InsertAsync(TEntity viewModel);
        Task UpdateAsync(TEntity viewModel);
        Task DeleteAsync(TEntity viewModel);
        Task DeleteAsync(int id);
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(int skip, int limit);
        Task<IEnumerable<TEntity>> SearchAsync(string search, int skip, int limit);
        Task<int> CountAsync();
        Task<int> CountAsync(string search);
    }
}
