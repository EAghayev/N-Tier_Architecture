using AutoMapper;
using QuarterApp.Core.Entities;
using QuarterApp.Service.Dtos.CategoryDtos;
using QuarterApp.Service.Dtos.PropertyDtos;
using QuarterApp.Service.HelperService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.Profiles
{
    public class MappingProfile:Profile
    {
        private readonly IHelperAccessor _helperAccessor;

        public MappingProfile(IHelperAccessor helperAccessor)
        {
            _helperAccessor = helperAccessor;


            CreateMap<Category, CategoryDetailDto>();
            CreateMap<Category, CategoryListItemDto>();
            CreateMap<Category, CategoryListItemDto>();
            CreateMap<CategoryPostDto, Category>();

            CreateMap<PropertyPostDto, Property>();
            CreateMap<Property, PropertyDetailDto>()
                .ForMember(dest => dest.FilePath, from => from.MapFrom(src => _helperAccessor.BaseUrl + "/uploads/properties/" + src.FileName));
        }
    }
}
