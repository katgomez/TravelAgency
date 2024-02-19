import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
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

  private searchUrl = environment.flightsSearchEndPoint;
  private reservationUrl = environment.flightsReservationEndPoint;

  constructor(private http: HttpClient) { }

  searchFlights(originCode:string, destinationCode:string, departureDate:string, returnDate:string, adults:number, fare:string): Observable<FlightSearchResultDto> {
    let params = new HttpParams();
    params = params.append('originCode', originCode);
    params = params.append('destinationCode', destinationCode);
    params = params.append('departureDate', departureDate);
    if(returnDate!=null){
      params = params.append('returnDate', returnDate);
    }
    params = params.append('adults', adults);
    params = params.append('fareType', fare);

    return this.http.get<FlightSearchResultDto>(this.searchUrl, { params });
  }

  makeReservation(flightCode:string): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post<FlightSearchResultDto>(this.reservationUrl, {flightSearchCode:flightCode},httpOptions);
  }
}