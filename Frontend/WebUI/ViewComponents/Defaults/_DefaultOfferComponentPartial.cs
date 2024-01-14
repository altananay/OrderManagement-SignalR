using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Defaults;

public class _DefaultOfferComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    { 
        return View();
    }
}