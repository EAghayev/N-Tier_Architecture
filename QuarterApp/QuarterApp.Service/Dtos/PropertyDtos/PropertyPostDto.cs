using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.Dtos.PropertyDtos
{
    public class PropertyPostDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double? Price { get; set; }
        public double? MonthlyPrice { get; set; }
        public double? DailyPrice { get; set; }
        public double? WeeklyPrice { get; set; }
        public string Address { get; set; }
        public DateTime BuiltDate { get; set; }
        public IFormFile File { get; set; }
    }

    public class PropertyPostDtoValidator : AbstractValidator<PropertyPostDto>
    {
        public PropertyPostDtoValidator()
        {
            RuleFor(x => x.Address).MaximumLength(500);
            RuleFor(x => x.Name).MaximumLength(200).NotNull().NotEmpty();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.DailyPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.WeeklyPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.MonthlyPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CategoryId).NotNull();

            RuleFor(x => x).Custom((x, context) =>
            {
                if(x.Price==null && x.DailyPrice == null && x.WeeklyPrice == null && x.MonthlyPrice == null)
                {
                    context.AddFailure("Any price must be entered");
                }
            });
        }
    }
}
