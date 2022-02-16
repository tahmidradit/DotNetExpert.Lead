using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.ViewModel.Leads
{
    public class LeadsViewModel : BaseViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DotNetExpert.Lead.Data.Entity.Category Category { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public bool IsForMaterial { get; set; }

    }
}
