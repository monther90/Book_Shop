
using Book_Shop.Data;
using Book_Shop.DTOs.Cart;
using Book_Shop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Book_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task<Cart?> GetUserCart(string userId)
        {
            return await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Book)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        private decimal GetBookPrice(Book book)
        {
            if (book.DiscountPrice.HasValue &&
                book.DiscountPrice.Value > 0 &&
                book.DiscountPrice.Value < book.Price)
            {
                return book.DiscountPrice.Value;
            }

            return book.Price;
        }

        private CartDto MapCartToDto(Cart cart)
        {
            var items = cart.Items.Select(item =>
            {
                var unitPrice = GetBookPrice(item.Book);

                return new CartItemDto
                {
                    Id = item.Id,
                    BookId = item.BookId,
                    BookTitle = item.Book.Title,
                    CoverImageUrl = item.Book.CoverImageUrl,
                    UnitPrice = unitPrice,
                    Quantity = item.Quantity,
                    Subtotal = unitPrice * item.Quantity
                };
            }).ToList();

            return new CartDto
            {
                Id = cart.Id,
                Items = items,
                TotalItems = items.Sum(item => item.Quantity),
                Subtotal = items.Sum(item => item.Subtotal)
            };
        }

        // GET: api/cart
        [HttpGet]
        public async Task<ActionResult<CartDto>> GetCart()
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var cart = await GetUserCart(userId);

            if (cart == null)
            {
                return Ok(new CartDto());
            }

            return Ok(MapCartToDto(cart));
        }

        // POST: api/cart/items
        [HttpPost("items")]
        public async Task<ActionResult<CartDto>> AddToCart(
            AddToCartDto dto)
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var book = await _context.Books
                .FirstOrDefaultAsync(b => b.Id == dto.BookId);

            if (book == null)
                return NotFound("Book not found.");

            if (dto.Quantity > book.StockQuantity)
                return BadRequest("Requested quantity exceeds available stock.");

            var cart = await GetUserCart(userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId
                };

                _context.Carts.Add(cart);

                await _context.SaveChangesAsync();
            }

            var existingItem = cart.Items
                .FirstOrDefault(i => i.BookId == dto.BookId);

            if (existingItem != null)
            {
                var newQuantity = existingItem.Quantity + dto.Quantity;

                if (newQuantity > book.StockQuantity)
                    return BadRequest("Requested quantity exceeds available stock.");

                existingItem.Quantity = newQuantity;
            }
            else
            {
                cart.Items.Add(new CartItem
                {
                    BookId = book.Id,
                    Quantity = dto.Quantity
                });
            }

            await _context.SaveChangesAsync();

            var updatedCart = await GetUserCart(userId);

            return Ok(MapCartToDto(updatedCart!));
        }

        // PUT: api/cart/items/{itemId}
        [HttpPut("items/{itemId:int}")]
        public async Task<ActionResult<CartDto>> UpdateCartItem(
            int itemId,
            UpdateCartItemDto dto)
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var cart = await GetUserCart(userId);

            if (cart == null)
                return NotFound("Cart not found.");

            var item = cart.Items
                .FirstOrDefault(i => i.Id == itemId);

            if (item == null)
                return NotFound("Cart item not found.");

            if (dto.Quantity > item.Book.StockQuantity)
                return BadRequest("Requested quantity exceeds available stock.");

            item.Quantity = dto.Quantity;

            await _context.SaveChangesAsync();

            var updatedCart = await GetUserCart(userId);

            return Ok(MapCartToDto(updatedCart!));
        }

        // DELETE: api/cart/items/{itemId}
        [HttpDelete("items/{itemId:int}")]
        public async Task<ActionResult<CartDto>> RemoveCartItem(
            int itemId)
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var cart = await GetUserCart(userId);

            if (cart == null)
                return NotFound("Cart not found.");

            var item = cart.Items
                .FirstOrDefault(i => i.Id == itemId);

            if (item == null)
                return NotFound("Cart item not found.");

            _context.CartItems.Remove(item);

            await _context.SaveChangesAsync();

            var updatedCart = await GetUserCart(userId);

            return Ok(MapCartToDto(updatedCart!));
        }

        // DELETE: api/cart/clear
        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
                return NoContent();

            _context.CartItems.RemoveRange(cart.Items);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
