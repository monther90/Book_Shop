
namespace Book_Shop.DTOs.Cart
{
    public class CartDto
    {
        public int Id { get; set; }
        public List<CartItemDto> Items { get; set; } = new();
        public int TotalItems { get; set; }
        public decimal Subtotal { get; set; }
    }
}
