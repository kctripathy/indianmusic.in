using IndianMusic.Domain.Models;
using IndianMusic.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Infrastructure.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(IndianMusicDbContext context) : base(context) { }

        public async Task<Artist?> GetArtistWithAlbumsAsync(int id)
        {
            return await _context.Set<Artist>()
                .Include(a => a.MusicPieces)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
