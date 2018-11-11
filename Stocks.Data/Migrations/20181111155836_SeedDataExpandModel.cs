using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Stocks.Data.Migrations
{
    public partial class SeedDataExpandModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdjustedClose",
                table: "StockTickers");

            migrationBuilder.DropColumn(
                name: "Close",
                table: "StockTickers");

            migrationBuilder.DropColumn(
                name: "High",
                table: "StockTickers");

            migrationBuilder.DropColumn(
                name: "Low",
                table: "StockTickers");

            migrationBuilder.RenameColumn(
                name: "Volume",
                table: "StockTickers",
                newName: "MarketCap");

            migrationBuilder.RenameColumn(
                name: "Open",
                table: "StockTickers",
                newName: "ADR_TSO");

            migrationBuilder.RenameColumn(
                name: "History",
                table: "StockTickers",
                newName: "UpdatedTime");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "StockTickers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExchangeMarket",
                table: "StockTickers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IPOYear",
                table: "StockTickers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "StockTickers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSale",
                table: "StockTickers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StockTickers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "StockTickers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pipes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Key = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    LocalizationCulture = table.Column<string>(nullable: true),
                    ResourceKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pipes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pipes");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "StockTickers");

            migrationBuilder.DropColumn(
                name: "ExchangeMarket",
                table: "StockTickers");

            migrationBuilder.DropColumn(
                name: "IPOYear",
                table: "StockTickers");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "StockTickers");

            migrationBuilder.DropColumn(
                name: "LastSale",
                table: "StockTickers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "StockTickers");

            migrationBuilder.DropColumn(
                name: "Sector",
                table: "StockTickers");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "StockTickers",
                newName: "History");

            migrationBuilder.RenameColumn(
                name: "MarketCap",
                table: "StockTickers",
                newName: "Volume");

            migrationBuilder.RenameColumn(
                name: "ADR_TSO",
                table: "StockTickers",
                newName: "Open");

            migrationBuilder.AddColumn<decimal>(
                name: "AdjustedClose",
                table: "StockTickers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Close",
                table: "StockTickers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "High",
                table: "StockTickers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Low",
                table: "StockTickers",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
