using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class AddedEmployeeAndAssociationToFIAndConstrains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "person_id",
                schema: "c",
                table: "Client",
                newName: "client_id");

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "c",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hours_flown = table.Column<double>(type: "float", nullable: false),
                    hire_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    former_employer = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    basic_salary = table.Column<double>(type: "float", nullable: false),
                    hourly_rate = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_Employee", x => x.employee_id);
                });

            migrationBuilder.CreateTable(
                name: "Flight_Instance_Employee_Association",
                schema: "c",
                columns: table => new
                {
                    flightInstanceId = table.Column<int>(type: "int", nullable: false),
                    employeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight_Instance_Employee_Association", x => x.flightInstanceId);
                    table.ForeignKey(
                        name: "FK_Flight_Instance_Employee_Association_Employee_employeeId",
                        column: x => x.employeeId,
                        principalSchema: "c",
                        principalTable: "Employee",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_Instance_Employee_Association_Flight_Instance_flightInstanceId",
                        column: x => x.flightInstanceId,
                        principalSchema: "c",
                        principalTable: "Flight_Instance",
                        principalColumn: "flight_instance_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_Instance_Employee_Association_employeeId",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                column: "employeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight_Instance_Employee_Association",
                schema: "c");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "c");

            migrationBuilder.RenameColumn(
                name: "client_id",
                schema: "c",
                table: "Client",
                newName: "person_id");
        }
    }
}
