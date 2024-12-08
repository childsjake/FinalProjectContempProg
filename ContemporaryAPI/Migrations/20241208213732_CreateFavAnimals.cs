using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContemporaryAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateFavAnimals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavAnimals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mammal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bird = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Reptile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amphibian = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fish = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavAnimals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "FavAnimals");
        }
    }
}
