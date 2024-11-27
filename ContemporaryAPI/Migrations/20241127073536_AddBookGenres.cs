using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContemporaryAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddBookGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fantasy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Scifi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Romance = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Historical = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenres", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenres");
        }
    }
}
