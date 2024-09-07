using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Dtos.Requests.Identity;

namespace WebUI.Controllers;

[AllowAnonymous]
public class LoginsController(SignInManager<User> _signInManager) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserLoginRequest request)
    {
        var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Category");
        }
		//todo: If result is failure add error message
		return View();
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Logins");
    }
}