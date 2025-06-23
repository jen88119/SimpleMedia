using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SimpleMedia.Dto;
using SimpleMedia.Entities;
using SimpleMedia.Interfaces;
using SimpleMedia.Services;
using System.Security.Claims;


public class UserController : Controller
{
    private readonly IUserService _userService;

    private readonly SimpleMediaContext _simpleMediaContext;

    public UserController(SimpleMediaContext simpleMediaContext, IUserService userService)
    {
        _simpleMediaContext = simpleMediaContext;
        _userService = userService;
    }
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public async Task<IActionResult> Profile()
    {
        var userId = User.Identity.Name;
        var result = await _userService.GetProfileAsync(userId);

        return View(result);
    }
    [HttpPost]
    public async Task<IActionResult> Register(User user)
    {
        if (await _userService.UserExistsAsync(user.UserID))
        {
            ModelState.AddModelError("UserID", "帳號已存在");
            return View(user);
        }

        await _userService.RegisterProfileAsync(user);
        return RedirectToAction("Login");
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto u)
    {
        var user = _simpleMediaContext.User.FirstOrDefault(a => a.UserID == u.UserID);

        if (user == null)
        {
            ViewBag.Error = "帳號不存在";
            return View(u);
        }

        string hash = PasswordHelper.HashPassword(u.Password, user.Salt);

        if (user.Password != hash)
        {
            ViewBag.Error = "密碼錯誤";
            return View(u);
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserID),
            new Claim("UserName", user.UserName)
        };
        
        var identity = new ClaimsIdentity(claims, "CookieAuth");
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("CookieAuth", principal);
        
        //HttpContext.Session.SetString("UserID", user.UserID);
        //HttpContext.Session.SetString("UserName", user.UserName);

        return RedirectToAction("Index", "Post");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("CookieAuth");
        return RedirectToAction("Login", "User");
    }

    [HttpPost]
    public async Task<IActionResult> Profile(ProfileDto u)
    {
        var userId = User.Identity.Name;

        await _userService.UpdateProfileAsync(u, userId);
        
        return RedirectToAction("Profile"); 
    }

}