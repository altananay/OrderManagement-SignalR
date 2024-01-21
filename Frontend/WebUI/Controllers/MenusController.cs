using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.Dtos.Responses.Product;

namespace WebUI.Controllers;

public class MenusController(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(_configuration.GetValue<string>("Endpoints:GetAllProducts"));
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<GetAllProductsWithCategoryResponse>>(jsonData);
        return View(values);
    }
}