import {inject, Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { CountryResultDto } from '../model/countries/CountryResultDto';
import {ConfigService} from "./ConfigService";


@Injectable({
  providedIn: 'root'
})
export class CountryService {
  configService = inject(ConfigService);

  private apiUrl = this.configService.readConfig().API_URL + 'countries';
  constructor(private http: HttpClient) { }

  getCountries(): Observable<CountryResultDto> {
    return this.http.get<CountryResultDto>(this.apiUrl);
  }
}
