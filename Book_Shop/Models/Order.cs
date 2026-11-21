
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Book_Shop.Models
{
    public enum OrderStatus
    {
        Pending = 1,
        Processing = 2,
        Shipped = 3,
        Delivered = 4,
        Canceled = 5
    }

    [Index(nameof(OrderNumber), IsUnique = true)]
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string OrderNumber { get; set; } = string.Empty;

        [Required]
        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(500)]
        public string ShippingAddress { get; set; } = string.Empty;

        public decimal SubTotal { get; set; }

        public decimal TaxRate { get; set; } = 0.05m;

        public decimal ShippingFee { get; set; } = 0m;

        public decimal TaxAmount { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public int? PromoCodeId { get; set; }

        public PromoCode? PromoCode { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
