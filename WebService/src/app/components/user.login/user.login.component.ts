import { Component } from '@angular/core';
import {UserService} from "../../services/user.service";
import {catchError, of, tap} from "rxjs";
import {UserDto} from "../../model/user/user.dto";
import {error} from "@angular/compiler-cli/src/transformers/util";

@Component({
  selector: 'app-user.login',
  templateUrl: './user.login.component.html',
  styleUrl: './user.login.component.css'
})
export class UserLoginComponent {
  _userData!: UserDto;

  get userData(): UserDto {
    return this._userData;
  }
  set userData(value: UserDto) {
    this._userData = value;
  }
  constructor(private userService: UserService) {}

  ngOnInit() {
  }

  login(data: UserDto) {
    this.userService.getUserByEmail(data.email)
      .pipe(
        tap(user => {
          this._userData = user;
          console.log('User found:', user);
        }),
        catchError(error => {
          console.error('Error finding user:', error);
          return of(null); // Return observable with null value to continue the stream
        })
      )
      .subscribe();
  }
}
