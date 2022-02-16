using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.Data.Entity
{
    public class BaseEntity
    {
		[Key]
		public int Id { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateUpdated { get; set; }
		public string CreatedByUserId { get; set; }
		public string UpdatedByUserId { get; set; }
		public bool IsActive { get; set; }

		[ForeignKey("CreatedByUserId"), Column(Order = 0)]
        public virtual AppUser CreatedByUser { get; set; }
	}
}
