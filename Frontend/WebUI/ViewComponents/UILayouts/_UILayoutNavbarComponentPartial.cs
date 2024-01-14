using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayouts;

public class _UILayoutNavbarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}