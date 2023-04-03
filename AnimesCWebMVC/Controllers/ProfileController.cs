using AnimesCWebMVC.Models;
using AnimesCWebMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace AnimesCWebMVC.Controllers
{

    public class ProfileController : Controller
    {
        private readonly IProfileHttpService _profileHttpService;
        private string token = string.Empty;

        public ProfileController(IProfileHttpService profileHttpService)
        {
            _profileHttpService = profileHttpService;
        }

        public async Task<ActionResult<ProfileViewModel>> Index()
        {
            //extratir o token do cookie

            var result = await _profileHttpService.GetProfiles(ObterTokenJwt());

            if (result is null)
            {
                return View("Error");
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult CreateProfile()
        {
            return View();
        }

        private string ObterTokenJwt()
        {

            if (HttpContext.Request.Cookies.ContainsKey("X-Access-Token"))
            {
                token = HttpContext.Request.Cookies["X-Access-Token"]!.ToString();
            }
            return token;
        }

    }
}