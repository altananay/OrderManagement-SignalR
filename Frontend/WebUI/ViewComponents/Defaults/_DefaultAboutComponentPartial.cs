using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.Responses.About;

namespace WebUI.ViewComponents.Defaults;

public class _DefaultAboutComponentPartial(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(_configuration.GetValue<string>("Endpoints:GetAllAbouts"));
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<GetAllAboutsResponse>>(jsonData);
        return View(values);
    }
}