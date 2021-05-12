using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class AddedInstanceFlightAndReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight_Instance",
                schema: "c",
                columns: table => new
                {
                    flight_instance_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flightNumber = table.Column<int>(type: "int", nullable: false),
                    departure_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    arrival_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ticket_price = table.Column<int>(type: "int", nullable: false),
                    flightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight_Instance", x => x.flight_instance_id);
                    table.ForeignKey(
                        name: "FK_Flight_Instance_Flight_flightId",
                        column: x => x.flightId,
                        principalSchema: "c",
                        principalTable: "Flight",
                        principalColumn: "flight_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                schema: "c",
                columns: table => new
                {
                    reservation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flight_class = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    extra_luggage = table.Column<bool>(type: "bit", nullable: false),
                    date_of_purchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    flightInstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.reservation_id);
                    table.ForeignKey(
                        name: "FK_Reservation_Flight_Instance_flightInstanceId",
                        column: x => x.flightInstanceId,
                        principalSchema: "c",
                        principalTable: "Flight_Instance",
                        principalColumn: "flight_instance_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_Instance_flightId",
                schema: "c",
                table: "Flight_Instance",
                column: "flightId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_flightInstanceId",
                schema: "c",
                table: "Reservation",
                column: "flightInstanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation",
                schema: "c");

            migrationBuilder.DropTable(
                name: "Flight_Instance",
                schema: "c");
        }
    }
}
