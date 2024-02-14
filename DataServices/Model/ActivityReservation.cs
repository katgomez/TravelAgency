using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WS.DataServices.Model
{
    public class ActivityReservation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Reservation")]
        public int ReservationID { get; set; }
        public string ActivityId { get; set; }
        public string ActivityName { get; set; }
        public DateOnly ActivityDate { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
    }
}
