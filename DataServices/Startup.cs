using Microsoft.Extensions.DependencyInjection.Extensions;
using SoapCore;
using System.ServiceModel;
using WS.DataServices.Model;
using WS.DataServices.Service;

namespace WS.DataServices
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IUserServices, UserServices>();
            services.TryAddSingleton<IReservationServices, ReservationServices>();
            services.TryAddSingleton<IFlightReservationServices, FlightReservationServices>();
            services.AddMvc(x => x.EnableEndpointRouting = false);
            services.AddSoapCore();
            services.AddDbContext<DataContext>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = new DataContext();
                //context.Database.EnsureDeleted(); //Delete ddbb always
                context.Database.EnsureCreated();
            }
            app.UseSoapEndpoint<IUserServices>("/UserServices.svc", new BasicHttpBinding(), SoapSerializer.DataContractSerializer,
            false, null, null, true, true);
            app.UseSoapEndpoint<IReservationServices>("/ReservationServices.svc", new BasicHttpBinding(), SoapSerializer.DataContractSerializer,
                false, null, null, true, true);
            app.UseSoapEndpoint<IFlightReservationServices>("/FlightServices.svc", new BasicHttpBinding(), SoapSerializer.DataContractSerializer,
                false, null, null, true, true);
            app.UseMvc();
        }
    }
}
