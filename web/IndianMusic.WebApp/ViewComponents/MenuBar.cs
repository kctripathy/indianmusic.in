using Microsoft.AspNetCore.Mvc;

namespace IndianMusic.WebApp.ViewComponents
{
    public class MenuBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
