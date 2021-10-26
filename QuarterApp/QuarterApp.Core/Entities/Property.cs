using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Core.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public double? MonthlyPrice { get; set; }
        public double? DailyPrice { get; set; }
        public double? WeeklyPrice { get; set;}
        public string Address { get; set; }
        public DateTime BuiltDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public Category Category { get; set; }
    }
}
