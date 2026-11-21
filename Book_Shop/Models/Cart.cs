
using Microsoft.EntityFrameworkCore;

namespace Book_Shop.Models
{
    [Index(nameof(UserId), IsUnique = true)]
    public class Cart
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;

        public int? AppliedPromoCodeId { get; set; }

        public PromoCode? AppliedPromoCode { get; set; }

        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
