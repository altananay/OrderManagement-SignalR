using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.Requests.Contact;
using WebUI.Dtos.Responses.Contact;

namespace WebUI.Controllers;

public class ContactsController(IHttpClientFactory _httpClientFactory, IConfiguration configuration): Controller
{
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetAllContacts"));
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllContactsResponse>>(jsonData);
            return View(values);
        }

        return View();
    }

    [HttpGet]

    public IActionResult CreateContact()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactRequest request)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(request);
        StringContent content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync(configuration.GetValue<string>("Endpoints:CreateContact"), content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> DeleteContact(Guid id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync(configuration.GetValue<string>("Endpoints:DeleteContact") + id.ToString());
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateContact(Guid id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetContact") + id.ToString());
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateContactRequest>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateContact(UpdateContactRequest request)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(request);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync(configuration.GetValue<string>("Endpoints:UpdateContact"), stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}