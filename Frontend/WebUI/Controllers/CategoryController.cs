using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Responses;

namespace WebUI.Controllers
{
    public class CategoryController(IHttpClientFactory _httpClientFactory, IConfiguration configuration) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetAllCategories"));
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetCategoryResponse>>(jsonData);
                return View(values);
            }

            return View();       
        }
    }
}