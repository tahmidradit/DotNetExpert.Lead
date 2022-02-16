using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.Data.Entity
{
    public class Category : BaseEntity
    {
        //[Key]
        //public int Id { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        //[Required, Display(Name = "Created By")]
        //public string CreatedByUserId { get; set; }

        //[Required, Display(Name = "Updated By")]
        //public string UpdatedByUserId { get; set; }

        //[Required, Display(Name = "Date Created")]
        //public DateTime DateCreated { get; set; }

        //[Required, Display(Name = "Date Updated")]
        //public DateTime DateUpdated { get; set; }
    }
}
