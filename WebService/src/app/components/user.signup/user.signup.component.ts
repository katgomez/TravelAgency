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

  getUser(userId: number): void {
    this.userService.getUserById(userId)
      .subscribe(user => this.userData = user);
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
      return; // Don't proceed with sign-up if there are validation errors
    }
    this.userService.userSignUp(data)
      .pipe(
        tap(user => {
          // Handle successful creation
          console.log('User created:', user);
        }),
        catchError(error => {
          // Handle error
          console.error('Error creating user:', error);
          this.errors = "This email already exits";
          return of(null); // Return observable with null value to continue the stream
        })
      )
      .subscribe();
    this.router.navigate(['/login']);
  }

  isValidEmail(email: string): boolean {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
  }

  isValidPassword(password: string): boolean {
    return password.length >= 6;
  }
}
