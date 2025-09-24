using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IndianMusic.WebApp.Controllers
{
    public class LanguageController : Controller
    {
        [HttpGet]
        public IActionResult Selector()
        {
            var cultures = new List<SelectListItem>
        {
            new SelectListItem { Value = "en", Text = "English" },
            new SelectListItem { Value = "hi", Text = "हिन्दी" },
            new SelectListItem { Value = "or", Text = "ଓଡ଼ିଆ" }
        };

            var currentCulture = HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.UICulture.Name;

            // Mark current culture as selected
            foreach (var item in cultures)
            {
                if (item.Value == currentCulture)
                {
                    item.Selected = true;
                }
            }

            ViewBag.Cultures = cultures;
            return PartialView("_LanguageSelector");
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl ?? "/");
        }
    }
}
