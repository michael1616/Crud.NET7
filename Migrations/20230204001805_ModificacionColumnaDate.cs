using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.NET7.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionColumnaDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Contacts",
                newName: "CreateDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Contacts",
                newName: "FechaCreacion");
        }
    }
}
