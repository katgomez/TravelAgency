using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using TravelAgencyStatistics.Model;

internal class Program

{
    private static void Main(string[] args)
    {

        IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var reservationsEndPoint = config["ConnectionStrings:ReservationsEndPoint"];
        var flightSearchEndPoint = config["ConnectionStrings:FlightSearchEndPoint"];
        string token = config["ConnectionStrings:token"];
        Console.Clear();

        while (true)
        {
            string opcion = solicitarOpcion();



            switch (opcion)
            {
                case "1":
                    // Lógica para la operación 1
                    Console.WriteLine("Realizando operación 1...");
                    Console.WriteLine("Press Enter to continue ...");
                    Console.ReadLine();
                    break;
                case "2":
                    // Lógica para la operación 2
                    Console.WriteLine("Requesting...");
                    ShowAirportsStatistics(flightSearchEndPoint, token, "MORE SEARCHED AIRPORTS STATISTICS");
                    Console.WriteLine("Press Enter to continue ...");
                    Console.ReadLine(); 
                    break;
                case "3":
                    // Lógica para consultar estadísticas
                    Console.WriteLine("Requesting statistics...");
                    ShowAirportsStatistics(reservationsEndPoint,token, "AIRPORTS WITH MORE RESERVATIONS");
                    Console.WriteLine("Press Enter to continue ...");
                    Console.ReadLine(); 

                    break;
                case "4":
                    return; 
                default:
                    Console.WriteLine("Not valid. Press Enter to continue");
                    Console.WriteLine("Press Enter to continue ...");
                    Console.ReadLine(); 
                    break;
            }
        }
        static string solicitarOpcion()
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Show number of users");
            Console.WriteLine("2. Show most booked airports");
            Console.WriteLine("3. Show most searched airports");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            return Console.ReadLine();
        }
        static void ShowAirportsStatistics(string url,string token, string title)
        {
            var client = new RestClient(url);


            var request = new RestRequest("statistics", Method.Get);
            request.AddHeader("Authorization", "Bearer " + token);
            List<AirportStatisticsInfo> result = JsonConvert.DeserializeObject<List<AirportStatisticsInfo>>(client.ExecuteAsync<List<AirportStatisticsInfo>>(request).Result.Content );

            long total = result.Sum(c => c.AirportCount);
            Console.WriteLine(title);
            Console.WriteLine("Iata code \t Total\t Percentage %");
            foreach (var airportCount in result)
            {
               
                Console.WriteLine(airportCount.AirportCode + " \t\t" + airportCount.AirportCount + " \t\t " + ((double)airportCount.AirportCount / total * 100));
                
            }


        }
    }
}