using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookReserve.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    BookCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Book__3214EC07ADF6505E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Photo = table.Column<byte[]>(type: "image", nullable: true),
                    Reserves = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__3214EC07A9A2BAC8", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserve",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(name: "User_Id", type: "int", nullable: false),
                    Bookid = table.Column<int>(name: "Book_id", type: "int", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reserve__3214EC07BCE5A327", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserve_Book",
                        column: x => x.Bookid,
                        principalTable: "Book",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reserve_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_Book_id",
                table: "Reserve",
                column: "Book_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_User_Id",
                table: "Reserve",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserve");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
