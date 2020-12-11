using Microsoft.EntityFrameworkCore.Migrations;

namespace AgriHub.Core.Migrations
{
    public partial class Added_Qty_On_Hand_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QtyOnHand",
                table: "Broilers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtyOnHand",
                table: "Broilers");
        }
    }
}
