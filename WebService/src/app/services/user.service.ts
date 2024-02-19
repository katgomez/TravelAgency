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

  constructor(private http: HttpClient) { }

  userSignUp(user: UserDto | undefined): Observable<UserDto> {
    let params = new HttpParams();
    return this.http.post<UserDto>(this.apiUrl, user);
  }
  checkOutCredentials(userCredentials: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/check-credentials`, userCredentials);
  }
  getUserById(userId: number): Observable<UserDto> {
    return this.http.get<UserDto>(`${this.apiUrl}/${userId}`);
  }
}
