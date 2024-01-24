using Application.Abstractions;
using Application.Requests.Category;
using Application.Responses.Category;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(IMapper _mapper, ICategoryService _categoryService, IConfiguration configuration) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mapper.Map<Task<List<GetAllCategoriesResponse>>>(_categoryService.GetAllAsync());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
    {
        Category product = _mapper.Map<CreateCategoryRequest, Category>(request);
        await _categoryService.AddAsync(product);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        Category product = await _categoryService.GetByIdAsync(id);
        _categoryService.Delete(product);
        return Ok();
    }

    [HttpGet("/api/Categories/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Category product = await _categoryService.GetByIdAsync(id);
        GetCategoryResponse response = _mapper.Map<Category, GetCategoryResponse>(product);
        return Ok(response);
    }

    [HttpPut("/api/Categories")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest request)
    {
        Category product = _mapper.Map<UpdateCategoryRequest, Category>(request);
        _categoryService.Update(product);
        return Ok();
    }

    [HttpGet("/api/GetCategoryCount")]
    public async Task<IActionResult> GetCategoryCount()
    {
        return Ok(_categoryService.GetCategoryCount());
    }

    [HttpGet("/api/GetActiveCategoryCount")]
    public async Task<IActionResult> GetActiveCategoryCount()
    {
        return Ok(_categoryService.GetActiveCategoryCount());
    }

    [HttpGet("/api/GetPassiveCategoryCount")]
    public async Task<IActionResult> GetPassiveCategoryCount()
    {
        return Ok(_categoryService.GetPassiveCategoryCount());
    }
}