using QuarterApp.Service.Dtos.PropertyDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Service.Services.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyCreateReturnDto> Create(PropertyPostDto propertyDto);
        Task<PropertyDetailDto> GetById(int id);
    }
}
