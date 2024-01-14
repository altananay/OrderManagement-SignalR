using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Defaults;

public class _DefaultSliderComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}