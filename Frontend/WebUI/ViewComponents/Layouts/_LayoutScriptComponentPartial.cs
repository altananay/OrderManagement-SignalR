﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Layouts;

public class _LayoutScriptComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
