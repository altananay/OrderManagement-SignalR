using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class ErrorsController : Controller
{
    public IActionResult NotFoundPage()
    {
        return View();
    }
}