using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WS.DataServices.Model
{
    public class HotelReservation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Reservation")]
        public int ReservationID { get; set; }
        public string HotelId { get; set; }
        public string HotelName { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
    }
}
