using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryDetail",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookDetail",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryDetail",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BookDetail",
                table: "Books");
        }
    }
}
