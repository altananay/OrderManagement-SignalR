using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Layouts;

public class _LayoutFooterComponentPartial : ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();
	}
}