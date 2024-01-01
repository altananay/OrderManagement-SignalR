using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class SignalRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SecondIndex()
        {
            return View();
        }
    }
}