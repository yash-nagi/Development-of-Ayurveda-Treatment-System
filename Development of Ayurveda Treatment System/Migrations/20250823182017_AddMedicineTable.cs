using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentofAyurvedaTreatmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicineTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "tbl_Medicine",
            columns: table => new
            {
                ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                MedicineNo = table.Column<int>(type: "int", nullable: false),
                MedicineName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                MedicineBatchNo = table.Column<int>(type: "int", nullable: false),
                ManufacturerName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                ManufacturerAddress = table.Column<string>(type: "nvarchar(50)", nullable: false),
                VendorID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                DateOfManufactured = table.Column<DateTime>(type: "DATETIME", nullable: false),
                DateOfExpire = table.Column<DateTime>(type: "DATETIME", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_tbl_Medicine", x => x.ID);
                // Add foreign keys later if you have Vendor/User tables
                // table.ForeignKey("FK_tbl_Medicine_Users", x => x.UserID, "tbl_User", "UserId", onDelete: ReferentialAction.Restrict);
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "tbl_Medicine");
        }
    }
}
