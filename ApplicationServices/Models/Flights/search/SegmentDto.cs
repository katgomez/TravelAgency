namespace ApplicationServices.Models.Flights.search
{
    public class SegmentDto
    {
        public string id { get; set; }
        public TravelDto departure { get; set; }
        public TravelDto arrival { get; set; }
        public string carrierCode { get; set; }
        public string number { get; set; }
        public string duration { get; set; }

        public int numberOfStops { get; set; }
        public bool blacklistedInE { get; set; }
    }
}
