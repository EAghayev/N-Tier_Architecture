using AutoMapper;
using QuarterApp.Core;
using QuarterApp.Core.Entities;
using QuarterApp.Service.CustomExceptions;
using QuarterApp.Service.Dtos;
using QuarterApp.Service.Dtos.PropertyDtos;
using QuarterApp.Service.HelperService.Interfaces;
using QuarterApp.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Service.Services.Implementations
{
    public class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public PropertyService(IUnitOfWork unitOfWork, IMapper mapper, IFileManager fileManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileManager = fileManager;
        }
        public async Task<PropertyCreateReturnDto> Create(PropertyPostDto propertyDto)
        {
            SavedFileDto savedFile = null;
            Property property = _mapper.Map<Property>(propertyDto);

            if (propertyDto.File != null)
            {
                if(propertyDto.File.ContentType!="image/png" && propertyDto.File.ContentType != "image/jpeg")
                {
                    throw new FileFormatException("File mimetype must be png or jpeg");
                }

                savedFile = await _fileManager.Save(propertyDto.File, "properties");
                property.FileName = savedFile.ChangedFileName;
            }

            await _unitOfWork.PropertyRepository.InsertAsync(property);
            await _unitOfWork.CommitAsync();

            PropertyCreateReturnDto returnDto = new PropertyCreateReturnDto
            {
                Id = property.Id,
                Path = savedFile.Path
            };

            return returnDto;
        }

        public async Task<PropertyDetailDto> GetById(int id)
        {
            Property property = await _unitOfWork.PropertyRepository.GetAsync(x => !x.IsDeleted && x.Id == id);

            if (property == null) throw new ItemNotFoundException("Property not found by id: " + id);

            PropertyDetailDto propertyDto = _mapper.Map<PropertyDetailDto>(property);

            return propertyDto;
        }
    }
}
