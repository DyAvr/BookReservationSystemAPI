using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReservationSystemAPI.Migrations
{
    public partial class AddInitialBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Title" },
                values: new object[,]
                {
                    { 1, "Suzanne Collins", "The Hunger Games" },
                    { 2, "J.K. Rowling", "Harry Potter and the Order of the PhoenixL" },
                    { 3, "Jane Austen", "Pride and Prejudice" },
                    { 4, "Harper Lee", "To Kill a Mockingbird" },
                    { 5, "Markus Zusak", "The Book Thief" },
                    { 6, "Stephenie Meyer", "Twilight" }
                });
        }

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
        }
    }
}
