using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuarterApp.Service.Dtos.PropertyDtos;
using QuarterApp.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] PropertyPostDto propertyDto)
        {
            var model = await _propertyService.Create(propertyDto);

            return StatusCode(201, model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _propertyService.GetById(id));
        }
    }
}
