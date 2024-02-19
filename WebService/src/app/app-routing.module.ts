import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FlightsSerarchComponent } from './components/flights/flight.search.component';
import {UserSignupComponent} from "./components/user.signup/user.signup.component";
import {UserLoginComponent} from "./components/user.login/user.login.component";

const routes: Routes = [
  { path: '', component: FlightsSerarchComponent },
  { path: '/sign-up', component: UserSignupComponent },
  { path: '/log-in', component: UserLoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 }
