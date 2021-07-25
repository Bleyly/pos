using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POS.Data;
using POS.Models;
using POS.Service;

namespace POS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IService<Type> _typeService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IService<Type> typeService)
        {
            _logger = logger;
            _productService = productService;
            _typeService = typeService;
        }

        public async Task<IActionResult> Index([FromQuery] int typeId)
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Product");
            }

            var types = await _typeService.GetAllAsync();

            if (typeId == default(int) && types.Any())
            {
                typeId = types.First().Id;
                return RedirectToAction(nameof(Index), new { typeId = types.First().Id });
            }

            ViewData["typeId"] = typeId;
            ViewData["Types"] = types;
            var productos = await _productService.GetByTypeAsync(typeId);

            return View(productos);
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
}
