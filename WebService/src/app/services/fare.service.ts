import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { CountryResultDto } from '../model/countries/CountryResultDto';
import { FareResultDto } from '../model/fares/fare.result.dto';


@Injectable({
  providedIn: 'root'
})
export class FareService {

  private apiUrl = environment.faresEndPoint;

  constructor(private http: HttpClient) { }

  getFares(): Observable<FareResultDto> {
    return this.http.get<FareResultDto>(this.apiUrl);
  }
}