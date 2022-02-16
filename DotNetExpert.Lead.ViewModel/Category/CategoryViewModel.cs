using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpert.Lead.ViewModel.Category
{
    public class CategoryViewModel : BaseViewModel
    {
        [Required]
        public string Name { get; set; }
        public bool IsForMaterial { get; set; }
    }
}
