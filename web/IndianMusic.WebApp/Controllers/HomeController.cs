using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Serilog;

namespace IndianMusic.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IndianMusicDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<Labels> _localizer;
        private readonly IMemoryCache _cache;
        private readonly IEmailSenderFromApp _emailsender;

        public HomeController(ILogger<HomeController> logger,
                               IEmailSenderFromApp emailSender,
                                IndianMusicDbContext context, 
                                IStringLocalizer<Labels> localizer, 
                                IMemoryCache cache)
        {
            _logger = logger;
            _emailsender = emailSender;
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

            if (feature != null)
            {
                // Log with Serilog
                Log.Error(feature.Error, "Unhandled exception at {Path}", feature.Path);

                ViewBag.ExceptionPath = feature.Path;
                ViewBag.ExceptionMessage = feature.Error.Message;
                ViewBag.StackTrace = feature.Error.StackTrace;
            }
            return View();
        }

        // Handles specific status codes (404, 500, etc.)
        public IActionResult StatusCode(int code)
        {
            Log.Information("HTTP {StatusCode} returned for path {Path}", code, HttpContext.Request.Path);
            ViewBag.Code = code;
            return View();
        }

        [HttpPost]
        public IActionResult CauseError()
        {
            throw new Exception("Test exception from CauseError action.");
        }

        [HttpPost]
        public async Task<IActionResult> SendTestEmail()
        {
            try
            {
                User user = new User
                {
                    Name = "Kishor",
                    Email = "kctripathy@gmail.com"
                };

                //bool result = await _emailsender.SendEmailGoogleAsync("kctripathy@gmail.com", "Test ", "test");

                bool result = await _emailsender.SendEmailAsync(user.Name, user.Email, "Test subject", "test body");

                @ViewBag.Result = result;
                return View("ConfirmationMessage");
                //throw new Exception(result.ToString());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        
        }

    }
}
