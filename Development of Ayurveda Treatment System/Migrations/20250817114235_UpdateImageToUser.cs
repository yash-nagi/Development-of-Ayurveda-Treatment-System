using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentofAyurvedaTreatmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imagepath",
                table: "tbl_User",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "tbl_User",
                newName: "Imagepath");
        }
    }
}
