using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.Requests.Testimonial;
using WebUI.Dtos.Responses.Testimonial;

namespace WebUI.Controllers;

public class TestimonialController(IHttpClientFactory _httpClientFactory, IConfiguration configuration) : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetAllTestimonials"));
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllTestimonialsResponse>>(jsonData);
            return View(values);
        }

        return View();
    }

    [HttpGet]

    public IActionResult CreateTestimonial()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialRequest request)
    {
        request.Status = true;
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(request);
        StringContent content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync(configuration.GetValue<string>("Endpoints:CreateTestimonial"), content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> DeleteTestimonial(Guid id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync(configuration.GetValue<string>("Endpoints:DeleteTestimonial") + id.ToString());
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateTestimonial(Guid id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetTestimonial") + id.ToString());
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateTestimonialRequest>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialRequest request)
    {
        request.Status = true;
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(request);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync(configuration.GetValue<string>("Endpoints:UpdateTestimonial"), stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}