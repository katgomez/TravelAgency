import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FlightsSerarchComponent } from './components/flights/flight.search.component';
import {UserSignupComponent} from "./components/user.signup/user.signup.component";
import {UserLoginComponent} from "./components/user.login/user.login.component";
import {ReservationsComponent} from "./components/reservations/reservations.component";

const routes: Routes = [
  { path: '', component: FlightsSerarchComponent },
  { path: 'sign-up', component: UserSignupComponent },
  { path: 'login', component: UserLoginComponent },
  { path: 'reservations', component: ReservationsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 }
