import { Component } from '@angular/core';
import {UserService} from "../../services/user.service";
import {catchError, of, tap} from "rxjs";
import {UserDto} from "../../model/user/user.dto";
import {Router} from "@angular/router";

@Component({
  selector: 'app-user.login',
  templateUrl: './user.login.component.html',
  styleUrl: './user.login.component.css'
})
export class UserLoginComponent {
  userData = {
    email: '',
    password: ''
  };
  message = '';
  constructor(private userService: UserService, private router: Router) {}

  ngOnInit() {
  }

  login(userData: any) {
    this.userService.checkOutCredentials(userData)
      .pipe(
        tap(valid => {
          if (valid) {
            this.router.navigate(['/reservations']);
          } else {
            this.message = 'Invalid email or password.';
          }
        }),
        catchError(error => {
          this.message = `User is not valid`;
          console.error('Error finding user:', error);
          return of(null); // Return observable with null value to continue the stream
        })
      )
      .subscribe();
  }
}
