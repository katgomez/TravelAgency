using Client.Model.Country;
using Client.Models.Flights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RestSharp;

namespace Client.Controllers
{
    public class FlightSearchController : Controller
    {
        private IConfiguration _configuration;
        public FlightSearchController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }


        public async Task<IActionResult> Index()
        {
            var client = new RestClient(_configuration.GetValue<string>("ApplicationSettings:CountriesEndPoint"));

            var request = new RestRequest("", Method.Get);

            CountryResultDto dto = client.ExecuteAsync<CountryResultDto>(request).Result.Data;

            ViewBag.Countries = dto;

            return View();
        }

        [HttpGet]
        public IActionResult GetFilteredAirports(string searchText, string country)
        {
            var client = new RestClient(_configuration.GetValue<string>("ApplicationSettings:FlightEndPoint"));

            var request = new RestRequest("airports", Method.Get);
            request.AddParameter("countryCode", country, ParameterType.QueryString);
            request.AddParameter("city", searchText, ParameterType.QueryString);

            AirportResultDto result = client.ExecuteAsync<AirportResultDto>(request).Result.Data;
            var filteredOptions = new List<SelectListItem>();


            foreach (AirportDto airport in result.airports)
            {
                string airportJson = JsonConvert.SerializeObject(airport);

                // Agregar un SelectListItem para cada aeropuert
                filteredOptions.Add(new SelectListItem { Value = airportJson, Text = airport.name });

            }


            // Devolver las opciones filtradas en formato JSON
            return Ok(filteredOptions);
        }

        [HttpPost]
        public IActionResult Search(AirportDto originOptions, string destinationOptions, string departureDate, string returnDate, int numPasajeros)
        {
            AirportDto originAirport = JsonConvert.DeserializeObject<AirportDto>(destinationOptions);

            // Convertir las fechas de cadena a objetos DateTime
            DateTime departureDateTime = DateTime.Parse(departureDate);
            DateTime? returnDateTime = !string.IsNullOrEmpty(returnDate) ? DateTime.Parse(returnDate) : (DateTime?)null;

            // Aquí puedes realizar las operaciones necesarias con los parámetros recibidos
            // Por ejemplo, buscar vuelos con los datos proporcionados

            // Luego, puedes redirigir a una vista de resultados, por ejemplo:
            return View();
        }
    }
}
