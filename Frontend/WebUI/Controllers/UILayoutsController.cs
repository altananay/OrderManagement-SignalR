using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UILayoutsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}