using IndianMusic.Domain.Models;
using IndianMusic.WebApp.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace IndianMusic.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IndianMusicDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<Labels> _localizer;
        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, IndianMusicDbContext context, IStringLocalizer<Labels> localizer, IMemoryCache cache)
        {
            _logger = logger;
            _context = context;
            _localizer = localizer;
            _cache = cache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        // Handles generic errors
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = feature?.Path;
            ViewBag.ExceptionMessage = feature?.Error.Message;
            ViewBag.StackTrace = feature?.Error.StackTrace;

            return View();
        }

        // Handles specific status codes (404, 500, etc.)
        public IActionResult StatusCode(int code)
        {
            ViewBag.Code = code;
            return View();
        }

        [HttpPost]
        public IActionResult CauseError()
        {
            throw new Exception("Test exception from CauseError action.");
        }
    }
}
