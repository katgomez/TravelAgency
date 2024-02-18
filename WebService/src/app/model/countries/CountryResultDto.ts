import { CountryDto } from './CountryDto';

export class CountryResultDto {
  numberResults: number;
  countries: CountryDto[];

  constructor(numberResults: number, countries: CountryDto[]) {
    this.numberResults = numberResults;
    this.countries = countries;
  }
}