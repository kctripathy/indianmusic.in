using Microsoft.AspNetCore.Identity;

namespace IndianMusic.WebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Custom fields
        public string DisplayName { get; set; }
        public int? LanguageID { get; set; }  // FK to your Languages table
        public string ProfileImageUrl { get; set; } = string.Empty;

        // Audit fields
        public bool IsActive { get; set; } = true;
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }
}
