using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class AddedClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clientId",
                schema: "c",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "c",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document_number = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    personal_id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    birth_place = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    place_of_residance = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    telephone_number = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.person_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_clientId",
                schema: "c",
                table: "Reservation",
                column: "clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Client_clientId",
                schema: "c",
                table: "Reservation",
                column: "clientId",
                principalSchema: "c",
                principalTable: "Client",
                principalColumn: "person_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Client_clientId",
                schema: "c",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "c");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_clientId",
                schema: "c",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "clientId",
                schema: "c",
                table: "Reservation");
        }
    }
}
