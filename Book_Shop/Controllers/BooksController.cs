
using Book_Shop.Data;
using Book_Shop.DTOs.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _context.Books
                .Select(book => new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    CoverImageUrl = book.CoverImageUrl,
                    PublicationYear = book.PublicationYear,
                    Price = book.Price,
                    DiscountPrice = book.DiscountPrice,
                    StockQuantity = book.StockQuantity,
                    IsBestSeller = book.IsBestSeller,
                    IsRecommended = book.IsRecommended,
                    CategoryName = book.Category.Name,
                    AuthorName = book.Author.Name,
                    PublisherName = book.Publisher.Name
                })
                .ToListAsync();

            return Ok(books);
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _context.Books
                .Where(book => book.Id == id)
                .Select(book => new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    CoverImageUrl = book.CoverImageUrl,
                    PublicationYear = book.PublicationYear,
                    Price = book.Price,
                    DiscountPrice = book.DiscountPrice,
                    StockQuantity = book.StockQuantity,
                    IsBestSeller = book.IsBestSeller,
                    IsRecommended = book.IsRecommended,
                    CategoryName = book.Category.Name,
                    AuthorName = book.Author.Name,
                    PublisherName = book.Publisher.Name
                })
                .FirstOrDefaultAsync();

            if (book == null)
                return NotFound();

            return Ok(book);


        }

        // GET: api/books/search?query=harry
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<BookDto>>> SearchBooks(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Search query cannot be empty.");

            var books = await _context.Books
                .Where(book =>
                    book.Title.Contains(query) ||
                    book.Author.Name.Contains(query))
                .Select(book => new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    CoverImageUrl = book.CoverImageUrl,
                    PublicationYear = book.PublicationYear,
                    Price = book.Price,
                    DiscountPrice = book.DiscountPrice,
                    StockQuantity = book.StockQuantity,
                    IsBestSeller = book.IsBestSeller,
                    IsRecommended = book.IsRecommended,
                    CategoryName = book.Category.Name,
                    AuthorName = book.Author.Name,
                    PublisherName = book.Publisher.Name
                })
                .ToListAsync();

            return Ok(books);
        }



        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByCategory(int categoryId)
        {
            var categoryExists = await _context.Categories
                .AnyAsync(category => category.Id == categoryId);

            if (!categoryExists)
                return NotFound("Category not found.");

            var books = await _context.Books
                .Where(book => book.CategoryId == categoryId)
                .Select(book => new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    CoverImageUrl = book.CoverImageUrl,
                    PublicationYear = book.PublicationYear,
                    Price = book.Price,
                    DiscountPrice = book.DiscountPrice,
                    StockQuantity = book.StockQuantity,
                    IsBestSeller = book.IsBestSeller,
                    IsRecommended = book.IsRecommended,
                    CategoryName = book.Category.Name,
                    AuthorName = book.Author.Name,
                    PublisherName = book.Publisher.Name
                })
                .ToListAsync();

            return Ok(books);
        }


        // GET: api/books/bestsellers
        [HttpGet("bestsellers")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBestsellers()
        {
            var books = await _context.Books
                .Where(book => book.IsBestSeller)
                .Select(book => new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    CoverImageUrl = book.CoverImageUrl,
                    PublicationYear = book.PublicationYear,
                    Price = book.Price,
                    DiscountPrice = book.DiscountPrice,
                    StockQuantity = book.StockQuantity,
                    IsBestSeller = book.IsBestSeller,
                    IsRecommended = book.IsRecommended,
                    CategoryName = book.Category.Name,
                    AuthorName = book.Author.Name,
                    PublisherName = book.Publisher.Name
                })
                .ToListAsync();

            return Ok(books);
        }

        // GET: api/books/recommended
        [HttpGet("recommended")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetRecommendedBooks()
        {
            var books = await _context.Books
                .Where(book => book.IsRecommended)
                .Select(book => new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    CoverImageUrl = book.CoverImageUrl,
                    PublicationYear = book.PublicationYear,
                    Price = book.Price,
                    DiscountPrice = book.DiscountPrice,
                    StockQuantity = book.StockQuantity,
                    IsBestSeller = book.IsBestSeller,
                    IsRecommended = book.IsRecommended,
                    CategoryName = book.Category.Name,
                    AuthorName = book.Author.Name,
                    PublisherName = book.Publisher.Name
                })
                .ToListAsync();

            return Ok(books);
        }


    }
}
