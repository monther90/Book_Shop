
using Book_Shop.Data;
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
    public class WishlistController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WishlistController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        // GET: api/wishlist
        [HttpGet]
        public async Task<IActionResult> GetWishlist()
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var wishlist = await _context.Wishlists
                .Where(w => w.UserId == userId)
                .Select(w => new
                {
                    w.Id,
                    Items = w.Items.Select(item => new
                    {
                        item.Id,
                        BookId = item.Book.Id,
                        item.Book.Title,
                        item.Book.Description,
                        item.Book.CoverImageUrl,
                        item.Book.Price,
                        item.Book.DiscountPrice,
                        item.Book.StockQuantity,
                        CategoryName = item.Book.Category.Name,
                        AuthorName = item.Book.Author.Name
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (wishlist == null)
            {
                return Ok(new
                {
                    Id = 0,
                    Items = new List<object>(),
                    TotalItems = 0
                });
            }

            return Ok(new
            {
                wishlist.Id,
                wishlist.Items,
                TotalItems = wishlist.Items.Count
            });
        }

        // POST: api/wishlist/items/{bookId}
        [HttpPost("items/{bookId:int}")]
        public async Task<IActionResult> AddToWishlist(int bookId)
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var bookExists = await _context.Books
                .AnyAsync(b => b.Id == bookId);

            if (!bookExists)
                return NotFound("Book not found.");

            var wishlist = await _context.Wishlists
                .Include(w => w.Items)
                .FirstOrDefaultAsync(w => w.UserId == userId);

            if (wishlist == null)
            {
                wishlist = new Wishlist
                {
                    UserId = userId
                };

                _context.Wishlists.Add(wishlist);

                await _context.SaveChangesAsync();
            }

            var alreadyExists = wishlist.Items
                .Any(item => item.BookId == bookId);

            if (alreadyExists)
                return BadRequest("Book already exists in wishlist.");

            wishlist.Items.Add(new WishlistItem
            {
                BookId = bookId
            });

            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Book added to wishlist successfully."
            });
        }

        // DELETE: api/wishlist/items/{bookId}
        [HttpDelete("items/{bookId:int}")]
        public async Task<IActionResult> RemoveFromWishlist(int bookId)
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var wishlist = await _context.Wishlists
                .Include(w => w.Items)
                .FirstOrDefaultAsync(w => w.UserId == userId);

            if (wishlist == null)
                return NotFound("Wishlist not found.");

            var item = wishlist.Items
                .FirstOrDefault(i => i.BookId == bookId);

            if (item == null)
                return NotFound("Book not found in wishlist.");

            _context.WishlistItems.Remove(item);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Book removed from wishlist successfully."
            });
        }

        // DELETE: api/wishlist/clear
        [HttpDelete("clear")]
        public async Task<IActionResult> ClearWishlist()
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var wishlist = await _context.Wishlists
                .Include(w => w.Items)
                .FirstOrDefaultAsync(w => w.UserId == userId);

            if (wishlist == null)
                return NoContent();

            _context.WishlistItems.RemoveRange(wishlist.Items);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
