using Microsoft.AspNetCore.Mvc;
using SalesControlWeb.Models.ViewModels;

namespace SalesControlWeb.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly ILogger<SalesRecordsController> _logger;

        public SalesRecordsController(ILogger<SalesRecordsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SimpleSearch()
        {
            return View();
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string message)
        {
            ErrorViewModel viewModel = new()
            { 
                Message = message,
                RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}