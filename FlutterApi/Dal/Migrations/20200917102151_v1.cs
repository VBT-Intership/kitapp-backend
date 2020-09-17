using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    photoUrl = table.Column<string>(nullable: true),
                    TotalItem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    IDate = table.Column<DateTime>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Adress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    bookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(nullable: true),
                    Isbn = table.Column<string>(nullable: true),
                    IsFavorite = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    CategoryOfBook = table.Column<string>(nullable: true),
                    PublishedTime = table.Column<DateTime>(nullable: false),
                    EditionNumber = table.Column<int>(nullable: false),
                    PrintNumber = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    CoverType = table.Column<string>(nullable: true),
                    TypeofPaper = table.Column<string>(nullable: true),
                    WriterName = table.Column<string>(nullable: true),
                    BookStarCount = table.Column<double>(nullable: false),
                    categoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.bookId);
                    table.ForeignKey(
                        name: "FK_Books_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserFavoritesCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoritesCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavoritesCategories_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoritesCategories_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment = table.Column<string>(nullable: true),
                    PublisDate = table.Column<DateTime>(nullable: false),
                    IsFavorite = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UserStarCount = table.Column<double>(nullable: false),
                    bookId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "bookId");
                    table.ForeignKey(
                        name: "FK_Comments_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SellDetail",
                columns: table => new
                {
                    sellId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductPrice = table.Column<double>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    OfferPrice = table.Column<double>(nullable: false),
                    bookId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellDetail", x => x.sellId);
                    table.ForeignKey(
                        name: "FK_SellDetail_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellDetail_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StarCount = table.Column<int>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    bookId = table.Column<int>(nullable: false),
                    UserStarsId = table.Column<int>(nullable: true),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stars_Stars_UserStarsId",
                        column: x => x.UserStarsId,
                        principalTable: "Stars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stars_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "bookId");
                    table.ForeignKey(
                        name: "FK_Stars_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    CategoriesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferDetail",
                columns: table => new
                {
                    OfferDetalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferDate = table.Column<DateTime>(nullable: false),
                    OfferStatus = table.Column<int>(nullable: false),
                    OfferUserId = table.Column<int>(nullable: false),
                    OfferPrice = table.Column<double>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    SellDetalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferDetail", x => x.OfferDetalId);
                    table.ForeignKey(
                        name: "FK_OfferDetail_SellDetail_SellDetalId",
                        column: x => x.SellDetalId,
                        principalTable: "SellDetail",
                        principalColumn: "sellId");
                    table.ForeignKey(
                        name: "FK_OfferDetail_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_categoryId",
                table: "Books",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_bookId",
                table: "Comments",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userId",
                table: "Comments",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferDetail_SellDetalId",
                table: "OfferDetail",
                column: "SellDetalId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferDetail_userId",
                table: "OfferDetail",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_SellDetail_bookId",
                table: "SellDetail",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_SellDetail_userId",
                table: "SellDetail",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Stars_UserStarsId",
                table: "Stars",
                column: "UserStarsId");

            migrationBuilder.CreateIndex(
                name: "IX_Stars_bookId",
                table: "Stars",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_Stars_userId",
                table: "Stars",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_CategoriesId",
                table: "UserFavorites",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_bookId",
                table: "UserFavorites",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_userId",
                table: "UserFavorites",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoritesCategories_categoryId",
                table: "UserFavoritesCategories",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoritesCategories_userId",
                table: "UserFavoritesCategories",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "OfferDetail");

            migrationBuilder.DropTable(
                name: "Stars");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "UserFavoritesCategories");

            migrationBuilder.DropTable(
                name: "SellDetail");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
