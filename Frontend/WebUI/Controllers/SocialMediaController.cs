using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.Requests.SocialMedia;
using WebUI.Dtos.Responses.SocialMedia;

namespace WebUI.Controllers;

public class SocialMediaController(IHttpClientFactory _httpClientFactory, IConfiguration configuration) : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetAllSocialMedias"));
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllSocialMediasResponse>>(jsonData);
            return View(values);
        }

        return View();
    }

    [HttpGet]

    public IActionResult CreateSocialMedia()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaRequest request)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(request);
        StringContent content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync(configuration.GetValue<string>("Endpoints:CreateSocialMedia"), content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> DeleteSocialMedia(Guid id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync(configuration.GetValue<string>("Endpoints:DeleteSocialMedia") + id.ToString());
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateSocialMedia(Guid id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetSocialMedia") + id.ToString());
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateSocialMediaRequest>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaRequest request)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(request);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync(configuration.GetValue<string>("Endpoints:UpdateSocialMedia"), stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}