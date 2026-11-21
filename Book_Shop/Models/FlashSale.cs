
using System.ComponentModel.DataAnnotations;

namespace Book_Shop.Models
{
    public class FlashSale
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
