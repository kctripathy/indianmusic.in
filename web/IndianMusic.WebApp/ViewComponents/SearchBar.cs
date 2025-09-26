using Microsoft.AspNetCore.Mvc;

namespace IndianMusic.WebApp.ViewComponents
{
    public class SearchBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var vm = new SearchViewModel();
            return View(vm);
        }
    }
}
