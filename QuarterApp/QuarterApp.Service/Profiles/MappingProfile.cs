using AutoMapper;
using QuarterApp.Core.Entities;
using QuarterApp.Service.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDetailDto>();
            CreateMap<Category, CategoryListItemDto>();
            CreateMap<Category, CategoryListItemDto>();

            CreateMap<CategoryPostDto, Category>();
        }
    }
}
