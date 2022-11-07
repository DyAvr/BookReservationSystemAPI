namespace BookReservationSystemAPI.Models {
    public class Reservation {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Comment { get; set; }
    }
}
