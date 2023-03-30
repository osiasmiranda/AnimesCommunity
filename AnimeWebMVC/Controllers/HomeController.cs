using Microsoft.AspNetCore.Mvc;

namespace AnimeWebMVC.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
   
}