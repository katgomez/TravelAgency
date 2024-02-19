using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataServices.Migrations
{
    /// <inheritdoc />
    public partial class Flights_itinerary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FlighReservations_ReservationID",
                table: "FlighReservations");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "DestinationDate",
                table: "FlighReservations",
                newName: "ArrivalDate");

            migrationBuilder.RenameColumn(
                name: "DestinationAirport",
                table: "FlighReservations",
                newName: "Duration");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalAirport",
                table: "FlighReservations",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CodeOfItinerary",
                table: "FlighReservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "numberOfStops",
                table: "FlighReservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FlighReservations_ReservationID",
                table: "FlighReservations",
                column: "ReservationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FlighReservations_ReservationID",
                table: "FlighReservations");

            migrationBuilder.DropColumn(
                name: "ArrivalAirport",
                table: "FlighReservations");

            migrationBuilder.DropColumn(
                name: "CodeOfItinerary",
                table: "FlighReservations");

            migrationBuilder.DropColumn(
                name: "numberOfStops",
                table: "FlighReservations");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "FlighReservations",
                newName: "DestinationAirport");

            migrationBuilder.RenameColumn(
                name: "ArrivalDate",
                table: "FlighReservations",
                newName: "DestinationDate");

            migrationBuilder.CreateIndex(
                name: "IX_FlighReservations_ReservationID",
                table: "FlighReservations",
                column: "ReservationID",
                unique: true);
        }
    }
}
