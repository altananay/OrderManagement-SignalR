using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Layouts;

public class _LayoutNavbarComponentPartial : ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();
	}
}