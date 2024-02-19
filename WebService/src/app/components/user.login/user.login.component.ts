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
  constructor(private userService: UserService, private router: Router) {}

  ngOnInit() {
  }

  login(data: any) {
    this.userService.getUserByEmail(data.email)
      .pipe(
        tap(user => {
          this.userData = user;
          console.log('User found:', user);
          this.router.navigate(['/reservations'])
        }),
        catchError(error => {
          console.error('Error finding user:', error);
          return of(null); // Return observable with null value to continue the stream
        })
      )
      .subscribe();
  }
}
