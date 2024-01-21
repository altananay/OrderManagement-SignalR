using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.Responses.Contact;

namespace WebUI.ViewComponents.UILayouts;

public class _UILayoutFooterComponentPartial(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(_configuration.GetValue<string>("Endpoints:GetAllContacts"));
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<GetAllContactsResponse>>(jsonData);
        return View(values);
    }
}