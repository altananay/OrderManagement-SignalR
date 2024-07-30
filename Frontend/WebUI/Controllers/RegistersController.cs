using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Dtos.Requests.Identity;

namespace WebUI.Controllers;

public class RegistersController : Controller
{
    private readonly UserManager<User> _userManager;

    public RegistersController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserRegisterRequest registerRequest)
    {
        var user = new User()
        {
            FirstName = registerRequest.FirstName,
            LastName = registerRequest.LastName,
            Email = registerRequest.Email,
            UserName = registerRequest.Username
        };
        
        
        var result = await _userManager.CreateAsync(user, registerRequest.Password);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Login");
        }
		//todo: If result is failure add error message
		return View();
    }
}
