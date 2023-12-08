using Microsoft.AspNetCore.Mvc;
using SalesControlWeb.Models.ViewModels;
using SalesControlWeb.Services;

namespace SalesControlWeb.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly ILogger<SalesRecordsController> _logger;
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(ILogger<SalesRecordsController> logger, SalesRecordService salesRecordService)
        {
            _logger = logger;
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(2022, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = new DateTime(2022, 12, 30);
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(2022, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = new DateTime(2022, 12, 30);
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
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