using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.Responses.SocialMedia;

namespace WebUI.ViewComponents.UILayouts;

public class _UILayoutSocialMediaComponentPartial(IHttpClientFactory _httpClientFactory, IConfiguration configuration) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
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
}