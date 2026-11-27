using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Book_Shop.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin" },
                    { 2, "George Orwell" },
                    { 3, "J. K. Rowling" },
                    { 4, "Agatha Christie" },
                    { 5, "Yuval Noah Harari" },
                    { 6, "James Clear" },
                    { 7, "Stephen King" },
                    { 8, "Paulo Coelho" },
                    { 9, "Mark Manson" },
                    { 10, "Morgan Housel" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fiction" },
                    { 2, "Science" },
                    { 3, "Technology" },
                    { 4, "History" },
                    { 5, "Business" },
                    { 6, "Self Development" },
                    { 7, "Mystery" },
                    { 8, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "FlashSales",
                columns: new[] { "Id", "Description", "EndTime", "IsActive", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1, "Special discounts on selected books", new DateTime(2030, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekend Book Deals" },
                    { 2, "Limited offers on popular books", new DateTime(2030, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best Sellers Sale" }
                });

            migrationBuilder.InsertData(
                table: "PromoCodes",
                columns: new[] { "Id", "Code", "DiscountPercentage", "ExpiryDate", "IsActive" },
                values: new object[,]
                {
                    { 1, "WELCOME10", 10m, new DateTime(2030, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 2, "BOOK20", 20m, new DateTime(2030, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 3, "READ15", 15m, new DateTime(2030, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Penguin Random House" },
                    { 2, "HarperCollins" },
                    { 3, "Simon & Schuster" },
                    { 4, "Macmillan Publishers" },
                    { 5, "Hachette Book Group" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CoverImageUrl", "Description", "DiscountPrice", "FlashSaleId", "FlashSalePrice", "FlashSaleSoldQuantity", "FlashSaleStock", "IsBestSeller", "IsRecommended", "Price", "PublicationYear", "PublisherId", "StockQuantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, 3, null, "A handbook of agile software craftsmanship.", null, 1, 18m, 0, 10, false, true, 30m, 2008, 1, 25, "Clean Code" },
                    { 2, 2, 1, null, "A dystopian novel about surveillance and totalitarianism.", null, 1, 15m, 0, 10, true, false, 18m, 1949, 1, 30, "1984" },
                    { 3, 3, 1, null, "The first book in the Harry Potter fantasy series.", null, null, null, 0, 0, true, false, 22m, 1997, 2, 40, "Harry Potter and the Philosopher's Stone" },
                    { 4, 4, 7, null, "A detective novel featuring Hercule Poirot.", null, null, null, 0, 0, true, false, 20m, 1934, 3, 18, "Murder on the Orient Express" },
                    { 5, 5, 4, null, "A brief history of humankind.", null, 2, 22m, 0, 8, false, true, 28m, 2011, 1, 22, "Sapiens" },
                    { 6, 6, 6, null, "A practical guide to building good habits.", 20m, 2, 18m, 0, 8, true, true, 24m, 2018, 1, 35, "Atomic Habits" },
                    { 7, 7, 1, null, "A horror novel set in an isolated hotel.", null, null, null, 0, 0, false, false, 23m, 1977, 3, 15, "The Shining" },
                    { 8, 8, 1, null, "A philosophical novel about following your dreams.", null, null, null, 0, 0, true, false, 17m, 1988, 1, 32, "The Alchemist" },
                    { 9, 9, 6, null, "A counterintuitive approach to living a better life.", null, null, null, 0, 0, false, true, 21m, 2016, 2, 27, "The Subtle Art of Not Giving a F*ck" },
                    { 10, 10, 5, null, "Timeless lessons on wealth, greed and happiness.", null, null, null, 0, 0, false, true, 19m, 2020, 1, 28, "The Psychology of Money" },
                    { 11, 1, 3, null, "A guide to practical software development.", null, null, null, 0, 0, false, true, 32m, 1999, 4, 20, "The Pragmatic Programmer" },
                    { 12, 2, 1, null, "A political allegory about power and corruption.", null, null, null, 0, 0, false, false, 15m, 1945, 1, 25, "Animal Farm" },
                    { 13, 3, 1, null, "The second adventure at Hogwarts.", null, null, null, 0, 0, false, false, 23m, 1998, 2, 30, "Harry Potter and the Chamber of Secrets" },
                    { 14, 4, 7, null, "A mystery novel about ten strangers on an island.", null, null, null, 0, 0, true, false, 19m, 1939, 3, 24, "And Then There Were None" },
                    { 15, 5, 4, null, "An exploration of the future of humanity.", null, null, null, 0, 0, false, false, 27m, 2015, 1, 18, "Homo Deus" },
                    { 16, 6, 6, null, "Rules for focused success in a distracted world.", 19m, null, null, 0, 0, false, true, 22m, 2016, 4, 26, "Deep Work" },
                    { 17, 7, 1, null, "A horror story about a terrifying presence in a small town.", null, null, null, 0, 0, false, false, 29m, 1986, 3, 12, "It" },
                    { 18, 8, 1, null, "A novel about spiritual discovery and personal growth.", null, null, null, 0, 0, false, false, 18m, 1990, 1, 20, "Brida" },
                    { 19, 9, 6, null, "A book about hope and the human condition.", null, null, null, 0, 0, false, false, 20m, 2019, 2, 22, "Everything Is F*cked" },
                    { 20, 10, 5, null, "A guide to what never changes in a changing world.", null, null, null, 0, 0, false, true, 25m, 2023, 1, 16, "Same as Ever" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FlashSales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FlashSales",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
