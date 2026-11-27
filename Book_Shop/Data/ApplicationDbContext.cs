
using Book_Shop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Book_Shop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Publisher> Publishers => Set<Publisher>();
        public DbSet<FlashSale> FlashSales => Set<FlashSale>();
        public DbSet<PromoCode> PromoCodes => Set<PromoCode>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();
        public DbSet<Wishlist> Wishlists => Set<Wishlist>();
        public DbSet<WishlistItem> WishlistItems => Set<WishlistItem>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.NormalizedEmail)
                .IsUnique();

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Wishlist)
                .WithOne(w => w.User)
                .HasForeignKey<Wishlist>(w => w.UserId);

            builder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Book>()
                .HasOne(b => b.FlashSale)
                .WithMany(f => f.Books)
                .HasForeignKey(b => b.FlashSaleId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<CartItem>()
                .HasOne(ci => ci.Book)
                .WithMany(b => b.CartItems)
                .HasForeignKey(ci => ci.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<WishlistItem>()
                .HasOne(wi => wi.Book)
                .WithMany(b => b.WishlistItems)
                .HasForeignKey(wi => wi.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Book)
                .WithMany(b => b.OrderItems)
                .HasForeignKey(oi => oi.BookId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            // Categories
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction" },
                new Category { Id = 2, Name = "Science" },
                new Category { Id = 3, Name = "Technology" },
                new Category { Id = 4, Name = "History" },
                new Category { Id = 5, Name = "Business" },
                new Category { Id = 6, Name = "Self Development" },
                new Category { Id = 7, Name = "Mystery" },
                new Category { Id = 8, Name = "Romance" }
            );

            // Authors
            builder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Robert C. Martin" },
                new Author { Id = 2, Name = "George Orwell" },
                new Author { Id = 3, Name = "J. K. Rowling" },
                new Author { Id = 4, Name = "Agatha Christie" },
                new Author { Id = 5, Name = "Yuval Noah Harari" },
                new Author { Id = 6, Name = "James Clear" },
                new Author { Id = 7, Name = "Stephen King" },
                new Author { Id = 8, Name = "Paulo Coelho" },
                new Author { Id = 9, Name = "Mark Manson" },
                new Author { Id = 10, Name = "Morgan Housel" }
            );

            // Publishers
            builder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Penguin Random House" },
                new Publisher { Id = 2, Name = "HarperCollins" },
                new Publisher { Id = 3, Name = "Simon & Schuster" },
                new Publisher { Id = 4, Name = "Macmillan Publishers" },
                new Publisher { Id = 5, Name = "Hachette Book Group" }
            );

            // Flash Sales
            builder.Entity<FlashSale>().HasData(
                new FlashSale
                {
                    Id = 1,
                    Title = "Weekend Book Deals",
                    Description = "Special discounts on selected books",
                    StartTime = new DateTime(2026, 11, 1, 0, 0, 0),
                    EndTime = new DateTime(2030, 12, 31, 23, 59, 59),
                    IsActive = true
                },
                new FlashSale
                {
                    Id = 2,
                    Title = "Best Sellers Sale",
                    Description = "Limited offers on popular books",
                    StartTime = new DateTime(2026, 11, 1, 0, 0, 0),
                    EndTime = new DateTime(2030, 12, 31, 23, 59, 59),
                    IsActive = true
                }
            );

            // Promo Codes
            builder.Entity<PromoCode>().HasData(
                new PromoCode
                {
                    Id = 1,
                    Code = "WELCOME10",
                    DiscountPercentage = 10,
                    ExpiryDate = new DateTime(2030, 12, 31),
                    IsActive = true
                },
                new PromoCode
                {
                    Id = 2,
                    Code = "BOOK20",
                    DiscountPercentage = 20,
                    ExpiryDate = new DateTime(2030, 12, 31),
                    IsActive = true
                },
                new PromoCode
                {
                    Id = 3,
                    Code = "READ15",
                    DiscountPercentage = 15,
                    ExpiryDate = new DateTime(2030, 12, 31),
                    IsActive = true
                }
            );

            // Books
            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Clean Code",
                    Description = "A handbook of agile software craftsmanship.",
                    Price = 30m,
                    PublicationYear = 2008,
                    StockQuantity = 25,
                    IsRecommended = true,
                    CategoryId = 3,
                    AuthorId = 1,
                    PublisherId = 1,
                    FlashSaleId = 1,
                    FlashSalePrice = 18m,
                    FlashSaleStock = 10,
                    FlashSaleSoldQuantity = 0
                },
                new Book
                {
                    Id = 2,
                    Title = "1984",
                    Description = "A dystopian novel about surveillance and totalitarianism.",
                    Price = 18m,
                    PublicationYear = 1949,
                    StockQuantity = 30,
                    IsBestSeller = true,
                    CategoryId = 1,
                    AuthorId = 2,
                    PublisherId = 1,
                    FlashSaleId = 1,
                    FlashSalePrice = 15m,
                    FlashSaleStock = 10,
                    FlashSaleSoldQuantity = 0
                },
                new Book
                {
                    Id = 3,
                    Title = "Harry Potter and the Philosopher's Stone",
                    Description = "The first book in the Harry Potter fantasy series.",
                    Price = 22m,
                    PublicationYear = 1997,
                    StockQuantity = 40,
                    IsBestSeller = true,
                    CategoryId = 1,
                    AuthorId = 3,
                    PublisherId = 2
                },
                new Book
                {
                    Id = 4,
                    Title = "Murder on the Orient Express",
                    Description = "A detective novel featuring Hercule Poirot.",
                    Price = 20m,
                    PublicationYear = 1934,
                    StockQuantity = 18,
                    IsBestSeller = true,
                    CategoryId = 7,
                    AuthorId = 4,
                    PublisherId = 3
                },
                new Book
                {
                    Id = 5,
                    Title = "Sapiens",
                    Description = "A brief history of humankind.",
                    Price = 28m,
                    PublicationYear = 2011,
                    StockQuantity = 22,
                    IsRecommended = true,
                    CategoryId = 4,
                    AuthorId = 5,
                    PublisherId = 1,
                    FlashSaleId = 2,
                    FlashSalePrice = 22m,
                    FlashSaleStock = 8,
                    FlashSaleSoldQuantity = 0
                },
                new Book
                {
                    Id = 6,
                    Title = "Atomic Habits",
                    Description = "A practical guide to building good habits.",
                    Price = 24m,
                    DiscountPrice = 20m,
                    PublicationYear = 2018,
                    StockQuantity = 35,
                    IsBestSeller = true,
                    IsRecommended = true,
                    CategoryId = 6,
                    AuthorId = 6,
                    PublisherId = 1,
                    FlashSaleId = 2,
                    FlashSalePrice = 18m,
                    FlashSaleStock = 8,
                    FlashSaleSoldQuantity = 0
                },
                new Book
                {
                    Id = 7,
                    Title = "The Shining",
                    Description = "A horror novel set in an isolated hotel.",
                    Price = 23m,
                    PublicationYear = 1977,
                    StockQuantity = 15,
                    CategoryId = 1,
                    AuthorId = 7,
                    PublisherId = 3
                },
                new Book
                {
                    Id = 8,
                    Title = "The Alchemist",
                    Description = "A philosophical novel about following your dreams.",
                    Price = 17m,
                    PublicationYear = 1988,
                    StockQuantity = 32,
                    IsBestSeller = true,
                    CategoryId = 1,
                    AuthorId = 8,
                    PublisherId = 1
                },
                new Book
                {
                    Id = 9,
                    Title = "The Subtle Art of Not Giving a F*ck",
                    Description = "A counterintuitive approach to living a better life.",
                    Price = 21m,
                    PublicationYear = 2016,
                    StockQuantity = 27,
                    IsRecommended = true,
                    CategoryId = 6,
                    AuthorId = 9,
                    PublisherId = 2
                },
                new Book
                {
                    Id = 10,
                    Title = "The Psychology of Money",
                    Description = "Timeless lessons on wealth, greed and happiness.",
                    Price = 19m,
                    PublicationYear = 2020,
                    StockQuantity = 28,
                    IsRecommended = true,
                    CategoryId = 5,
                    AuthorId = 10,
                    PublisherId = 1
                },
                new Book
                {
                    Id = 11,
                    Title = "The Pragmatic Programmer",
                    Description = "A guide to practical software development.",
                    Price = 32m,
                    PublicationYear = 1999,
                    StockQuantity = 20,
                    IsRecommended = true,
                    CategoryId = 3,
                    AuthorId = 1,
                    PublisherId = 4
                },
                new Book
                {
                    Id = 12,
                    Title = "Animal Farm",
                    Description = "A political allegory about power and corruption.",
                    Price = 15m,
                    PublicationYear = 1945,
                    StockQuantity = 25,
                    CategoryId = 1,
                    AuthorId = 2,
                    PublisherId = 1
                },
                new Book
                {
                    Id = 13,
                    Title = "Harry Potter and the Chamber of Secrets",
                    Description = "The second adventure at Hogwarts.",
                    Price = 23m,
                    PublicationYear = 1998,
                    StockQuantity = 30,
                    CategoryId = 1,
                    AuthorId = 3,
                    PublisherId = 2
                },
                new Book
                {
                    Id = 14,
                    Title = "And Then There Were None",
                    Description = "A mystery novel about ten strangers on an island.",
                    Price = 19m,
                    PublicationYear = 1939,
                    StockQuantity = 24,
                    IsBestSeller = true,
                    CategoryId = 7,
                    AuthorId = 4,
                    PublisherId = 3
                },
                new Book
                {
                    Id = 15,
                    Title = "Homo Deus",
                    Description = "An exploration of the future of humanity.",
                    Price = 27m,
                    PublicationYear = 2015,
                    StockQuantity = 18,
                    CategoryId = 4,
                    AuthorId = 5,
                    PublisherId = 1
                },
                new Book
                {
                    Id = 16,
                    Title = "Deep Work",
                    Description = "Rules for focused success in a distracted world.",
                    Price = 22m,
                    DiscountPrice = 19m,
                    PublicationYear = 2016,
                    StockQuantity = 26,
                    IsRecommended = true,
                    CategoryId = 6,
                    AuthorId = 6,
                    PublisherId = 4
                },
                new Book
                {
                    Id = 17,
                    Title = "It",
                    Description = "A horror story about a terrifying presence in a small town.",
                    Price = 29m,
                    PublicationYear = 1986,
                    StockQuantity = 12,
                    CategoryId = 1,
                    AuthorId = 7,
                    PublisherId = 3
                },
                new Book
                {
                    Id = 18,
                    Title = "Brida",
                    Description = "A novel about spiritual discovery and personal growth.",
                    Price = 18m,
                    PublicationYear = 1990,
                    StockQuantity = 20,
                    CategoryId = 1,
                    AuthorId = 8,
                    PublisherId = 1
                },
                new Book
                {
                    Id = 19,
                    Title = "Everything Is F*cked",
                    Description = "A book about hope and the human condition.",
                    Price = 20m,
                    PublicationYear = 2019,
                    StockQuantity = 22,
                    CategoryId = 6,
                    AuthorId = 9,
                    PublisherId = 2
                },
                new Book
                {
                    Id = 20,
                    Title = "Same as Ever",
                    Description = "A guide to what never changes in a changing world.",
                    Price = 25m,
                    PublicationYear = 2023,
                    StockQuantity = 16,
                    IsRecommended = true,
                    CategoryId = 5,
                    AuthorId = 10,
                    PublisherId = 1
                }
            );
        }
    }
}
