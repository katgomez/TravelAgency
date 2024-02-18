import { FlightResultDto } from "./flight.result.dto";

export class FlightSearchResultDto {
  constructor(
    public numberResults: number,
    public flights: FlightResultDto[]
  ) {}
}
