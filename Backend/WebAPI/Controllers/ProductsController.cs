using Application.Abstractions;
using Application.Requests.Product;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService _productService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("/GetAllProductsWithCategory")]
        public async Task<IActionResult> GetAllProductsWithCategory()
        {
            var values = await _mapper.Map<Task<List<GetAllProductsWithCategoryResponse>>>(_productService.GetAllProductsWithCategoriesAsync());
            return Ok(values);
        }
    }
}
