using Microsoft.AspNetCore.Mvc;

namespace IndianMusic.WebApp.Areas.Music.Controllers
{
    [Area("Music")]
    [Route("music")]
    public class HomeController : Controller
    {
        [Route("{*slug}")] // base route for the area
        public IActionResult Index(string slug)
        {
            // slug will contain everything after /music/
            // e.g. "classical-music/hindustani"

            if (string.IsNullOrEmpty(slug))
            {
                // default page
                return View("Index");  // e.g. Music Home
            }

            // Split the slug into parts
            var parts = slug.Split('/', StringSplitOptions.RemoveEmptyEntries);

            // Example: parts[0] = "classical-music", parts[1] = "hindustani"
            ViewBag.Category = parts.Length > 0 ? parts[0] : "";
            ViewBag.SubCategory = parts.Length > 1 ? parts[1] : "";

            return View("CategoryView"); // return a single view for all URLs
        }
    }
}
