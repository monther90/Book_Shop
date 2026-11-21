
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Book_Shop.Models
{
    [Index(nameof(Code), IsUnique = true)]
    public class PromoCode
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = string.Empty;

        [Range(0.01, 100)]
        public decimal DiscountPercentage { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Cart> Carts { get; set; } = new List<Cart>();

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
