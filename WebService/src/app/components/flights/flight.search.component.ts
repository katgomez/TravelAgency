import { Component } from "@angular/core";
import { CountryService } from '../../services/country.service';
import { CountryDto } from '../../model/countries/CountryDto';
import { FlightsService } from "../../services/flights.service";
import { AirportDto } from "../../model/airport/airport.dto";
import { FormBuilder, FormGroup } from "@angular/forms";

@Component({
    selector: 'flight-search',
    templateUrl: './flight.search.component.html',
    styleUrl: './flight.search.component.css'
  })
  export class FlightsSerarchComponent {

    constructor(private countryService: CountryService, private flightService: FlightsService, private  formBuilder: FormBuilder) { 

      this.flightsSearchForm = this.formBuilder.group({  
        countryOrigin:[''],
        origin:[''],
        originText:[''],
        countryDestination:[''],
        destination:[''],
        destinationText:[''],
        departureDate:[''],
        returnDate:[''],
        passengers:['']
      });

      this.flightsSearchForm.get('countryOrigin')?.valueChanges.subscribe((valor) => {
        this.countryOriginSelected = valor;
      });
      this.flightsSearchForm.get('originText')?.valueChanges.subscribe((valor) => {
        this.origintCityText = valor;
      });
      this.flightsSearchForm.get('countryDestination')?.valueChanges.subscribe((valor) => {
        this.countryDestinationSelected = valor;
      });
      this.flightsSearchForm.get('destinationText')?.valueChanges.subscribe((valor) => {
        this.destinationCityText = valor;
      });


    }

    flightsSearchForm: FormGroup;

    countries: CountryDto[ ] = [];
  
    filteredCountries: any[] = [];
    originResults: AirportDto[] = [];

    countryOriginSelected?: string;
    isOriginDisabled: boolean = true;
    origintCityText?:string ;

    destinationResults: AirportDto[] = [];
    countryDestinationSelected?: string;
    isDestinationDisabled: boolean = true;
    destinationCityText?:string ;

    flights: any[] = [];
  
    ngOnInit(): void {
      this.countryService.getCountries().subscribe(data => {
        this.countries = data.countries;
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
      if(this.countryOriginSelected != null && this.origintCityText!=null){
        this.flightService.getAirports(this.countryOriginSelected, this.origintCityText).subscribe(data=>{
          this.originResults = data.airports;
        });
        
      }

    }
    searchDestinations() {
      if(this.countryDestinationSelected != null && this.destinationCityText!=null){
        this.flightService.getAirports(this.countryDestinationSelected, this.destinationCityText).subscribe(data=>{
          this.destinationResults = data.airports;
        });
        
      }

    }

    selectFlight(event: any){

    }

    onSubmitSearch() {
      const origen = this.flightsSearchForm.value.origin;
      console.log('Nombre:', this.flightsSearchForm.value);
    }
  
  }