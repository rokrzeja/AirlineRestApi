using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class AddedAirplaneTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "c");

            migrationBuilder.CreateTable(
                name: "Airplane",
                schema: "c",
                columns: table => new
                {
                    airplane_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    shortcut = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    economy_class_capacity = table.Column<int>(type: "int", nullable: false),
                    business_class_capacity = table.Column<int>(type: "int", nullable: false),
                    first_class_capacity = table.Column<int>(type: "int", nullable: false),
                    range = table.Column<int>(type: "int", nullable: false),
                    production_year = table.Column<int>(type: "int", nullable: false),
                    manufacturer = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    hours_flown = table.Column<double>(type: "float", nullable: false),
                    date_of_last_service = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplane", x => x.airplane_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airplane",
                schema: "c");
        }
    }
}
