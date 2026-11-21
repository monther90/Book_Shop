
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Book_Shop.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(3000)]
        public string? Description { get; set; }

        [MaxLength(500)]
        public string? CoverImageUrl { get; set; }

        [Range(0, 9999)]
        public int? PublicationYear { get; set; }

      
        [Range(typeof(decimal), "0.01", "9999999999999999")]
        public decimal Price { get; set; }


        [Range(typeof(decimal), "0.01", "9999999999999999")]
        public decimal? DiscountPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        public bool IsBestSeller { get; set; }

        public bool IsRecommended { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public int AuthorId { get; set; }

        public Author Author { get; set; } = null!;

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; } = null!;

        public int? FlashSaleId { get; set; }

        public FlashSale? FlashSale { get; set; }

        public decimal? FlashSalePrice { get; set; }

        [Range(0, int.MaxValue)]
        public int FlashSaleStock { get; set; }

        [Range(0, int.MaxValue)]
        public int FlashSaleSoldQuantity { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
