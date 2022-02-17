using DotNetExpert.Lead.Data.Entity;
using DotNetExpert.Lead.Repository.Data;
using DotNetExpert.Lead.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.Repository.Repository
{
    public class LeadsRepository : Repository<DotNetExpert.Lead.Data.Entity.Leads>, ILeadsRepository
    {
		public LeadsRepository(ApplicationDbContext context) : base(context) { }

		public override async Task<int> CountAsync(string search)
		{
			return await context.Leads.Where(x => x.FirstName.ToLower().Contains(search.ToLower())).CountAsync();
		}

		public override async Task<IEnumerable<Leads>> SearchAsync(string search, int skip, int limit)
		{
			var leads = context.Leads.Where(x => x.FirstName.ToLower().Contains(search.ToLower())).Skip(skip).Take(limit);
			return await leads.ToListAsync();
		}
	}
}
