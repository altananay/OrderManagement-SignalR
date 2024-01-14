using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Defaults;

public class _DefaultBookATableComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}