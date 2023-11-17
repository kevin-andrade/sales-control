using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalesControlWeb.Models;

namespace SalesControlWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Message"] = "Links";

        return View();
    }

    public IActionResult About()
    {
        ViewData["Message"] = "Sales Control Web App from C#";
        ViewData["Dev"] = "Keven Andrade";

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
