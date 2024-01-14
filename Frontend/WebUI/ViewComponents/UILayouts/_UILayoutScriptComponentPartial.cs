using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayouts;

public class _UILayoutScriptComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}