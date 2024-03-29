import {inject, Injectable} from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { CountryResultDto } from '../model/countries/CountryResultDto';
import { AirportDto } from '../model/airport/airport.dto';
import { AirportResultDto } from '../model/airport/airport.result.dto';
import { FlightSearchResultDto } from '../model/flights/flight.search.result.dto';
import {tap} from "rxjs/operators";
import {UserService} from "./user.service";
import {ReservationDto} from "../model/reservation/reservation.dto";
import {ConfigService} from "./ConfigService";


@Injectable({
  providedIn: 'root'
})
export class FlightsService {
  configService = inject(ConfigService);

  private searchUrl = this.configService.readConfig().API_URL + 'flightsSearch';
  private reservationUrl = this.configService.readConfig().API_URL + 'flightReservations';

  constructor(private http: HttpClient, private userService: UserService) { }

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

  makeReservation(flightCode:string, adults:number): any {
    const headers = this.createHeaders();
    const userId = this.userService.getUserId();
    if (userId) {
      const requestBody = {
        userId: userId,
        adults: adults,
        flightSearchCode: flightCode
      };
    return this.http.post(`${this.reservationUrl}`, requestBody,{ headers });
    }
  }

  private createHeaders(): HttpHeaders {
    const authToken = this.userService.getToken();
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${authToken}`
    });
  }
  getReservationData(userId: string) {
    const headers = this.createHeaders();
    return this.http.get<ReservationDto[]>(`${this.reservationUrl}?userId=${userId}`, { headers });
  }

}
