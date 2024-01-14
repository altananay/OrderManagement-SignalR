using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Defaults;

public class _DefaultOurMenuComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}