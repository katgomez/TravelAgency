import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {UserDto} from "../model/user/user.dto";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = environment.userEndPoint;
  private authUrl = environment.authEndPoint;
  constructor(private http: HttpClient) {
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
