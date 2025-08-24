using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentofAyurvedaTreatmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddDebitCardTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_DebitCard",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DebitCardID = table.Column<long>(type: "bigint", nullable: false),
                    PaymentAmount = table.Column<long>(type: "bigint", nullable: false),
                    DateOfPayment = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CardHolderName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CardExpDate = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DebitCard", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_DebitCard");
        }
    }
}
