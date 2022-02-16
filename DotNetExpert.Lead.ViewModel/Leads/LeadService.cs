using DotNetExpert.Lead.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.ViewModel.Leads
{
    public class LeadService
    {
        private readonly AppDbContext context;

        public LeadService(AppDbContext context)
        {
            this.context = context;
        }

        public List<DotNetExpert.Lead.Data.Entity.Category> RenderCategories()
        {
            return context.Categories.ToList();
        }
    }
}
