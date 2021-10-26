using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.Dtos.CategoryDtos
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
    }

    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(25).MinimumLength(2).NotNull().NotEmpty();
        }
    }

}
