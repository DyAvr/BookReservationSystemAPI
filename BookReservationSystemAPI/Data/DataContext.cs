using BookReservationSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReservationSystemAPI.Data {
    public class DataContext: DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Book>().HasData(
                    new Book { Id = 1, Title = "The Hunger Games", Author = "Suzanne Collins" },
                    new Book { Id = 2, Title = "Harry Potter and the Order of the PhoenixL", Author = "J.K. Rowling" },
                    new Book { Id = 3, Title = "Pride and Prejudice", Author = "Jane Austen" },
                    new Book { Id = 4, Title = "To Kill a Mockingbird", Author = "Harper Lee" },
                    new Book { Id = 5, Title = "The Book Thief", Author = "Markus Zusak" },
                    new Book { Id = 6, Title = "Twilight", Author = "Stephenie Meyer" }
            );
        }
    }
}
