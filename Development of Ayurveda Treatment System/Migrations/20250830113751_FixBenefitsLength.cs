using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentofAyurvedaTreatmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixBenefitsLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Benefits",
                table: "tbl_Course",
                type: "nvarchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Benefits",
                table: "tbl_Course",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");
        }
    }
}
