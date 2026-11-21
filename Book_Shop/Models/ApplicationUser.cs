
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Book_Shop.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Address { get; set; }

        [MaxLength(500)]
        public string? ProfileImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Cart? Cart { get; set; }

        public Wishlist? Wishlist { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
