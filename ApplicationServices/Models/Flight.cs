﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApplicationServices.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public string FlightId { get; set; }
        public string Airline { get; set; }
        public string DestinationAirport { get; set; }
        public DateOnly DestinationDate { get; set; }
        public string DpartureAirport { get; set; }
        public DateOnly DepartureDate { get; set; }
        public decimal Price { get; set; }
    }
}
