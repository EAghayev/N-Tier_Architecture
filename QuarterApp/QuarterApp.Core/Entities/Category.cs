using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
