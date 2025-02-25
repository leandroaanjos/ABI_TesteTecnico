using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProductPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Change column to Null before drop it, this is necessary to avoid DropTable
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                defaultValue: 0m);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
