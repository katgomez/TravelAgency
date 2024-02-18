import { FareDto } from "./fare.dto";

export class FareResultDto {
  numberResults: number;
  fares: FareDto[];

  constructor() {
    this.numberResults = 0;
    this.fares = [];
  }
}
