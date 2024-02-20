export class ReservationDto {
  constructor(
    public id: number,
    public numberOfClients: number,
    public price: number,
    public reservationDate: string,
    public reservationStatus: string,
    public userId: number
  ) {}
}
