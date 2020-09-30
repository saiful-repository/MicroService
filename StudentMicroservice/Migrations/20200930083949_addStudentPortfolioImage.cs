using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentMicroservice.Migrations
{
    public partial class addStudentPortfolioImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentPortfolioImages",
                columns: table => new
                {
                    PhotoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPortfolioImages", x => x.PhotoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentPortfolioImages");
        }
    }
}
