using QuarterApp.Service.Dtos;
using QuarterApp.Service.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Service.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryPostDto categoryDto);
        Task<CategoryDetailDto> GetByIdAsync(int id);
        Task<PagenatedListDto<CategoryListItemDto>> GetAllFiltered(int page, string search);
        Task EditAsync(int id, CategoryPostDto categoryDto);
        void Delete(int id);
        Task<bool> IsExistByIdAsync(int id);
    }
}
