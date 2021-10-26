using AutoMapper;
using QuarterApp.Core;
using QuarterApp.Core.Entities;
using QuarterApp.Service.CustomExceptions;
using QuarterApp.Service.Dtos;
using QuarterApp.Service.Dtos.CategoryDtos;
using QuarterApp.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Service.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateAsync(CategoryPostDto categoryDto)
        {
            if (await _unitOfWork.CategoryRepository.IsExistAsync(x => x.Name.ToLower() == categoryDto.Name.ToLower()))
                throw new RecordAlreadyExistException($"Item already exist with name {categoryDto.Name}");

            Category category = _mapper.Map<Category>(categoryDto);

            await _unitOfWork.CategoryRepository.InsertAsync(category);
            await _unitOfWork.CommitAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task EditAsync(int id, CategoryPostDto categoryDto)
        {
            Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id);
            if (category == null) throw new ItemNotFoundException($"Item not found by id: {id}");

            if (await _unitOfWork.CategoryRepository.IsExistAsync(x =>x.Id!=id && x.Name.ToLower() == categoryDto.Name.ToLower()))
                throw new RecordAlreadyExistException($"Item already exist with name {categoryDto.Name}");

            category.Name = categoryDto.Name;
            await _unitOfWork.CommitAsync();
        }

        public async Task<PagenatedListDto<CategoryListItemDto>> GetAllFiltered(int page, string search)
        {
            if (page < 1) throw new PageIndexFormatException("PageIndex must be greater or equal than 1");

            IEnumerable<Category> items = await _unitOfWork.CategoryRepository.GetAllPagenatedAsync(x => string.IsNullOrWhiteSpace(search)?true:x.Name.ToLower().Contains(search), page,10);
            int totalCount = await _unitOfWork.CategoryRepository.GetTotalCountAsync(x => string.IsNullOrWhiteSpace(search) ? true : x.Name.ToLower().Contains(search));

            IEnumerable<CategoryListItemDto> itemDtos = _mapper.Map<IEnumerable<CategoryListItemDto>>(items);

            PagenatedListDto<CategoryListItemDto> model = new PagenatedListDto<CategoryListItemDto>(itemDtos, totalCount, page, 10);

            return model;
        }


        public async Task<CategoryDetailDto> GetByIdAsync(int id)
        {
            Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id);

            if (category == null) throw new ItemNotFoundException($"Item not found by id: {id}");

            CategoryDetailDto categoryDto = _mapper.Map<CategoryDetailDto>(category);

            return categoryDto;
        }

        public Task<bool> IsExistByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
