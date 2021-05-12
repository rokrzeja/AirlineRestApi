using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class addSteawrdAndLanguagesTableAndConstrains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                schema: "c",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    language = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.language_id);
                });

            migrationBuilder.CreateTable(
                name: "Steward",
                schema: "c",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    bonus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steward", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_Steward_Employee_employee_id",
                        column: x => x.employee_id,
                        principalSchema: "c",
                        principalTable: "Employee",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Steward_Language_Association",
                schema: "c",
                columns: table => new
                {
                    steward_language_association_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    language_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steward_Language_Association", x => x.steward_language_association_id);
                    table.ForeignKey(
                        name: "FK_Steward_Language_Association_Language_language_id",
                        column: x => x.language_id,
                        principalSchema: "c",
                        principalTable: "Language",
                        principalColumn: "language_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Steward_Language_Association_Steward_employee_id",
                        column: x => x.employee_id,
                        principalSchema: "c",
                        principalTable: "Steward",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Steward_Language_Association_employee_id",
                schema: "c",
                table: "Steward_Language_Association",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Steward_Language_Association_language_id",
                schema: "c",
                table: "Steward_Language_Association",
                column: "language_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Steward_Language_Association",
                schema: "c");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "c");

            migrationBuilder.DropTable(
                name: "Steward",
                schema: "c");
        }
    }
}
