export class TravelDto {
    constructor(
      public iataCode: string,
      public terminal: string,
      public at: Date
    ) {}
  }
  