using IndianMusic.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IndianMusicz.WebApp.Controllers
{
    public class TranslateController : Controller
    {
        private readonly TranslationService _translator;

        public TranslateController(TranslationService translator)
        {
            _translator = translator;
        }

        [HttpPost]
        public IActionResult Index(string text, string lang = "hi")
        {
            var translated = _translator.TranslateText(text, lang);
            ViewBag.Original = text;
            ViewBag.Translated = translated;
            return View();
        }

        public IActionResult Index() => View();
    }
}
