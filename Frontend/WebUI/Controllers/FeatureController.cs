using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.Requests.Feature;
using WebUI.Dtos.Responses.Feature;

namespace WebUI.Controllers;

public class FeatureController(IHttpClientFactory _httpClientFactory, IConfiguration configuration) : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetAllFeatures"));
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllFeaturesResponse>>(jsonData);
            return View(values);
        }

        return View();
    }

    [HttpGet]

    public IActionResult CreateFeature()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureRequest request)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(request);
        StringContent content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync(configuration.GetValue<string>("Endpoints:CreateFeature"), content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> DeleteFeature(Guid id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync(configuration.GetValue<string>("Endpoints:DeleteFeature") + id.ToString());
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateFeature(Guid id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetFeature") + id.ToString());
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateFeatureRequest>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureRequest request)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(request);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync(configuration.GetValue<string>("Endpoints:UpdateFeature"), stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}