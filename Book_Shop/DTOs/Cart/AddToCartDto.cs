
using System.ComponentModel.DataAnnotations;

namespace Book_Shop.DTOs.Cart
{
    public class AddToCartDto
    {
        [Required]
        public int BookId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } = 1;
    }
}
