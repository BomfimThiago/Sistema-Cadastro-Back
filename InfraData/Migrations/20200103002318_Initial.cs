using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfraData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                     .Annotation("Sqlite.Autoincrement", true),,
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                     .Annotation("Sqlite.Autoincrement", true),,
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Contact = table.Column<string>(maxLength: 30, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    ResignedDate = table.Column<DateTime>(nullable: true),
                    DepartmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
