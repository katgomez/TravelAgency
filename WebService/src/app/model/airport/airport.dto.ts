import { CountryDto } from "../countries/CountryDto";

export class AirportDto {
  id?: string;
  name?: string;
  detailedName?: string;
  iataCode?: string;
  countryDto?: CountryDto;
  travelersScore?: number;


}
