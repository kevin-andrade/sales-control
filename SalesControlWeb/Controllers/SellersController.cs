using Microsoft.AspNetCore.Mvc;
using SalesControlWeb.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }
        public IActionResult Index()
        {
            var listSellers = _sellerService.FindAll();
            return View(listSellers);
        }
    }
}