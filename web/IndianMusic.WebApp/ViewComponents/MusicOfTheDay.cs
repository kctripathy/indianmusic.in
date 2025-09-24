namespace IndianMusicz.ViewComponents
{
    using IndianMusic.Domain.Data;
    using IndianMusic.Domain.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    
    public class MusicOfTheDayViewComponent : ViewComponent
    {
        private readonly IndianMusicDbContext _context;
        private readonly IMemoryCache _cache;
        public MusicOfTheDayViewComponent(IndianMusicDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public IViewComponentResult Invoke()
        {

            if (!_cache.TryGetValue("MusicOfTheDay", out MusicPiece? music))
            {
                // Example: pick a random artist from DB
                music = _context.MusicPieces.OrderBy(a => Guid.NewGuid()).FirstOrDefault();
                if (music == null)
                {
                    music = new MusicPiece();
                }

                var now = DateTime.Now;
                var midnight = now.Date.AddDays(1);
                var cacheDuration = midnight - now;

                _cache.Set("MusicOfTheDay", music, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = cacheDuration
                });
            }
            // Fetch artist of the day
            //var artist = _context.Artists.OrderBy(a => Guid.NewGuid()).FirstOrDefault();
            return View(music);
        }
    }
}
