using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentofAyurvedaTreatmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Employes",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Emp_First_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Emp_Middle_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Emp_Last_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ContactNo = table.Column<long>(type: "bigint", nullable: false),
                    Emp_DOB = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Salary = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Employes", x => x.EmployeeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Employes");
        }
    }
}
