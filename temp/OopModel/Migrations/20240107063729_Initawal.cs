using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OopModel.Migrations
{
    /// <inheritdoc />
    public partial class Initawal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kakiempats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KembangBiak = table.Column<byte>(type: "tinyint", nullable: false),
                    Habitat = table.Column<byte>(type: "tinyint", nullable: false),
                    Nafas = table.Column<byte>(type: "tinyint", nullable: false),
                    Kategori = table.Column<int>(type: "int", nullable: false),
                    IsBuas = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kakiempats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "unggass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsTerbang = table.Column<bool>(type: "bit", nullable: false),
                    IsKicau = table.Column<bool>(type: "bit", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KembangBiak = table.Column<byte>(type: "tinyint", nullable: false),
                    Habitat = table.Column<byte>(type: "tinyint", nullable: false),
                    Nafas = table.Column<byte>(type: "tinyint", nullable: false),
                    Kategori = table.Column<int>(type: "int", nullable: false),
                    IsBuas = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unggass", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kakiempats");

            migrationBuilder.DropTable(
                name: "unggass");
        }
    }
}
