import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { CountryResultDto } from '../model/countries/CountryResultDto';
import { AirportDto } from '../model/airport/airport.dto';
import { AirportResultDto } from '../model/airport/airport.result.dto';


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
}