using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterApp.Mvc.ViewModels
{
    public class CategoryIndexViewModel
    {
        public List<CategoryItemViewModel> Items { get;set; }
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrev { get; set; }
    }

    public class CategoryItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
