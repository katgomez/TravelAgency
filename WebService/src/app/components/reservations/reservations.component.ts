import { Component } from '@angular/core';
import {UserService} from "../../services/user.service";
import {FlightsService} from "../../services/flights.service";
import {ReservationDto} from "../../model/reservation/reservation.dto";
import {catchError, of, tap} from "rxjs";

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrl: './reservations.component.css'
})
export class ReservationsComponent {
  userId: any;
  flightReservations: ReservationDto[] | undefined;
  constructor(private userService: UserService, private flightsService: FlightsService) {}

  ngOnInit() {
    this.getReservations();
  }
  getReservations(){
    this.userId = this.userService.getUserId();
    this.flightsService.getReservationData(this.userId).pipe(
      tap(reservations => {
        this.flightReservations = reservations;
      }),
      catchError(error => {
        console.error('Error creating user:', error);
        return of(null);
      })
    )
      .subscribe();
  }


}
