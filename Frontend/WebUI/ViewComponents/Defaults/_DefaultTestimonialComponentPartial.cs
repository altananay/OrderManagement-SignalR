using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.Responses.Testimonial;

namespace WebUI.ViewComponents.Defaults;

public class _DefaultTestimonialComponentPartial(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(_configuration.GetValue<string>("Endpoints:GetAllTestimonials"));
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<GetAllTestimonialsResponse>>(jsonData);
        return View(values);
    }
}