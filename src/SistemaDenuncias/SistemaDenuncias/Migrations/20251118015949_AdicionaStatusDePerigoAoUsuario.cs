using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDenuncias.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaStatusDePerigoAoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmPerigo",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmPerigo",
                table: "Usuarios");
        }
    }
}
