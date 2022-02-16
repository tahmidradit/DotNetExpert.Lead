using DotNetExpert.Lead.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ILeadsRepository Leads { get; }

        int Commit();
        Task<int> CommitAsync();
    }
}
