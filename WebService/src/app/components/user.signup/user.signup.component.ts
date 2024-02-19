import { Component } from '@angular/core';
import { UserDto} from "../../model/user/user.dto";
import {UserService} from "../../services/user.service";
import {catchError, of, tap} from "rxjs";
import {error} from "@angular/compiler-cli/src/transformers/util";

@Component({
  selector: 'app-user.signup',
  templateUrl: './user.signup.component.html',
  styleUrl: './user.signup.component.css'
})
export class UserSignupComponent {
  // @ts-ignore
  _userData: UserDto;
  get userData(): UserDto {
    return this._userData;
  }

  set userData(value: UserDto) {
    this._userData = value;
  }
  constructor(private userService: UserService) { }

  ngOnInit() {
  }

  getUser(userId: number): void {
    this.userService.getUserById(userId)
      .subscribe(user => this._userData = user);
  }

  signUp(data: UserDto): void {
    this.userService.userSignUp(data)
      .pipe(
        tap(user => {
          // Handle successful creation
          console.log('User created:', user);
        }),
        catchError(error => {
          // Handle error
          console.error('Error creating user:', error);
          return of(null); // Return observable with null value to continue the stream
        })
      )
      .subscribe();
  }
}
