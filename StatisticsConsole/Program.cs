
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {

        IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var connection = config.GetValue<string>("ConnectionStrings:AgencyTravelApplication");

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Realizar operación 1");
            Console.WriteLine("2. Realizar operación 2");
            Console.WriteLine("3. Consultar estadísticas");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    // Lógica para la operación 1
                    Console.WriteLine("Realizando operación 1...");
                    Console.ReadLine(); // Espera a que el usuario presione Enter
                    break;
                case "2":
                    // Lógica para la operación 2
                    Console.WriteLine("Realizando operación 2...");
                    Console.ReadLine(); // Espera a que el usuario presione Enter
                    break;
                case "3":
                    // Lógica para consultar estadísticas
                    Console.WriteLine("Consultando estadísticas...");
                    MostrarEstadisticas();
                    Console.ReadLine(); // Espera a que el usuario presione Enter
                    break;
                case "4":
                    return; // Salir del programa
                default:
                    Console.WriteLine("Opción no válida. Presione Enter para continuar.");
                    Console.ReadLine(); // Espera a que el usuario presione Enter
                    break;
            }
        }

        static void MostrarEstadisticas()
        {
            // Aquí puedes calcular y mostrar las estadísticas
            // Por ejemplo:
            Console.WriteLine("Estadísticas:");
            Console.WriteLine("Total de usuarios: 100");
            Console.WriteLine("Usuarios activos: 80");
            Console.WriteLine("Usuarios inactivos: 20");
            // Añade más estadísticas según sea necesario
        }
    }
}