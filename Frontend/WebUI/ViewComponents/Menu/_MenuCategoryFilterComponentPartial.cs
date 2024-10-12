using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.Responses.Category;

namespace WebUI.ViewComponents.Menu;

public class _MenuCategoryFilterComponentPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetAllCategories"));
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllCategoriesResponse>>(jsonData);
            return View(values);
        }

        return View();
    }
}