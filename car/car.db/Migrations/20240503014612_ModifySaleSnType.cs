using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace w.sale.car.db.Migrations
{
    /// <inheritdoc />
    public partial class ModifySaleSnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SnReserve",
                table: "reserve",
                newName: "IdReserve");

            migrationBuilder.AlterColumn<string>(
                name: "SnReserve",
                table: "sale",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdReserve",
                table: "reserve",
                newName: "SnReserve");

            migrationBuilder.AlterColumn<int>(
                name: "SnReserve",
                table: "sale",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
