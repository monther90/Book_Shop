
namespace Book_Shop.DTOs.Books
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? CoverImageUrl { get; set; }

        public int? PublicationYear { get; set; }

        public decimal Price { get; set; }

        public decimal? DiscountPrice { get; set; }

        public bool IsBestSeller { get; set; }

        public bool IsRecommended { get; set; }

        public int StockQuantity { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string AuthorName { get; set; } = string.Empty;

        public string PublisherName { get; set; } = string.Empty;

        public decimal? FlashSalePrice { get; set; }
    }
}
