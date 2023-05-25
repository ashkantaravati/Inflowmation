using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inflowmation.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentAndEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Request",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IssuedForId",
                table: "Request",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IssuedFromId",
                table: "Request",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Request_CreatedById",
                table: "Request",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Request_IssuedForId",
                table: "Request",
                column: "IssuedForId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_IssuedFromId",
                table: "Request",
                column: "IssuedFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Department_IssuedForId",
                table: "Request",
                column: "IssuedForId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Department_IssuedFromId",
                table: "Request",
                column: "IssuedFromId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Employee_CreatedById",
                table: "Request",
                column: "CreatedById",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Department_IssuedForId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Department_IssuedFromId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Employee_CreatedById",
                table: "Request");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Request_CreatedById",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_IssuedForId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_IssuedFromId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "IssuedForId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "IssuedFromId",
                table: "Request");
        }
    }
}
