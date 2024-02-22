using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataServices.Model
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfClients { get; set; }
        public string ReservationStatus { get; set; } = "started";
        public decimal Price { get; set; }
        public FlightReservation FlightReservations { get; set; }

    }
}
