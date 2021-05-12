using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class UpdateFlightInstanceEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Instance_Employee_Association_Employee_employeeId",
                schema: "c",
                table: "Flight_Instance_Employee_Association");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Instance_Employee_Association_Flight_Instance_flightInstanceId",
                schema: "c",
                table: "Flight_Instance_Employee_Association");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight_Instance_Employee_Association",
                schema: "c",
                table: "Flight_Instance_Employee_Association");

            migrationBuilder.RenameColumn(
                name: "employeeId",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                newName: "employee_Id");

            migrationBuilder.RenameColumn(
                name: "flightInstanceId",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                newName: "flight_instance_id");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_Instance_Employee_Association_employeeId",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                newName: "IX_Flight_Instance_Employee_Association_employee_Id");

            migrationBuilder.AddColumn<int>(
                name: "flight_instance_employee_association_id",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight_Instance_Employee_Association",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                column: "flight_instance_employee_association_id");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_Instance_Employee_Association_flight_instance_id",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                column: "flight_instance_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Instance_Employee_Association_Employee_employee_Id",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                column: "employee_Id",
                principalSchema: "c",
                principalTable: "Employee",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Instance_Employee_Association_Flight_Instance_flight_instance_id",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                column: "flight_instance_id",
                principalSchema: "c",
                principalTable: "Flight_Instance",
                principalColumn: "flight_instance_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Instance_Employee_Association_Employee_employee_Id",
                schema: "c",
                table: "Flight_Instance_Employee_Association");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Instance_Employee_Association_Flight_Instance_flight_instance_id",
                schema: "c",
                table: "Flight_Instance_Employee_Association");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight_Instance_Employee_Association",
                schema: "c",
                table: "Flight_Instance_Employee_Association");

            migrationBuilder.DropIndex(
                name: "IX_Flight_Instance_Employee_Association_flight_instance_id",
                schema: "c",
                table: "Flight_Instance_Employee_Association");

            migrationBuilder.DropColumn(
                name: "flight_instance_employee_association_id",
                schema: "c",
                table: "Flight_Instance_Employee_Association");

            migrationBuilder.RenameColumn(
                name: "flight_instance_id",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                newName: "flightInstanceId");

            migrationBuilder.RenameColumn(
                name: "employee_Id",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                newName: "employeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_Instance_Employee_Association_employee_Id",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                newName: "IX_Flight_Instance_Employee_Association_employeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight_Instance_Employee_Association",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                column: "flightInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Instance_Employee_Association_Employee_employeeId",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                column: "employeeId",
                principalSchema: "c",
                principalTable: "Employee",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Instance_Employee_Association_Flight_Instance_flightInstanceId",
                schema: "c",
                table: "Flight_Instance_Employee_Association",
                column: "flightInstanceId",
                principalSchema: "c",
                principalTable: "Flight_Instance",
                principalColumn: "flight_instance_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
