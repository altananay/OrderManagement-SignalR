using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebUI.Dtos.Requests.Identity;

namespace WebUI.Controllers;

public class SettingsController(UserManager<User> userManager) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await userManager.FindByNameAsync(User.Identity.Name);
        UserEditRequest request = new UserEditRequest();
        request.LastName = values.LastName;
        request.FirstName = values.FirstName;
        request.Username = values.UserName;
        request.Email = values.Email;
        return View(request);
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserEditRequest request)
    {
        if (request.Password == request.ConfirmPassword)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            user.LastName = request.LastName;
            user.FirstName = request.FirstName;
            user.UserName = request.Username;
            user.Email = request.Email;
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, request.Password);
            var result = await userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Category");
        }
        return View();
    }
}