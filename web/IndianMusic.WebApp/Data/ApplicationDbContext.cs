using IndianMusic.WebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IndianMusic.Domain.Models;

namespace IndianMusic.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IndianMusic.Domain.Models.AspNetUser> AspNetUser { get; set; } = default!;
    }
}
