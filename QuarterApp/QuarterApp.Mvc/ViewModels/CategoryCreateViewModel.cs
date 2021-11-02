using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterApp.Mvc.ViewModels
{
    public class CategoryCreateViewModel
    {
        [StringLength(maximumLength:20)]
        public string Name { get; set; }
    }
}
