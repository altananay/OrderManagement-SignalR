using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.Requests.Product;
using WebUI.Dtos.Responses.Category;
using WebUI.Dtos.Responses.Product;

namespace WebUI.Controllers
{
    public class ProductController(IHttpClientFactory _httpClientFactory, IConfiguration configuration) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetAllProducts"));
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAllProductsWithCategoryResponse>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetAllCategories"));
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllCategoriesResponse>>(jsonData);
            List<SelectListItem> categories = (from x in values select new SelectListItem { Text = x.Name, Value = x.Id.ToString()}).ToList();
            ViewBag.viewbag = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            request.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(configuration.GetValue<string>("Endpoints:CreateProduct"), content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync(configuration.GetValue<string>("Endpoints:DeleteProduct") + id.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var getAllCategoriesClient = _httpClientFactory.CreateClient();
            var getAllCategoriesResponseMessage = await getAllCategoriesClient.GetAsync(configuration.GetValue<string>("Endpoints:GetAllCategories"));
            var getAllCategoriesJsonData = await getAllCategoriesResponseMessage.Content.ReadAsStringAsync();
            var categoriesDeserialize = JsonConvert.DeserializeObject<List<GetAllCategoriesResponse>>(getAllCategoriesJsonData);
            List<SelectListItem> categories = (from x in categoriesDeserialize select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.viewbag = categories;


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(configuration.GetValue<string>("Endpoints:GetProduct") + id.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetProductResponse>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
        {
            request.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(configuration.GetValue<string>("Endpoints:UpdateProduct"), stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}