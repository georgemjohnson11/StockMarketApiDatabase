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

            migrationBuilder.DropColumn(
                name: "Factor",
                table: "StockSplits");

            migrationBuilder.DropColumn(
                name: "Ask",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "AverageDailyVolume10Day",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "AverageDailyVolume3Month",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "Bid",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "BookValue",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "EarningsTimestamp",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "EarningsTimestampEnd",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "EarningsTimestampStart",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "FiftyDayAverage",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "FiftyDayAverageChange",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "FiftyDayAverageChangePercent",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "FiftyTwoWeekHigh",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "FiftyTwoWeekHighChange",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "FiftyTwoWeekHighChangePercent",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "FiftyTwoWeekLow",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "FiftyTwoWeekLowChange",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "FiftyTwoWeekLowChangePercent",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "RegularMarketChangePercent",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "RegularMarketDayHigh",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "RegularMarketDayLow",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "RegularMarketOpen",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "RegularMarketPreviousClose",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "RegularMarketPrice",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "RegularMarketVolume",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "TwoHundredDayAverage",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "TwoHundredDayAverageChange",
                table: "StockHistories");

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

            migrationBuilder.RenameColumn(
                name: "TwoHundredDayAverageChangePercent",
                table: "StockHistories",
                newName: "Dividend");

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

            migrationBuilder.AddColumn<decimal>(
                name: "LastSale",
                table: "StockTickers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StockTickers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "StockTickers",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AfterSplit",
                table: "StockSplits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BeforeSplit",
                table: "StockSplits",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.DropColumn(
                name: "AfterSplit",
                table: "StockSplits");

            migrationBuilder.DropColumn(
                name: "BeforeSplit",
                table: "StockSplits");

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

            migrationBuilder.RenameColumn(
                name: "Dividend",
                table: "StockHistories",
                newName: "TwoHundredDayAverageChangePercent");

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

            migrationBuilder.AddColumn<short>(
                name: "Factor",
                table: "StockSplits",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<decimal>(
                name: "Ask",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AverageDailyVolume10Day",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AverageDailyVolume3Month",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Bid",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BookValue",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "EarningsTimestamp",
                table: "StockHistories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EarningsTimestampEnd",
                table: "StockHistories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EarningsTimestampStart",
                table: "StockHistories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "FiftyDayAverage",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FiftyDayAverageChange",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FiftyDayAverageChangePercent",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FiftyTwoWeekHigh",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FiftyTwoWeekHighChange",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FiftyTwoWeekHighChangePercent",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FiftyTwoWeekLow",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FiftyTwoWeekLowChange",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FiftyTwoWeekLowChangePercent",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RegularMarketChangePercent",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RegularMarketDayHigh",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RegularMarketDayLow",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RegularMarketOpen",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RegularMarketPreviousClose",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RegularMarketPrice",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RegularMarketVolume",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TwoHundredDayAverage",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TwoHundredDayAverageChange",
                table: "StockHistories",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
