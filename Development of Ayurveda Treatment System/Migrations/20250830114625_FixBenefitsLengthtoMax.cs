using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentofAyurvedaTreatmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixBenefitsLengthtoMax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Benefits",
                table: "tbl_Course",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Benefits",
                table: "tbl_Course",
                type: "nvarchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
