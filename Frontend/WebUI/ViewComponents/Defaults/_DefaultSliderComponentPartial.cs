using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.Responses.Slider;

namespace WebUI.ViewComponents.Defaults;

public class _DefaultSliderComponentPartial(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(_configuration.GetValue<string>("Endpoints:GetAllSliders"));
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<GetAllSlidersResponse>>(jsonData);
        return View(values);
    }
}