using Microsoft.AspNetCore.Mvc;
using IndianMusic.Domain.ViewModels;
using IndianMusic.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace IndianMusic.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchRepository _repo;
        public SearchController(ISearchRepository repository)
        {
            _repo = repository;
        }
        [HttpPost]
        public async Task<IActionResult> Result(SearchViewModel model)
        {

            ViewBag.QueryText = model.QueryText;
            ViewBag.SelectedCategories = string.Join(", ", model.SelectedCategories);

            List<SearchResult> searchResults = new List<SearchResult>();
            searchResults = await _repo.GetSearchResultAsync(model);

            return View("SearchResult", searchResults);
        }
    }
}
