using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EnerGov.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ManagerId = table.Column<int>(type: "integer", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_employee_employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "employee",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "employeerole",
                columns: table => new
                {
                    EmployeeRoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeerole", x => x.EmployeeRoleId);
                    table.ForeignKey(
                        name: "FK_employeerole_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "ManagerId" },
                values: new object[,]
                {
                    { 1, "Jefferey", "Wells", null },
                    { 2, "Vector", "Atkins", 1 },
                    { 3, "Kelli", "Hamilton", 1 }
                });

            migrationBuilder.InsertData(
                table: "employeerole",
                columns: new[] { "EmployeeRoleId", "EmployeeId", "Role", "RoleId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "ManagerId" },
                values: new object[,]
                {
                    { 4, "Adam", "Brown", 2 },
                    { 5, "Lois", "Martinez", 3 },
                    { 6, "Brian", "Cruz", 2 },
                    { 7, "Michael", "Lind", 3 },
                    { 8, "Kristen", "Floyd", 2 },
                    { 9, "Eric", "Bay", 3 },
                    { 10, "Brandon", "Young", 3 }
                });

            migrationBuilder.InsertData(
                table: "employeerole",
                columns: new[] { "EmployeeRoleId", "EmployeeId", "Role", "RoleId" },
                values: new object[,]
                {
                    { 2, 2, 1, 1 },
                    { 3, 3, 1, 1 },
                    { 4, 4, 3, 3 },
                    { 5, 4, 2, 2 },
                    { 6, 5, 2, 2 },
                    { 7, 6, 4, 4 },
                    { 8, 7, 5, 5 },
                    { 9, 8, 5, 5 },
                    { 10, 8, 6, 6 },
                    { 11, 9, 3, 3 },
                    { 12, 9, 6, 6 },
                    { 13, 10, 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_ManagerId",
                table: "employee",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_employeerole_EmployeeId",
                table: "employeerole",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeerole");

            migrationBuilder.DropTable(
                name: "employee");
        }
    }
}
