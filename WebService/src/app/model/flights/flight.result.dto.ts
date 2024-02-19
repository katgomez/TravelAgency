import { FlightItineraryDto } from "./flight.itinerary.dto";

export class FlightResultDto {
  constructor(
    public id: string,
    public flightCode: string,
    public departureDayItineraries: FlightItineraryDto[],
    public returnDayItineraries: FlightItineraryDto[],
    public price: number,
    public currency: string,
    public priceWithFare: number
  ) {}
}
