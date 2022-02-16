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
    public class CategoryRepository : Repository<DotNetExpert.Lead.Data.Entity.Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }

		public override async Task<int> CountAsync(string search)
		{
			return await context.Categories.Where(x => x.Name.ToLower().Contains(search.ToLower())).CountAsync();
		}

		public override async Task<IEnumerable<Category>> SearchAsync(string search, int skip, int limit)
		{
			var categories = context.Categories.Where(x => x.Name.ToLower().Contains(search.ToLower())).Skip(skip).Take(limit);
			return await categories.ToListAsync();
		}
	}
}
