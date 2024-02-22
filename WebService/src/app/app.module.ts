import {APP_INITIALIZER, NgModule} from '@angular/core';
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
import {ConfigService} from "./services/ConfigService";

export function initConfig(appConfig: ConfigService) {
  return () => appConfig.setConfig();
}
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
  providers: [{
                provide: APP_INITIALIZER,
                useFactory: initConfig,
                deps: [ConfigService], //We say to angular that this initializer depends of ConfigService
                //So config service will be available for the init config
                multi: true,
              },],
  bootstrap: [AppComponent]
})
export class AppModule { }
