using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.Requests.Table;
using WebUI.Dtos.Responses.Table;

namespace WebUI.Controllers;

public class TablesController(IHttpClientFactory _httpClientFactory, IConfiguration _configuration) : Controller
{
	public async Task<IActionResult> Index()
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync(_configuration.GetValue<string>("Endpoints:GetAllTables"));
		if (responseMessage.IsSuccessStatusCode)
		{
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<GetAllTablesResponse>>(jsonData);
			return View(values);
		}
		return View();
	}
	[HttpGet]
	public IActionResult CreateTable()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> CreateTable(CreateTableRequest request)
	{
        //todo: add textarea to webui for description column
        request.Description = "";
		var client = _httpClientFactory.CreateClient();
		var jsonData = JsonConvert.SerializeObject(request);
		StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync(_configuration.GetValue<string>("Endpoints:CreateTable"), stringContent);
		if (responseMessage.IsSuccessStatusCode)
		{
			return RedirectToAction("Index");
		}
		return View();
	}
	public async Task<IActionResult> DeleteTable(Guid id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.DeleteAsync(_configuration.GetValue<string>("Endpoints:DeleteTable") + id.ToString());
		if (responseMessage.IsSuccessStatusCode)
		{
			return RedirectToAction("Index");
		}
		return View();
	}
	[HttpGet]
	public async Task<IActionResult> UpdateTable(Guid id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync(_configuration.GetValue<string>("Endpoints:GetTable") + id.ToString());
		if (responseMessage.IsSuccessStatusCode)
		{
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<UpdateTableRequest>(jsonData);
			return View(values);
		}
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> UpdateTable(UpdateTableRequest request)
	{
		var client = _httpClientFactory.CreateClient();
		var jsonData = JsonConvert.SerializeObject(request);
		StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
		var responseMessage = await client.PutAsync(_configuration.GetValue<string>("Endpoints:UpdateTable"), stringContent);
		if (responseMessage.IsSuccessStatusCode)
		{
			return RedirectToAction("Index");
		}
		return View();
	}

	[HttpGet]
	public async Task<IActionResult> TableListByStatus()
	{
		var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync(_configuration.GetValue<string>("Endpoints:GetAllTables"));
        if (responseMessage.IsSuccessStatusCode)
		{
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<GetAllTablesResponse>>(jsonData);
			return View(values);
		}
		return View();
	}
}