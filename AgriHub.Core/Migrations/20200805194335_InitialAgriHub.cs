using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgriHub.Core.Migrations
{
    public partial class InitialAgriHub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brooders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brooders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PenHouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenHouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Broilers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchNo = table.Column<string>(nullable: true),
                    ChicksDaysOld = table.Column<int>(nullable: false),
                    DateReceipt = table.Column<DateTime>(nullable: false),
                    QtyReceipt = table.Column<int>(nullable: false),
                    BrooderId = table.Column<string>(nullable: true),
                    PinHouseId = table.Column<int>(nullable: false),
                    PinCapacity = table.Column<int>(nullable: false),
                    AvgWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransactionDate = table.Column<DateTimeOffset>(nullable: false),
                    CurrentWeek = table.Column<int>(nullable: false),
                    LoggedBy = table.Column<string>(nullable: true),
                    BatchCompleted = table.Column<bool>(nullable: true),
                    BatchCompletedOn = table.Column<DateTime>(nullable: true),
                    BatchCompletedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broilers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Broilers_Brooders_BrooderId",
                        column: x => x.BrooderId,
                        principalTable: "Brooders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Broilers_PenHouses_PinHouseId",
                        column: x => x.PinHouseId,
                        principalTable: "PenHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BroilerTrans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BroilerId = table.Column<int>(nullable: false),
                    BatchNo = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTimeOffset>(nullable: false),
                    TransactionWeek = table.Column<int>(nullable: false),
                    OpeningStock = table.Column<int>(nullable: false),
                    Mortality = table.Column<int>(nullable: true),
                    ClosingStock = table.Column<int>(nullable: true),
                    AvgWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StdWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FeedCons = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    LoggedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BroilerTrans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BroilerTrans_Broilers_BroilerId",
                        column: x => x.BroilerId,
                        principalTable: "Broilers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Broilers_BrooderId",
                table: "Broilers",
                column: "BrooderId");

            migrationBuilder.CreateIndex(
                name: "IX_Broilers_PinHouseId",
                table: "Broilers",
                column: "PinHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_BroilerTrans_BroilerId",
                table: "BroilerTrans",
                column: "BroilerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BroilerTrans");

            migrationBuilder.DropTable(
                name: "Broilers");

            migrationBuilder.DropTable(
                name: "Brooders");

            migrationBuilder.DropTable(
                name: "PenHouses");
        }
    }
}
