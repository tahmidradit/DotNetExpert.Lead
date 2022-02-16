using DotNetExpert.Lead.Repository.Data;
using DotNetExpert.Lead.Repository.IRepository;
using DotNetExpert.Lead.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.Repository.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

		private ICategoryRepository _categoryRepository;
		private ILeadsRepository _leadsRepository;

        public ICategoryRepository Category => _categoryRepository = _categoryRepository ?? new CategoryRepository(context);
        public ILeadsRepository Leads => _leadsRepository = _leadsRepository ?? new LeadsRepository(context);

		public int Commit()
		{
			return context.SaveChanges();
		}

		public async Task<int> CommitAsync()
		{
			return await context.SaveChangesAsync();
		}

		private bool disposed;
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void Dispose(bool disposing)
		{

			if (!disposed)
				if (disposing)

					context.Dispose();

			disposed = true;
		}
	}
}
