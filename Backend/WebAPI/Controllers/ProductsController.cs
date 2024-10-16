﻿using Application.Abstractions;
using Application.Requests.Product;
using Application.Responses.Product;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService _productService, IMapper _mapper) : ControllerBase
{
    [HttpGet("/api/Products/Page/{page}/WithLimit/{limit}")]
	public async Task<IActionResult> GetAllProductsWithPagination(int page, int limit)
	{
		var values = await _mapper.Map<Task<List<GetAllProductsWithCategoryResponse>>>(_productService.GetAllProductsWithPaginationAsync(page, limit));
		return Ok(values);
	}

	[HttpGet("/GetAllProductsWithCategory")]
    public async Task<IActionResult> GetAllProductsWithCategory()
    {
        var values = await _mapper.Map<Task<List<GetAllProductsWithCategoryResponse>>>(_productService.GetAllProductsWithCategoriesAsync());
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateProductRequest request)
    {
        Product product = _mapper.Map<CreateProductRequest, Product>(request);
        await _productService.AddAsync(product);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        Product product = await _productService.GetByIdAsync(id);
        _productService.Delete(product);
        return Ok();
    }

    [HttpGet("/api/Products/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Product product = await _productService.GetProductWithCategoryAsync(id);
        GetProductResponse response = _mapper.Map<Product, GetProductResponse>(product);
        return Ok(response);
    }

    [HttpPut("/api/Products")]
    public async Task<IActionResult> UpdateCategory(UpdateProductRequest request)
    {
        Product product = _mapper.Map<UpdateProductRequest, Product>(request);
        _productService.Update(product);
        return Ok();
    }

    [HttpGet("/api/GetProductCount")]
    public async Task<IActionResult> GetProductCount()
    {
        return Ok(_productService.GetProductCount());
    }

    [HttpGet("/api/GetProductCountByHamburger")]
    public async Task<IActionResult> GetProductCountByHamburger()
    {
        return Ok(_productService.GetProductCountByCategoryNameHamburger());
    }

    [HttpGet("/api/GetProductCountByDrink")]
    public async Task<IActionResult> GetProductCountByDrink()
    {
        return Ok(_productService.GetProductCountByCategoryNameDrink());
    }

    [HttpGet("/api/GetProductPriceAverage")]
    public async Task<IActionResult> GetProductPriceAverage()
    {
        return Ok(await _productService.GetProductPriceAverage());
    }

    [HttpGet("/api/GetProductNameByMaxPrice")]
    public async Task<IActionResult> GetProductNameByMaxPrice()
    {
        return Ok(await _productService.GetProductNameByMaxPrice());
    }

    [HttpGet("/api/GetProductNameByMinPrice")]
    public async Task<IActionResult> GetProductNameByMinPrice()
    {
        return Ok(await _productService.GetProductNameByMinPrice());
    }

    [HttpGet("/api/GetAveragePriceHamburger")]
    public async Task<IActionResult> GetAverageHamburgerPrice()
    {
        return Ok(await _productService.GetAverageHamburgerPrice());
    }
}