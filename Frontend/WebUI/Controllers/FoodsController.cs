using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.Responses.FoodTasty;

namespace WebUI.Controllers;

public class FoodsController(IConfiguration configuration) : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(configuration.GetValue<string>("Endpoints:TastyApiRequestUrl")),
            Headers = 
    {
        { "x-rapidapi-key", configuration.GetValue<string>("Endpoints:RapidApiKey") },
        { "x-rapidapi-host", configuration.GetValue<string>("Endpoints:RapidApiHost") },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<FoodTastyResultsResponse>(body);
            var values = results.Results;
            return View(values.ToList());
        }
    }
}