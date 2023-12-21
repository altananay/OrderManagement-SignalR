using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Layouts;

public class _LayoutSidebarComponentPartial : ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();
	}
}
