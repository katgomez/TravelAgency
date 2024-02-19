import { TravelDto } from './travel.dto';

export class SegmentDto {
  constructor(
    public departure: TravelDto,
    public arrival: TravelDto,
    public carrierCode: string,
    public number: string,
    public duration: number,
    public durationMinutes: number,
    public id: string,
    public numberOfStops: number,
    public blacklistedInEU: boolean
  ) {}
}
