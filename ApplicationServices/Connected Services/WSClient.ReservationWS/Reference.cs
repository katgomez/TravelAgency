﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSClient.ReservationWS
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Reservation", Namespace="http://schemas.datacontract.org/2004/07/WS.DataServices.Model")]
    public partial class Reservation : object
    {
        
        private WSClient.ReservationWS.FlightReservation FlightReservationField;
        
        private int IdField;
        
        private int NumberOfClientsField;
        
        private decimal PriceField;
        
        private System.DateTime ReservationDateField;
        
        private string ReservationStatusField;
        
        private int UserIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WSClient.ReservationWS.FlightReservation FlightReservation
        {
            get
            {
                return this.FlightReservationField;
            }
            set
            {
                this.FlightReservationField = value;
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
        public int NumberOfClients
        {
            get
            {
                return this.NumberOfClientsField;
            }
            set
            {
                this.NumberOfClientsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price
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
        public System.DateTime ReservationDate
        {
            get
            {
                return this.ReservationDateField;
            }
            set
            {
                this.ReservationDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ReservationStatus
        {
            get
            {
                return this.ReservationStatusField;
            }
            set
            {
                this.ReservationStatusField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId
        {
            get
            {
                return this.UserIdField;
            }
            set
            {
                this.UserIdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FlightReservation", Namespace="http://schemas.datacontract.org/2004/07/WS.DataServices.Model")]
    public partial class FlightReservation : object
    {
        
        private string AirlineField;
        
        private string DepartureAirportField;
        
        private System.DateTime DepartureDateField;
        
        private string DestinationAirportField;
        
        private System.DateTime DestinationDateField;
        
        private string FlightIdField;
        
        private int IdField;
        
        private decimal PriceField;
        
        private int ReservationIDField;
        
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
        public string DestinationAirport
        {
            get
            {
                return this.DestinationAirportField;
            }
            set
            {
                this.DestinationAirportField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DestinationDate
        {
            get
            {
                return this.DestinationDateField;
            }
            set
            {
                this.DestinationDateField = value;
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
        public decimal Price
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
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ws.agencytravel/reservation/", ConfigurationName="WSClient.ReservationWS.IReservationServices")]
    public interface IReservationServices
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.agencytravel/reservation/IReservationServices/GetReservations", ReplyAction="http://ws.agencytravel/reservation/IReservationServices/GetReservationsResponse")]
        System.Threading.Tasks.Task<WSClient.ReservationWS.Reservation[]> GetReservationsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.agencytravel/reservation/IReservationServices/GetReservation", ReplyAction="http://ws.agencytravel/reservation/IReservationServices/GetReservationResponse")]
        System.Threading.Tasks.Task<WSClient.ReservationWS.Reservation> GetReservationAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.agencytravel/reservation/IReservationServices/CreateReservation", ReplyAction="http://ws.agencytravel/reservation/IReservationServices/CreateReservationResponse" +
            "")]
        System.Threading.Tasks.Task CreateReservationAsync(WSClient.ReservationWS.Reservation reservation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.agencytravel/reservation/IReservationServices/UpdateReservation", ReplyAction="http://ws.agencytravel/reservation/IReservationServices/UpdateReservationResponse" +
            "")]
        System.Threading.Tasks.Task UpdateReservationAsync(WSClient.ReservationWS.Reservation reservation);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IReservationServicesChannel : WSClient.ReservationWS.IReservationServices, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class ReservationServicesClient : System.ServiceModel.ClientBase<WSClient.ReservationWS.IReservationServices>, WSClient.ReservationWS.IReservationServices
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ReservationServicesClient() : 
                base(ReservationServicesClient.GetDefaultBinding(), ReservationServicesClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IReservationServices.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ReservationServicesClient(EndpointConfiguration endpointConfiguration) : 
                base(ReservationServicesClient.GetBindingForEndpoint(endpointConfiguration), ReservationServicesClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ReservationServicesClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ReservationServicesClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ReservationServicesClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ReservationServicesClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ReservationServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<WSClient.ReservationWS.Reservation[]> GetReservationsAsync()
        {
            return base.Channel.GetReservationsAsync();
        }
        
        public System.Threading.Tasks.Task<WSClient.ReservationWS.Reservation> GetReservationAsync(int id)
        {
            return base.Channel.GetReservationAsync(id);
        }
        
        public System.Threading.Tasks.Task CreateReservationAsync(WSClient.ReservationWS.Reservation reservation)
        {
            return base.Channel.CreateReservationAsync(reservation);
        }
        
        public System.Threading.Tasks.Task UpdateReservationAsync(WSClient.ReservationWS.Reservation reservation)
        {
            return base.Channel.UpdateReservationAsync(reservation);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IReservationServices))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IReservationServices))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:9090/ReservationServices.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ReservationServicesClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IReservationServices);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ReservationServicesClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IReservationServices);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IReservationServices,
        }
    }
}
