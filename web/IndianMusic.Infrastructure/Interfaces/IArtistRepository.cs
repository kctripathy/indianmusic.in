using IndianMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianMusic.Infrastructure.Interfaces
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<Artist?> GetArtistWithAlbumsAsync(int id);
    }
}
