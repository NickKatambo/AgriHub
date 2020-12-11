using Microsoft.EntityFrameworkCore.Migrations;

namespace AgriHub.Core.Migrations
{
    public partial class sp_addbroiler_transaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //stored procedure section
            string sp_AddBroilerTransaction = @"
            USE [AgriHub]
            GO
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            -- =============================================
            -- Author:		Nick Katambo
            -- Create date: 11 August 2020 7:18pm
            -- Description:	Insert Broiler Transaction log data. Current week is auto calculated based the 'receipt date'.
            -- =============================================
            CREATE PROCEDURE [dbo].[sp_AddBroilerTransaction] 
	            @BroilerId	int,
	            @BatchNo	nvarchar(MAX),
	            @TransactionDate	datetimeoffset(7),
	            @OpeningStock	int,
	            @Mortality	int,
	            @ClosingStock	int,
	            @AvgWeight	decimal(18, 2),
	            @StdWeight	decimal(18, 2),
	            @FeedCons	decimal(18, 2),
	            @Comment	nvarchar(MAX),
	            @LoggedBy	nvarchar(MAX)

            AS
            BEGIN
	            -- Get required parameters
	            DECLARE @DateReceipt date = (SELECT [DateReceipt] FROM [AgriHub].[dbo].[Broilers] WHERE Id = @BroilerId)
	            DECLARE	@CurrentWeek int = (SELECT DATEDIFF ( wk ,@DateReceipt , GETDATE() ))
                DECLARE @CurrentDay int = (SELECT DATEDIFF (D ,@DateReceipt, GETDATE() ))

	            SET NOCOUNT ON;

	            -- Update Header current week
	            UPDATE Broilers SET CurrentWeek = @CurrentWeek WHERE Id = @BroilerId

                -- Insert statements for procedure here
	            INSERT INTO BroilerTrans(
	               [BroilerId]
	              ,[BatchNo]
                  ,[TransactionDate]
                  ,[TransactionWeek]
                  ,TransactionDay
                  ,[OpeningStock]
                  ,[Mortality]
                  ,[ClosingStock]
                  ,[AvgWeight]
                  ,[StdWeight]
                  ,[FeedCons]
                  ,[Comment]
                  ,[LoggedBy])

	            VALUES(
		            @BroilerId,
		            @BatchNo,
		            @TransactionDate,
		            @CurrentWeek,
                    @CurrentDay,
		            @OpeningStock,
		            @Mortality,
		            @ClosingStock,
		            @AvgWeight,
		            @StdWeight,
		            @FeedCons,
		            @Comment,
		            @LoggedBy)

            END";

            migrationBuilder.Sql(sp_AddBroilerTransaction);

            migrationBuilder.AlterColumn<string>(
                name: "LoggedBy",
                table: "BroilerTrans",
                type: "VARCHAR(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "BroilerTrans",
                type: "VARCHAR(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BatchNo",
                table: "BroilerTrans",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionDay",
                table: "BroilerTrans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LoggedBy",
                table: "Broilers",
                type: "VARCHAR(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BatchNo",
                table: "Broilers",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BatchCompletedBy",
                table: "Broilers",
                type: "VARCHAR(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //stored procedure section
            string sp_AddBroilerTransaction = @"DROP PROCEDURE [dbo].[sp_AddBroilerTransaction]";
            migrationBuilder.Sql(sp_AddBroilerTransaction);

            migrationBuilder.DropColumn(
                name: "TransactionDay",
                table: "BroilerTrans");

            migrationBuilder.AlterColumn<string>(
                name: "LoggedBy",
                table: "BroilerTrans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "BroilerTrans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BatchNo",
                table: "BroilerTrans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoggedBy",
                table: "Broilers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BatchNo",
                table: "Broilers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "BatchCompletedBy",
                table: "Broilers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(30)",
                oldNullable: true);
        }
    }
}
