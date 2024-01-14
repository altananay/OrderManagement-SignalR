using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayouts;

public class _UILayoutFooterComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}