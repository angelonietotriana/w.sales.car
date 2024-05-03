using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace w.sale.car.db.Migrations
{
    /// <inheritdoc />
    public partial class ModifySale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDeliveryLocation",
                table: "sale",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdDeliveryLocation",
                table: "sale");
        }
    }
}
