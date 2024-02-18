import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { CountryResultDto } from '../model/countries/CountryResultDto';


@Injectable({
  providedIn: 'root'
})
export class CountryService {

  private apiUrl = environment.countriesEndPoint;

  constructor(private http: HttpClient) { }

  getCountries(): Observable<CountryResultDto> {
    return this.http.get<CountryResultDto>(this.apiUrl);
  }
}