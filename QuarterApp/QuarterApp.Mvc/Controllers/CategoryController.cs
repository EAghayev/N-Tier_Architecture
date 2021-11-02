using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuarterApp.Mvc.ViewModels;
using QuarterApp.Service.CustomExceptions;
using QuarterApp.Service.Dtos;
using QuarterApp.Service.Dtos.CategoryDtos;
using QuarterApp.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:44348/api/categories?page={page}");
            var responseJsonStr = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                CategoryIndexViewModel model = JsonConvert.DeserializeObject<CategoryIndexViewModel>(responseJsonStr);
                return View(model);
            }
            else
            {
                ErrorResponseModel error = JsonConvert.DeserializeObject<ErrorResponseModel>(responseJsonStr);
                return Ok(error);
            }
        }

        public async Task<IActionResult> IndexService(int page=1,string search=null)
        {
            PagenatedListDto<CategoryListItemDto> model = await _categoryService.GetAllFiltered(page, search);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateViewModel categoryVM)
        {
            if (!ModelState.IsValid) return View();

            var jsonStr = JsonConvert.SerializeObject(categoryVM);

            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:44348/api/categories", new StringContent(jsonStr, Encoding.UTF8, "application/json"));

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return RedirectToAction("index");
            }
            else
            {
                string responseContentStr = await responseMessage.Content.ReadAsStringAsync();
                ErrorResponseModel error = JsonConvert.DeserializeObject<ErrorResponseModel>(responseContentStr);

                if (error.Code == 409)
                {
                    ModelState.AddModelError("Name", "Eyni adli category movcuddur!");
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "xeta bas verdi");
                    return View();
                }

            }
        }

        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CategoryPostDto categoryDto)
        {
            try
            {
                await _categoryService.CreateAsync(categoryDto);
            }
            catch (RecordAlreadyExistException ex)
            {
                ModelState.AddModelError("Name", "Eyni adli category movcuddur!");
                return View();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Xeta bas verdi!");
                return View();
            }

            return RedirectToAction("indexservice");
        }



    }
}
