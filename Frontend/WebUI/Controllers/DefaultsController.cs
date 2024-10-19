using Application.Requests.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.Responses.Contact;

namespace WebUI.Controllers;

[AllowAnonymous]
public class DefaultsController(IHttpClientFactory _httpClientFactory, IConfiguration configuration) : Controller
{
    public async Task<IActionResult> Index()
    {
		var client = _httpClientFactory.CreateClient();
        //todo: get id from parameter
        Guid id = Guid.Parse("6bf0779e-dc6c-4c0f-82f0-af6cdc7f7daf");
        var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetContact") + id.ToString());
		var response = await responseMessage.Content.ReadAsStringAsync();
		var jsonResponse = JsonConvert.DeserializeObject<GetContactResponse>(response);
		ViewBag.Location = jsonResponse.GoogleMapSource;
		return View();
    }

    [HttpGet]
    public PartialViewResult SendMessage()
    {
		return PartialView();
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(CreateMessageRequest request)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(request);
        StringContent content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync(configuration.GetValue<string>("Endpoints:CreateMessage"), content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}