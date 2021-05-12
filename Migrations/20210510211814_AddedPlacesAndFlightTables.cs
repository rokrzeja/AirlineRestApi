using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class AddedPlacesAndFlightTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arrival",
                schema: "c",
                columns: table => new
                {
                    arrival_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    airport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    airport_shortcut = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    city = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    country = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrival", x => x.arrival_id);
                });

            migrationBuilder.CreateTable(
                name: "Departure",
                schema: "c",
                columns: table => new
                {
                    arrival_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    airport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    airport_shortcut = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    city = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    country = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departure", x => x.arrival_id);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                schema: "c",
                columns: table => new
                {
                    flight_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flight_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fixed_cost = table.Column<double>(type: "float", nullable: false),
                    airport_tax = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.flight_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arrival",
                schema: "c");

            migrationBuilder.DropTable(
                name: "Departure",
                schema: "c");

            migrationBuilder.DropTable(
                name: "Flight",
                schema: "c");
        }
    }
}
