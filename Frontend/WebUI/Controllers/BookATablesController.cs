using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using WebUI.Dtos.Requests.Booking;

namespace WebUI.Controllers
{
    public class BookATablesController(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_configuration.GetValue<string>("Endpoints:GetContact"));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray item = JArray.Parse(responseBody);
            string value = item[0]["googleMapSource"].ToString();
            ViewBag.location = value;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingRequest request)
        {
            //todo: get contact api operations codes move to function
            HttpClient locationClient = new HttpClient();
            HttpResponseMessage response = await locationClient.GetAsync(_configuration.GetValue<string>("Endpoints:GetContact"));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray item = JArray.Parse(responseBody);
            string value = item[0]["googleMapSource"].ToString();
            ViewBag.location = value;

            //todo: add textarea to index and get value from textarea
            request.Description = "test";

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(_configuration.GetValue<string>("Endpoints:CreateBooking"), stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Defaults");
            } 
            else
            {
                var errors = await responseMessage.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errors);
                return View();
            }
        }
    }
}