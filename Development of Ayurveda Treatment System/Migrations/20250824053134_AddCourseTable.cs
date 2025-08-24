using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentofAyurvedaTreatmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Course",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CourseDuration = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CourseFeeStruc = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Benefits = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    InstituteName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    InstituteAddress = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    InstituteContactNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Course", x => x.CourseId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Course");
        }
    }
}
