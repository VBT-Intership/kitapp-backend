using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Books_bookId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Stars_Stars_UserStarsId",
                table: "Stars");

            migrationBuilder.DropIndex(
                name: "IX_Stars_UserStarsId",
                table: "Stars");

            migrationBuilder.DropIndex(
                name: "IX_Comments_bookId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserStarsId",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "bookId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "booksId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_booksId",
                table: "Comments",
                column: "booksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Books_booksId",
                table: "Comments",
                column: "booksId",
                principalTable: "Books",
                principalColumn: "bookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Books_booksId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_booksId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "booksId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "UserStarsId",
                table: "Stars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "bookId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stars_UserStarsId",
                table: "Stars",
                column: "UserStarsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_bookId",
                table: "Comments",
                column: "bookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Books_bookId",
                table: "Comments",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "bookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stars_Stars_UserStarsId",
                table: "Stars",
                column: "UserStarsId",
                principalTable: "Stars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
