import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { CountryResultDto } from '../model/countries/CountryResultDto';
import { AirportDto } from '../model/airport/airport.dto';
import { AirportResultDto } from '../model/airport/airport.result.dto';
import { FlightSearchResultDto } from '../model/flights/flight.search.result.dto';


@Injectable({
  providedIn: 'root'
})
export class FlightsService {

  private apiUrl = environment.flightsSearchEndPoint;

  constructor(private http: HttpClient) { }

  getAirports(countryCode:string, city:string): Observable<AirportResultDto> {
    let params = new HttpParams();
    params = params.append('countryCode', countryCode);
    params = params.append('city', city);

    return this.http.get<AirportResultDto>(this.apiUrl + "/airports", { params });
  }

  searchFlights(originCode:string, destinationCode:string, departureDate:string, returnDate:string, adults:number): Observable<FlightSearchResultDto> {
    let params = new HttpParams();
    params = params.append('originCode', originCode);
    params = params.append('destinationCode', destinationCode);
    params = params.append('departureDate', departureDate);
    params = params.append('returnDate', returnDate);
    params = params.append('adults', adults);
    params = params.append('fareType', 'ECONOMIC');

    return this.http.get<FlightSearchResultDto>(this.apiUrl, { params });
  }
}