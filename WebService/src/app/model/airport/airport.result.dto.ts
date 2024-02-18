import { AirportDto } from './airport.dto';

export class AirportResultDto {
  numberResults: number;
  airports: AirportDto[];

  constructor(numberResults: number, airports: AirportDto[]) {
    this.numberResults = numberResults;
    this.airports = airports;
  }
}
