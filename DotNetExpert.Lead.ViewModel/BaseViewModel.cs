using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.ViewModel
{
    public class BaseViewModel
    {
		[Key]
		public int Id { get; set; }

		[Display(Name = "Date Created")]
		public DateTime DateCreated { get; set; }

		[Display(Name = "Date Updated")]
		public DateTime DateUpdated { get; set; }
		public string CreatedByUserId { get; set; }
		public string UpdatedByUserId { get; set; }
		public bool IsActive { get; set; }
	}
}
