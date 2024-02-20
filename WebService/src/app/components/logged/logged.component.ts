import { Component, OnInit } from '@angular/core';
import {UserService} from "../../services/user.service";
import {UserDto} from "../../model/user/user.dto";

@Component({
  selector: 'app-logged',
  templateUrl: './logged.component.html',
  styleUrls: ['./logged.component.css']
})
export class LoggedComponent implements OnInit {
  loggedInUser: any;
  userData: UserDto | undefined;
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loggedInUser = this.userService.getUserId();
    if (this.loggedInUser) this.getUser(this.loggedInUser);
  }

  getUser(userId: number): void {
    this.userService.getUserById(userId)
        .subscribe(user => this.userData = user);
  }

}
