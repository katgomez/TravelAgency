using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using TravelAgencyStatistics.Model;

internal class Program
{
    private static void Main(string[] args)
    {

        IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var urlDataService = config["ConnectionStrings:ReservationsEndPoint"];
        Console.Clear();

        while (true)
        {
            string opcion = solicitarOpcion();



            switch (opcion)
            {
                case "1":
                    // Lógica para la operación 1
                    Console.WriteLine("Realizando operación 1...");
                    Console.ReadLine();
                    break;
                case "2":
                    // Lógica para la operación 2
                    Console.WriteLine("Realizando operación 2...");
                    Console.ReadLine(); 
                    break;
                case "3":
                    // Lógica para consultar estadísticas
                    Console.WriteLine("Consultando estadísticas...");
                    ShowStatisticsMoreSearchedAirports(urlDataService);
                    Console.ReadLine(); 

                    Console.ReadLine(); 
                    break;
                case "4":
                    return; 
                default:
                    Console.WriteLine("Opción no válida. Presione Enter para continuar.");
                    Console.ReadLine(); 
                    break;
            }
        }
        static string solicitarOpcion()
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Realizar operación 1");
            Console.WriteLine("2. Realizar operación 2");
            Console.WriteLine("3. Consultar estadísticas");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            return Console.ReadLine();
        }
        static void ShowStatisticsMoreSearchedAirports(string url)
        {
            var client = new RestClient(url);


            var request = new RestRequest("statistics", Method.Get);
            List<AirportStatisticsInfo> result = JsonConvert.DeserializeObject<List<AirportStatisticsInfo>>(client.ExecuteAsync<List<AirportStatisticsInfo>>(request).Result.Content );

            long total = result.Sum(c => c.AirportCount);
            Console.WriteLine("MORE SEARCHED AIRPORTS STATISTICS");
            Console.WriteLine("Iata code \t Reservations %");
            foreach (var airportCount in result)
            {
               
                Console.WriteLine(airportCount.AirportCode +" \t "+ ((double)airportCount.AirportCount / total * 100));
                
            }


        }
    }
}