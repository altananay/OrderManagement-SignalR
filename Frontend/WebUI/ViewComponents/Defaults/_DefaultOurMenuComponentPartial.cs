using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.Responses.Product;

namespace WebUI.ViewComponents.Defaults;

public class _DefaultOurMenuComponentPartial(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(_configuration.GetValue<string>("Endpoints:GetAllProducts"));
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<GetAllProductsWithCategoryResponse>>(jsonData);
        return View(values);
    }
}