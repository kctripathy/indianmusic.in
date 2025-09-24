using IndianMusic.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IndianMusic.WebApp.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistsController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<IActionResult> Index()
        {
            var artists = await _artistRepository.GetAllAsync();
            return View(artists);
        }
    }

}
