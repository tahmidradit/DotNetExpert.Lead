using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.Data.Entity
{
    public class AppUser : IdentityUser
    {
		public int Number { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public int DepartmentId { get; set; }

		[ForeignKey("DepartmentId")]
		public virtual Department Department { get; set; }
	}
}
