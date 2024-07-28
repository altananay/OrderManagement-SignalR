using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class MessagesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult UserClientCount()
    {
        return View();
    }
}