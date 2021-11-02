using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.Dtos.PropertyDtos
{
    public class PropertyDetailDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public double? MonthlyPrice { get; set; }
        public double? DailyPrice { get; set; }
        public double? WeeklyPrice { get; set; }
        public string Address { get; set; }
        public DateTime BuiltDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
