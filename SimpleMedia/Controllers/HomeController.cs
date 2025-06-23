using Microsoft.AspNetCore.Mvc;
using SimpleMedia.Models;
using System.Diagnostics;

namespace SimpleMedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SimpleMedia.Entities.SimpleMediaContext _simpleMediaContext;

        public HomeController(ILogger<HomeController> logger, SimpleMedia.Entities.SimpleMediaContext simpleMediaContext)
        {
            _logger = logger;
            _simpleMediaContext = simpleMediaContext;
        }

        public IActionResult Index()
        {
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
}
