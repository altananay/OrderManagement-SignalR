using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Layouts;

public class _LayoutHeaderPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}