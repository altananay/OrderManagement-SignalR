using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class DefaultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}