using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuarterApp.Service.CustomExceptions;
using QuarterApp.Service.Dtos.CategoryDtos;
using QuarterApp.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(CategoryPostDto categoryDto)
        {
            await _categoryService.CreateAsync(categoryDto);
            
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _categoryService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryPostDto categoryDto)
        {
            await _categoryService.EditAsync(id, categoryDto);

            return NoContent();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll(string search,int page = 1)
        {
            return Ok(await _categoryService.GetAllFiltered(page, search));
        }
    }
}
