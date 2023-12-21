using Application.Abstractions;
using Application.Responses.Category;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(IMapper _mapper, ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mapper.Map<Task<List<GetAllCategoriesResponse>>>(_categoryService.GetAll());
            return Ok(values);
        }
    }
}