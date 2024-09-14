using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.Responses.Product;

namespace WebUI.ViewComponents.Defaults;

public class _DefaultOurMenuComponentPartial(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        //todo: set page and limit from parameter
        int page = 1;
        int limit = 9;
        var responseMessage = await client.GetAsync(string.Format(_configuration.GetValue<string>("Endpoints:GetAllProductsWithPagination"), page, limit));
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<GetAllProductsResponse>>(jsonData);
        return View(values);
    }
}