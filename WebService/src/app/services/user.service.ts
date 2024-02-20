import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpParams} from "@angular/common/http";
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
    return this.http.post<UserDto>(this.apiUrl, user);
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

  logout() {
    sessionStorage.removeItem("token");
    sessionStorage.removeItem("token");
  }
}
