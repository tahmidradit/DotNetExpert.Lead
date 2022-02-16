using DotNetExpert.Lead.Repository.Data;
using DotNetExpert.Lead.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.Repository.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int Insert(TEntity entity)
        {
            int id = 0;
            try
            {
                this.context.Set<TEntity>().Add(entity);
                this.context.SaveChanges();

                id = (int)entity.GetType().GetProperty("Id").GetValue(entity, null);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException.InnerException.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.ToUpper().Contains("VIOLATION OF UNIQUE KEY"))
                {
                    throw new Exception("Duplicate unique key");
                }
                else
                {
                    throw new Exception("OTHER ERROR " + ex.Message);
                }
            }

            return id;
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            int id = 0;
            try
            {
                await this.context.Set<TEntity>().AddAsync(entity);
                await this.context.SaveChangesAsync();

                id = (int)entity.GetType().GetProperty("Id").GetValue(entity, null);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException.InnerException.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.ToUpper().Contains("VIOLATION OF UNIQUE KEY"))
                {
                    throw new Exception("Duplicate unique key");
                }
                else
                {
                    throw new Exception("OTHER ERROR " + ex.Message);
                }
            }

            return id;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.context.Set<TEntity>().ToListAsync();
        }

        public TEntity GetById(int id)
        {
            return this.context.Set<TEntity>().Find(id);
        }

        public ValueTask<TEntity> GetByIdAsync(int id)
        {
            return this.context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            int id = (int)entity.GetType().GetProperty("Id").GetValue(entity, null);
            var entityLookup = this.context.Set<TEntity>().Find(id);
            if (entityLookup != null)
            {
                this.context.Set<TEntity>().Remove(entityLookup);
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.context.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return this.context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            try
            {
                var local = context.Set<TEntity>().Local
                    .FirstOrDefault(x => x.GetType().GetProperty("Id").Equals(entity.GetType().GetProperty("Id")));

                if (local != null)
                {
                    context.Entry(local).State = EntityState.Detached;
                }

                this.context.Entry(entity).State = EntityState.Modified;
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException.InnerException.Message);
            }
            catch (Exception ex)
            {
                //throw ex;
                throw new Exception(ex.InnerException.InnerException.Message);
            }
        }
        
        public async Task<IEnumerable<TEntity>> GetAllAsync(int skip, int limit)
        {
            return await this.context.Set<TEntity>().Skip(skip).Take(limit).ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await this.context.Set<TEntity>().CountAsync();
        }

        public virtual async Task<int> CountAsync(string search)
        {
            return await this.context.Set<TEntity>().CountAsync();
        }

        public virtual Task<IEnumerable<TEntity>> SearchAsync(string search, int skip, int limit)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll(int skip, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            int id = (int)entity.GetType().GetProperty("Id").GetValue(entity, null);
            var entityLookup = await this.context.Set<TEntity>().FindAsync(id);
            if (entityLookup != null)
            {
                this.context.Set<TEntity>().Remove(entityLookup);
            }
        }
    }
}
