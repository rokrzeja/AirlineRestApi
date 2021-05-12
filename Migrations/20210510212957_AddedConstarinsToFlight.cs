using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class AddedConstarinsToFlight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "airplaneId",
                schema: "c",
                table: "Flight",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "arrivalId",
                schema: "c",
                table: "Flight",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "departureId",
                schema: "c",
                table: "Flight",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Flight_airplaneId",
                schema: "c",
                table: "Flight",
                column: "airplaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_arrivalId",
                schema: "c",
                table: "Flight",
                column: "arrivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_departureId",
                schema: "c",
                table: "Flight",
                column: "departureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airplane_airplaneId",
                schema: "c",
                table: "Flight",
                column: "airplaneId",
                principalSchema: "c",
                principalTable: "Airplane",
                principalColumn: "airplane_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Arrival_arrivalId",
                schema: "c",
                table: "Flight",
                column: "arrivalId",
                principalSchema: "c",
                principalTable: "Arrival",
                principalColumn: "arrival_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Departure_departureId",
                schema: "c",
                table: "Flight",
                column: "departureId",
                principalSchema: "c",
                principalTable: "Departure",
                principalColumn: "arrival_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airplane_airplaneId",
                schema: "c",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Arrival_arrivalId",
                schema: "c",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Departure_departureId",
                schema: "c",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_airplaneId",
                schema: "c",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_arrivalId",
                schema: "c",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_departureId",
                schema: "c",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "airplaneId",
                schema: "c",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "arrivalId",
                schema: "c",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "departureId",
                schema: "c",
                table: "Flight");
        }
    }
}
