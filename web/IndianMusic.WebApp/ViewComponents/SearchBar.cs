using Microsoft.AspNetCore.Mvc;
using IndianMusic.Domain.ViewModels;
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
