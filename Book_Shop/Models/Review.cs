
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Book_Shop.Models
{
    [Index(nameof(BookId), nameof(UserId), IsUnique = true)]
    public class Review
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;

        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(1000)]
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
