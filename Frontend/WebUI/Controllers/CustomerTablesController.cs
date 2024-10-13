using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.Responses.Table;

namespace WebUI.Controllers;

public class CustomerTablesController(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : Controller
{
    public async Task<IActionResult> CustomerTablesList()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(_configuration.GetValue<string>("Endpoints:GetAllTables"));
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllTablesResponse>>(jsonData);
            return View(values);
        }
        return View();
    }
}