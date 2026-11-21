
using Microsoft.EntityFrameworkCore;

namespace Book_Shop.Models
{
    [Index(nameof(UserId), IsUnique = true)]
    public class Wishlist
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;

        public ICollection<WishlistItem> Items { get; set; } = new List<WishlistItem>();
    }
}
