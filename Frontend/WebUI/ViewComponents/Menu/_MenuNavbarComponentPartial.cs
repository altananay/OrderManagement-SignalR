using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Menu;

public class _MenuNavbarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}