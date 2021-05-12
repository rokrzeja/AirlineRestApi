using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class addedPilot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pilot",
                schema: "c",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    rank = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilot", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_Pilot_Employee_employee_id",
                        column: x => x.employee_id,
                        principalSchema: "c",
                        principalTable: "Employee",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pilot",
                schema: "c");
        }
    }
}
