using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.Requests.About;
using WebUI.Dtos.Responses.About;

namespace WebUI.Controllers
{
    public class AboutsController(IHttpClientFactory _httpClientFactory, IConfiguration configuration) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetAllAbouts"));
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAllAboutsResponse>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]

        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(configuration.GetValue<string>("Endpoints:CreateAbout"), content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteAbout(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync(configuration.GetValue<string>("Endpoints:DeleteAbout") + id.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetAbout") + id.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutRequest>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(configuration.GetValue<string>("Endpoints:UpdateAbout"), stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}