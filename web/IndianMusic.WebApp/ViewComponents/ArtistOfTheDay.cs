namespace IndianMusicz.ViewComponents
{
    using IndianMusic.Domain.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OutputCaching;
    using Microsoft.Extensions.Caching.Memory;

    
    public class ArtistOfTheDayViewComponent : ViewComponent
    {
        private readonly IndianMusicDbContext _context;
        private readonly IMemoryCache _cache;
        public ArtistOfTheDayViewComponent(IndianMusicDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public IViewComponentResult Invoke()
        {

            if (!_cache.TryGetValue("ArtistOfTheDay", out Artist? artist))
            {
                // Example: pick a random artist from DB
                artist = _context.Artists.OrderBy(a => Guid.NewGuid()).FirstOrDefault();

                var now = DateTime.Now;
                var midnight = now.Date.AddDays(1);
                var cacheDuration = midnight - now;

                _cache.Set("ArtistOfTheDay", artist, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = cacheDuration
                });
            }
            // Fetch artist of the day
            //var artist = _context.Artists.OrderBy(a => Guid.NewGuid()).FirstOrDefault();
            return View(artist);
        }
    }
}
