import {inject, Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {UserDto} from "../model/user/user.dto";
import {ConfigService} from "./ConfigService";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  configService = inject(ConfigService);
  private apiUrl = this.configService.readConfig().API_URL + 'users';
  private authUrl = this.configService.readConfig().API_URL + 'auth';
  constructor(private http: HttpClient) {
    console.log(this.configService.readConfig().API_URL);
  }

  userSignUp(user: UserDto | undefined): Observable<UserDto> {
    let params = new HttpParams();
    return this.http.post<UserDto>(`${this.authUrl}/user`, user);
  }

  checkOutCredentials(userCredentials: any): Observable<any> {
    return this.http.post<boolean>(`${this.authUrl}`, userCredentials);
  }

  getToken(): string | null {
    return sessionStorage.getItem("token");
  }

  getUserId(): string | null {
    return sessionStorage.getItem("userId");
  }

  getUserById(userId: number): Observable<UserDto> {
    const headers = this.createHeaders();
    return this.http.get<UserDto>(`${this.apiUrl}/${userId}`, { headers });
  }
  logout() {
    sessionStorage.removeItem("userId");
    sessionStorage.removeItem("token");
    window.location.reload();
  }

  private createHeaders(): HttpHeaders {
    const authToken = this.getToken();
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${authToken}`
    });
  }
}
