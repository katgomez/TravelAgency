import { Component } from '@angular/core';
import { UserService } from "../../services/user.service";
import { catchError, tap } from "rxjs/operators";
import { of } from "rxjs";
import { Router } from "@angular/router";

@Component({
  selector: 'app-user-login', // Corrected selector
  templateUrl: './user.login.component.html',
  styleUrls: ['./user.login.component.css'] // Corrected styleUrls
})
export class UserLoginComponent {
  userData = {
    email: '',
    password: ''
  };
  message = '';

  constructor(private userService: UserService, private router: Router) {}

  login(userData: any) {
    this.userService.checkOutCredentials(userData)
      .pipe(
        tap(valid => {
          if (valid) {
            sessionStorage.setItem("userId", valid.userId);
            sessionStorage.setItem("token", valid.token.token);
            this.router.navigate(['/reservations']);
          } else {
            this.message = 'Invalid email or password.'; // Handle invalid credentials
          }
        }),
        catchError(error => {
          switch (error.status) {
            case 400:
              this.message = 'Invalid email or password.';
              break;
            case 500:
              this.message = 'User is not valid.';
              break;
          }
          console.error('Error finding user:', error);
          return of(null);
        })
      )
      .subscribe();
  }
}
