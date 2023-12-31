using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.Requests.Discount;
using WebUI.Dtos.Responses.Discount;

namespace WebUI.Controllers;

public class DiscountController(IHttpClientFactory _httpClientFactory, IConfiguration configuration) : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetAllDiscounts"));
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllDiscountsResponse>>(jsonData);
            return View(values);
        }

        return View();
    }

    [HttpGet]

    public IActionResult CreateDiscount()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateDiscount(CreateDiscountRequest request)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(request);
        StringContent content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync(configuration.GetValue<string>("Endpoints:CreateDiscount"), content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> DeleteDiscount(Guid id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync(configuration.GetValue<string>("Endpoints:DeleteDiscount") + id.ToString());
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateDiscount(Guid id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetDiscount") + id.ToString());
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateDiscountRequest>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateDiscount(UpdateDiscountRequest request)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(request);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync(configuration.GetValue<string>("Endpoints:UpdateDiscount"), stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}