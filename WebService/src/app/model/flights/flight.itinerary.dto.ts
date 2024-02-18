import { SegmentDto } from "./segment.dto";

export class FlightItineraryDto {
  constructor(
    public itinerary: SegmentDto[]
  ) {}
}