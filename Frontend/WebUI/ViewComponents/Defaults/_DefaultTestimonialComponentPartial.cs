using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Defaults;

public class _DefaultTestimonialComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}