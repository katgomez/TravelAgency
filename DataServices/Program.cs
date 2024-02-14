using WS.DataServices;

internal class Program
{
    public static void Main(string[] args)
    {
        var host = new WebHostBuilder()
        .UseKestrel(x => x.AllowSynchronousIO = true)
        .UseUrls("http://*:9090")
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseStartup<Startup>()
        .ConfigureLogging(x =>
        {
            x.AddDebug();
            x.AddConsole();
        })
        .Build();
        host.Run();
    }

}