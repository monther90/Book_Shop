
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Book_Shop.Models
{
    [Index(nameof(CartId), nameof(BookId), IsUnique = true)]
    public class CartItem
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public Cart Cart { get; set; } = null!;

        public int BookId { get; set; }

        public Book Book { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
