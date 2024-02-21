﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSClient.FlightReservation
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FlightReservation", Namespace="http://schemas.datacontract.org/2004/07/DataServices.Model")]
    public partial class FlightReservation : object
    {
        
        private string AirlineField;
        
        private string ArrivalAirportField;
        
        private System.DateTime ArrivalDateField;
        
        private string CodeOfItineraryField;
        
        private string DepartureAirportField;
        
        private System.DateTime DepartureDateField;
        
        private double DurationField;
        
        private string FlightIdField;
        
        private int IdField;
        
        private double PriceField;
        
        private int ReservationIDField;
        
        private int numberOfStopsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Airline
        {
            get
            {
                return this.AirlineField;
            }
            set
            {
                this.AirlineField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ArrivalAirport
        {
            get
            {
                return this.ArrivalAirportField;
            }
            set
            {
                this.ArrivalAirportField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ArrivalDate
        {
            get
            {
                return this.ArrivalDateField;
            }
            set
            {
                this.ArrivalDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodeOfItinerary
        {
            get
            {
                return this.CodeOfItineraryField;
            }
            set
            {
                this.CodeOfItineraryField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DepartureAirport
        {
            get
            {
                return this.DepartureAirportField;
            }
            set
            {
                this.DepartureAirportField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DepartureDate
        {
            get
            {
                return this.DepartureDateField;
            }
            set
            {
                this.DepartureDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Duration
        {
            get
            {
                return this.DurationField;
            }
            set
            {
                this.DurationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FlightId
        {
            get
            {
                return this.FlightIdField;
            }
            set
            {
                this.FlightIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Price
        {
            get
            {
                return this.PriceField;
            }
            set
            {
                this.PriceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ReservationID
        {
            get
            {
                return this.ReservationIDField;
            }
            set
            {
                this.ReservationIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int numberOfStops
        {
            get
            {
                return this.numberOfStopsField;
            }
            set
            {
                this.numberOfStopsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AirportStatisticsInfo", Namespace="http://schemas.datacontract.org/2004/07/ApplicationServices.Models.Statistics")]
    public partial class AirportStatisticsInfo : object
    {
        
        private string AirportCodeField;
        
        private long AirportCountField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AirportCode
        {
            get
            {
                return this.AirportCodeField;
            }
            set
            {
                this.AirportCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long AirportCount
        {
            get
            {
                return this.AirportCountField;
            }
            set
            {
                this.AirportCountField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://agencytravel/flight/", ConfigurationName="WSClient.FlightReservation.IFlightReservationServices")]
    public interface IFlightReservationServices
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://agencytravel/flight/IFlightReservationServices/GetFlights", ReplyAction="http://agencytravel/flight/IFlightReservationServices/GetFlightsResponse")]
        System.Threading.Tasks.Task<WSClient.FlightReservation.FlightReservation[]> GetFlightsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://agencytravel/flight/IFlightReservationServices/GetFlight", ReplyAction="http://agencytravel/flight/IFlightReservationServices/GetFlightResponse")]
        System.Threading.Tasks.Task<WSClient.FlightReservation.FlightReservation> GetFlightAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://agencytravel/flight/IFlightReservationServices/CreateFlight", ReplyAction="http://agencytravel/flight/IFlightReservationServices/CreateFlightResponse")]
        System.Threading.Tasks.Task CreateFlightAsync(WSClient.FlightReservation.FlightReservation flightReservation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://agencytravel/flight/IFlightReservationServices/UpdateFlight", ReplyAction="http://agencytravel/flight/IFlightReservationServices/UpdateFlightResponse")]
        System.Threading.Tasks.Task UpdateFlightAsync(WSClient.FlightReservation.FlightReservation flightReservation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://agencytravel/flight/IFlightReservationServices/GetAirportReservationStatis" +
            "tics", ReplyAction="http://agencytravel/flight/IFlightReservationServices/GetAirportReservationStatis" +
            "ticsResponse")]
        System.Threading.Tasks.Task<WSClient.FlightReservation.AirportStatisticsInfo[]> GetAirportReservationStatisticsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IFlightReservationServicesChannel : WSClient.FlightReservation.IFlightReservationServices, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class FlightReservationServicesClient : System.ServiceModel.ClientBase<WSClient.FlightReservation.IFlightReservationServices>, WSClient.FlightReservation.IFlightReservationServices
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public FlightReservationServicesClient() : 
                base(FlightReservationServicesClient.GetDefaultBinding(), FlightReservationServicesClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IFlightReservationServices.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FlightReservationServicesClient(EndpointConfiguration endpointConfiguration) : 
                base(FlightReservationServicesClient.GetBindingForEndpoint(endpointConfiguration), FlightReservationServicesClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FlightReservationServicesClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(FlightReservationServicesClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FlightReservationServicesClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(FlightReservationServicesClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FlightReservationServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<WSClient.FlightReservation.FlightReservation[]> GetFlightsAsync()
        {
            return base.Channel.GetFlightsAsync();
        }
        
        public System.Threading.Tasks.Task<WSClient.FlightReservation.FlightReservation> GetFlightAsync(int id)
        {
            return base.Channel.GetFlightAsync(id);
        }
        
        public System.Threading.Tasks.Task CreateFlightAsync(WSClient.FlightReservation.FlightReservation flightReservation)
        {
            return base.Channel.CreateFlightAsync(flightReservation);
        }
        
        public System.Threading.Tasks.Task UpdateFlightAsync(WSClient.FlightReservation.FlightReservation flightReservation)
        {
            return base.Channel.UpdateFlightAsync(flightReservation);
        }
        
        public System.Threading.Tasks.Task<WSClient.FlightReservation.AirportStatisticsInfo[]> GetAirportReservationStatisticsAsync()
        {
            return base.Channel.GetAirportReservationStatisticsAsync();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IFlightReservationServices))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IFlightReservationServices))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:9090/FlightServices.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return FlightReservationServicesClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IFlightReservationServices);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return FlightReservationServicesClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IFlightReservationServices);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IFlightReservationServices,
        }
    }
}
