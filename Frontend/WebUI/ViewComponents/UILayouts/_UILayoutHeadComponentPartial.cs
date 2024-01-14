using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayouts;

public class _UILayoutHeadComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}