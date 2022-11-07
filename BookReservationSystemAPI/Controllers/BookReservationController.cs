using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReservationSystemAPI.Data;
using BookReservationSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookReservationSystemAPI.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class BookReservationController: ControllerBase {
        private readonly DataContext _context;

        public BookReservationController(DataContext context) {
            _context = context;
        }

        [Route("Available")]
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAvailableBooks() {
            var reservedIds = _context.Reservations.Select( r => r.BookId).ToList();
            return Ok(await _context.Books.Where( b => !reservedIds.Contains(b.Id)).ToListAsync());
        }

        [Route("Reserved")]
        [HttpGet]
        public ActionResult<List<object>> GetReservedBooks() {
            var reserved = _context.Reservations.Select( r => 
                new {r.BookId, Book = _context.Books.First(b => b.Id == r.BookId), r.Comment}).ToList();
            return Ok(reserved);
        }

        [Route("Reserve")]
        [HttpPost]
        public async Task<ActionResult<Reservation>> ReserveBook(int bookId, string comment) {
            var prev = _context.Reservations.FirstOrDefault(r => r.BookId == bookId);
            if(prev != null) {
                return BadRequest("Book is already reserved.");
            }
            var reservation = new Reservation {
                BookId = bookId,
                Comment = comment
            };
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return Ok(reservation);
        }

        [Route("Return")]
        [HttpPost]
        public async Task<ActionResult<Reservation>> DeleteReservation(int bookId) {
            var reservation = _context.Reservations.FirstOrDefault(r => r.BookId == bookId);
            if(reservation == null) {
                return BadRequest("Book isn't reserved.");
            }
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return Ok(reservation);
        }


    }
}
