using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDenuncias.Migrations
{
    /// <inheritdoc />
    public partial class attUsuarioTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Usuarios",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Usuarios",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Usuarios");
        }
    }
}
