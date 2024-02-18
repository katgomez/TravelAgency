import { TravelDto } from './travel.dto';

export class SegmentDto {
  constructor(
    public departure: TravelDto,
    public arrival: TravelDto,
    public carrierCode: string,
    public number: string,
    public duration: string,
    public id: string,
    public numberOfStops: number,
    public blacklistedInEU: boolean
  ) {}
}
