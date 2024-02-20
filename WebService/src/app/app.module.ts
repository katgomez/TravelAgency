import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgSelectModule } from '@ng-select/ng-select';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule,ReactiveFormsModule  } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FlightsSerarchComponent } from './components/flights/flight.search.component';
import { UserSignupComponent } from './components/user.signup/user.signup.component';
import { UserLoginComponent } from './components/user.login/user.login.component';
import { ReservationsComponent } from './components/reservations/reservations.component';
import { LoggedComponent } from './components/logged/logged.component';

@NgModule({
  declarations: [
    AppComponent,
    FlightsSerarchComponent,
    UserSignupComponent,
    UserLoginComponent,
    ReservationsComponent,
    LoggedComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgSelectModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
