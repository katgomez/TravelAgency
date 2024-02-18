import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FlightsSerarchComponent } from './components/flights/flight.search.component';

const routes: Routes = [
  { path: '', component: FlightsSerarchComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 }
