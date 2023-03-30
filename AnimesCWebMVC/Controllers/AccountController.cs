using AnimesCWebMVC.Models;
using AnimesCWebMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimesCWebMVC.Controllers;

public class AccountController : Controller


{
    private readonly IAuthentication _authenticationService;

    public AccountController(IAuthentication authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(UserViewModel model) 
    { 
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "Login Inválido");
            return View(model);
        }
        //verifica as credenciais do usuário e retorna o valor
        var result = await _authenticationService.AuthenticationUser(model);

        if(result is null)
        {
            ModelState.AddModelError(string.Empty, "Login Inválido");
            return View(model);
        }

        Response.Cookies.Append("X-Access-Token", result.Token, new CookieOptions()
        {
            Secure = true,
            HttpOnly = true,
            SameSite = SameSiteMode.Strict
        }) ;
        return Redirect("/");
    }
}
