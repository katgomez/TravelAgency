import { CountryDto } from "../countries/CountryDto";

export class AirportDto {
  id: string;
  name: string;
  detailedName: string;
  iataCode: string;
  countryDto: CountryDto;
  travelersScore: number;

  constructor(
    id: string,
    name: string,
    detailedName: string,
    iataCode: string,
    countryDto: CountryDto,
    travelersScore: number
  ) {
    this.id = id;
    this.name = name;
    this.detailedName = detailedName;
    this.iataCode = iataCode;
    this.countryDto = countryDto;
    this.travelersScore = travelersScore;
  }
}
