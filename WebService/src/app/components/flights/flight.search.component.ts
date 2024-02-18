import { Component } from "@angular/core";
import { CountryService } from '../../services/country.service';
import { CountryDto } from '../../model/countries/CountryDto';
import { FlightsService } from "../../services/flights.service";
import { AirportDto } from "../../model/airport/airport.dto";

@Component({
    selector: 'flight-search',
    templateUrl: './flight.search.component.html',
    styleUrl: './flight.search.component.css'
  })
  export class FlightsSerarchComponent {

    constructor(private countryService: CountryService, private flightService: FlightsService) { }

    countries: CountryDto[ ] = [];
  
    filteredCountries: any[] = [];
    originResults: AirportDto[] = [];

    countryOriginSelected?: CountryDto;
    isOriginDisabled: boolean = true;
    origintCityText?:string ;

    destinationResults: AirportDto[] = [];
    countryDestinationSelected?: CountryDto;
    isDestinationDisabled: boolean = true;
    destinationCityText?:string ;
  
    ngOnInit(): void {
      this.countryService.getCountries().subscribe(data => {
        this.countries = data.countries;
      });
    }
  
    onCountryOriginSelected(country: CountryDto) {
      if(country != null){
        this.countryOriginSelected = country;
        this.isOriginDisabled = false;
      }
    }
    onCountryDestinationSelected(country: CountryDto) {
      if(country != null){
        this.countryDestinationSelected = country;
        this.isDestinationDisabled = false;
      }
    }

    filterCountries(event: any) {
      const value = event.target.value;
      this.filteredCountries = this.countries.filter(country =>
        country.name.toLowerCase().includes(value.toLowerCase())
      );
    }
  
    searchOrigins() {
      if(this.countryOriginSelected != null && this.origintCityText!=null){
        this.flightService.getAirports(this.countryOriginSelected.code, this.origintCityText).subscribe(data=>{
          this.originResults = data.airports;
        });
        
      }

    }
    searchDestinations() {
      if(this.countryDestinationSelected != null && this.destinationCityText!=null){
        this.flightService.getAirports(this.countryDestinationSelected.code, this.destinationCityText).subscribe(data=>{
          this.destinationResults = data.airports;
        });
        
      }

    }
  
  }