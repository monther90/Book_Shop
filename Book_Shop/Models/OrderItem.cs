
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Book_Shop.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; } = null!;

        public int? BookId { get; set; }

        public Book? Book { get; set; }

        [Required]
        [MaxLength(200)]
        public string BookTitle { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? CoverImageUrl { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
