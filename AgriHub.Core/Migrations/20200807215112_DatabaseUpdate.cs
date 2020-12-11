using Microsoft.EntityFrameworkCore.Migrations;

namespace AgriHub.Core.Migrations
{
    public partial class DatabaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "PenHouses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "BatchNo",
                table: "Broilers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PenHouses");

            migrationBuilder.AlterColumn<string>(
                name: "BatchNo",
                table: "Broilers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
