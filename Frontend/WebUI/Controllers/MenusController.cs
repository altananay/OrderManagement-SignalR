using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.Requests.Basket;
using WebUI.Dtos.Responses.Product;

namespace WebUI.Controllers;

public class MenusController(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : Controller
{
    [Route("Menus/Index/{tableId:Guid}")]
    [HttpGet]
    public async Task<IActionResult> Index([FromRoute] Guid tableId)
    {
        ViewBag.tableId = tableId;
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(_configuration.GetValue<string>("Endpoints:GetAllProducts"));
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<GetAllProductsWithCategoryResponse>>(jsonData);
        return View(values);
    }

    [HttpPost]
    public async Task<IActionResult> AddBasket([FromBody] CreateBasketRequest request)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(request);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(_configuration.GetValue<string>("Endpoints:CreateBasket"), content);

        var updateTableStatusClient = _httpClientFactory.CreateClient();
        var updateTableStatusClientResponse = await updateTableStatusClient.GetAsync(string.Format(_configuration.GetValue<string>("Endpoints:UpdateTableStatus"), request.TableId, true));

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}