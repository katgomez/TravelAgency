import { Component } from "@angular/core";
import { CountryService } from '../../services/country.service';
import { CountryDto } from '../../model/countries/CountryDto';
import { FlightsService } from "../../services/flights.service";
import { AirportDto } from "../../model/airport/airport.dto";
import { FormBuilder, FormGroup } from "@angular/forms";
import { FlightSearchResultDto } from "../../model/flights/flight.search.result.dto";
import { FlightResultDto } from "../../model/flights/flight.result.dto";
import { FareService } from "../../services/fare.service";
import { FareResultDto } from "../../model/fares/fare.result.dto";
import { FareDto } from "../../model/fares/fare.dto";
import { AirportService } from "../../services/airport.service";

@Component({
  selector: 'flight-search',
  templateUrl: './flight.search.component.html',
  styleUrl: './flight.search.component.css'
})
export class FlightsSerarchComponent {

  constructor(private countryService: CountryService, private flightService: FlightsService, private fareService: FareService,
     private airportService: AirportService,private formBuilder: FormBuilder) {

    this.flightsSearchForm = this.formBuilder.group({
      countryOrigin: [],
      origin: [],
      originText: [],
      countryDestination: [],
      destination: [],
      destinationText: [''],
      departureDate: [],
      returnDate: [],
      passengers: [1],
      fare: [this.fares.length > 0 ? this.fares[0] : null]
    });

    this.flightsSearchForm.get('countryOrigin')?.valueChanges.subscribe((valor) => {
      this.countryOriginSelected = valor;
      this.flightsSearchForm.patchValue({
        origin: []
      });
    });
    this.flightsSearchForm.get('originText')?.valueChanges.subscribe((valor) => {
      this.origintCityText = valor;
    });
    this.flightsSearchForm.get('countryDestination')?.valueChanges.subscribe((valor) => {
      this.countryDestinationSelected = valor;
      this.flightsSearchForm.patchValue({
        destination: []
        
      });
    });
    this.flightsSearchForm.get('destinationText')?.valueChanges.subscribe((valor) => {
      this.destinationCityText = valor;
    });


  }

  fares: FareDto[] = [];

  flightsSearchForm: FormGroup;

  countries: CountryDto[] = [];

  filteredCountries: any[] = [];
  originResults: AirportDto[] = [];

  countryOriginSelected?: string;
  isOriginDisabled: boolean = true;
  origintCityText?: string;

  destinationResults: AirportDto[] = [];
  countryDestinationSelected?: string;
  isDestinationDisabled: boolean = true;
  destinationCityText?: string;

  flights?: FlightSearchResultDto;

  ngOnInit(): void {
    this.countryService.getCountries().subscribe(data => {
      this.countries = data.countries;
    });

    this.fareService.getFares().subscribe(data=>{
      this.fares = data.fares;

    });
  }




  filterCountries(event: any) {
    const value = event.target.value;
    this.filteredCountries = this.countries.filter(country =>
      country.name.toLowerCase().includes(value.toLowerCase())
    );
  }


  searchOrigins() {
    console.log(this.countryOriginSelected);
    console.log(this.origintCityText);
    const valorSeleccionado = this.flightsSearchForm.get('origin')?.value;
    console.log('Valor seleccionado:', valorSeleccionado);

    this.flightsSearchForm.patchValue({
      origin: []
    });
    if (this.countryOriginSelected != null && this.origintCityText != null) {
      this.airportService.getAirports(this.countryOriginSelected, this.origintCityText).subscribe(data => {
        this.originResults = data.airports;
      });

    }

  }
  searchDestinations() {
    this.flightsSearchForm.patchValue({
      destination: []
    });
    if (this.countryDestinationSelected != null && this.destinationCityText != null) {
      this.airportService.getAirports(this.countryDestinationSelected, this.destinationCityText).subscribe(data => {
        console.log(data);
        this.destinationResults = data.airports;
      });

    }

  }

  buyFlight(flight: FlightResultDto) {

  }

  onSubmitSearch() {
    const origen = this.flightsSearchForm.value.origin?.iataCode;
    const destination = this.flightsSearchForm.value.destination?.iataCode;
    const departureDate = this.flightsSearchForm.value.departureDate;
    const returnDate = this.flightsSearchForm.value.returnDate;
    const fare = this.flightsSearchForm.value.fare;
    const passengers: number = this.flightsSearchForm.value.passengers;
    console.log(this.flightsSearchForm.value);
    if (origen != null && destination != null && departureDate != null && returnDate != null 
      && passengers != null&& fare !=null) {
      console.log("Buscando vuelos");
      this.flightService.searchFlights(origen, destination, departureDate, returnDate, passengers, fare.name).subscribe(data => {
        this.flights = data;
      });
    }
  }
}