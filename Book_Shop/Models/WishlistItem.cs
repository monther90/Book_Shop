
using Microsoft.EntityFrameworkCore;

namespace Book_Shop.Models
{
    [Index(nameof(WishlistId), nameof(BookId), IsUnique = true)]
    public class WishlistItem
    {
        public int Id { get; set; }

        public int WishlistId { get; set; }

        public Wishlist Wishlist { get; set; } = null!;

        public int BookId { get; set; }

        public Book Book { get; set; } = null!;
    }
}
