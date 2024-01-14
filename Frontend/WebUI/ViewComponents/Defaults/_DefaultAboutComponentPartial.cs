using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Defaults;

public class _DefaultAboutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}