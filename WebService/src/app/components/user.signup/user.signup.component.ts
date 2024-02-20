import { Component } from '@angular/core';
import { UserDto} from "../../model/user/user.dto";
import {UserService} from "../../services/user.service";
import {catchError, of, tap} from "rxjs";
import {error} from "@angular/compiler-cli/src/transformers/util";
import {Router} from "@angular/router";

@Component({
  selector: 'app-user.signup',
  templateUrl: './user.signup.component.html',
  styleUrl: './user.signup.component.css'
})
export class UserSignupComponent {
  userData: UserDto = {
    id: 0,
    lastName: '',
    firstName: '',
    email: '',
    password: ''
  };
  emailError = '';
  passwordError = '';
  errors= '';
  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
  }
  signUp(data: UserDto): void {
    this.emailError = '';
    this.passwordError = '';

    if (!this.isValidEmail(data.email)) {
      this.emailError = 'Invalid email format';
    }

    if (!this.isValidPassword(data.password)) {
      this.passwordError = 'Password must be at least 6 characters long';
    }

    if (this.emailError || this.passwordError) {
      return;
    }
    this.userService.userSignUp(data)
      .pipe(
        tap(user => {
          console.log('User created:', user);
          this.router.navigate(['/login']);
        }),
        catchError(error => {
          console.error('Error creating user:', error);
          this.errors = "This email already exits";
          return of(null);
        })
      )
      .subscribe();
  }

  isValidEmail(email: string): boolean {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
  }

  isValidPassword(password: string): boolean {
    return password.length >= 6;
  }
}
