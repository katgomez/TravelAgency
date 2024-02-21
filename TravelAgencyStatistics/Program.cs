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
        var usersEndPoint = config["ConnectionStrings:UsersEndPoint"];

        string token = config["ConnectionStrings:token"];
        Console.Clear();

        while (true)
        {
            string opcion = solicitarOpcion();



            switch (opcion)
            {
                case "1":
                    // Lógica para la operación 1
                    Console.WriteLine("\nRequesting...");
                    ShowNumberUsers(usersEndPoint, token, "\nSHOWING NUMBER OF USERS IN THE APPLICATION");
                    Console.WriteLine("\nPress Enter to continue ...");
                    Console.ReadLine();
                    break;
                case "2":
                    // Lógica para la operación 2
                    Console.WriteLine("Requesting...");
                    ShowAirportsStatistics(flightSearchEndPoint, token, "\nMORE SEARCHED AIRPORTS STATISTICS");
                    Console.WriteLine("\nPress Enter to continue ...");
                    Console.ReadLine();
                    break;
                case "3":
                    // Lógica para consultar estadísticas
                    Console.WriteLine("\nRequesting statistics...");
                    ShowAirportsStatistics(reservationsEndPoint, token, "\nAIRPORTS WITH MORE RESERVATIONS");
                    Console.WriteLine("\nPress Enter to continue ...");
                    Console.ReadLine();

                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Not valid. Press Enter to continue");
                    Console.WriteLine("\nPress Enter to continue ...");
                    Console.ReadLine();
                    break;
            }
        }
        static string solicitarOpcion()
        {
            Console.WriteLine("\n\nMenú:");
            Console.WriteLine("1. Show number of users");
            Console.WriteLine("2. Show most searched airports");
            Console.WriteLine("3. Show most booked airports");
            Console.WriteLine("4. Salir");
            Console.Write("Select an option: ");

            return Console.ReadLine();
        }
        static void ShowAirportsStatistics(string url, string token, string title)
        {
            var client = new RestClient(url);


            var request = new RestRequest("statistics", Method.Get);
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.ExecuteAsync<List<AirportStatisticsInfo>>(request).Result;

            if (response.IsSuccessful)
            {
                List<AirportStatisticsInfo> result = JsonConvert.DeserializeObject<List<AirportStatisticsInfo>>(response.Content);

                long total = result.Sum(c => c.AirportCount);
                Console.WriteLine(title);
                Console.WriteLine("Iata code \t Total\t Percentage %");
                foreach (var airportCount in result)
                {

                    Console.WriteLine(airportCount.AirportCode + " \t\t" + airportCount.AirportCount + " \t\t " + (Math.Round(((double)airportCount.AirportCount / total * 100)) * 100.0) / 100.0);

                }
                return;
            }
            Console.WriteLine("Error requesting information: ");


        }

        static void ShowNumberUsers(string url, string token, string title)
        {
            var client = new RestClient(url);


            var request = new RestRequest("statistics", Method.Get);
            request.AddHeader("Authorization", "Bearer " + token);
            var response = client.ExecuteAsync(request).Result;
            if (response.IsSuccessful)
            {
                long result = JsonConvert.DeserializeObject<long>(response.Content);

                Console.WriteLine(title);
                Console.WriteLine("Total users: " + result);
                return;
            }
            Console.WriteLine("Error requesting information: ");



        }
    }
}