using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Stocks.Data.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockTickers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    History = table.Column<DateTime>(nullable: false),
                    Open = table.Column<decimal>(nullable: false),
                    Close = table.Column<decimal>(nullable: false),
                    AdjustedClose = table.Column<decimal>(nullable: false),
                    High = table.Column<decimal>(nullable: false),
                    Low = table.Column<decimal>(nullable: false),
                    Volume = table.Column<decimal>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IsCurrency = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTickers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AccountId = table.Column<int>(nullable: false),
                    Type = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TickerFrom = table.Column<string>(nullable: true),
                    TickerTo = table.Column<string>(nullable: true),
                    Ratio = table.Column<short>(nullable: false),
                    RateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_StockTickers_TickerFrom",
                        column: x => x.TickerFrom,
                        principalTable: "StockTickers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_StockTickers_TickerTo",
                        column: x => x.TickerTo,
                        principalTable: "StockTickers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Ticker = table.Column<string>(nullable: true),
                    History = table.Column<DateTime>(nullable: false),
                    Open = table.Column<decimal>(nullable: false),
                    Close = table.Column<decimal>(nullable: false),
                    AdjustedClose = table.Column<decimal>(nullable: false),
                    High = table.Column<decimal>(nullable: false),
                    Low = table.Column<decimal>(nullable: false),
                    Volume = table.Column<decimal>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IsCurrency = table.Column<bool>(nullable: false),
                    Ask = table.Column<decimal>(nullable: false),
                    AverageDailyVolume10Day = table.Column<decimal>(nullable: false),
                    AverageDailyVolume3Month = table.Column<decimal>(nullable: false),
                    Bid = table.Column<decimal>(nullable: false),
                    BookValue = table.Column<decimal>(nullable: false),
                    DividendDate = table.Column<DateTime>(nullable: false),
                    EarningsTimestamp = table.Column<DateTime>(nullable: false),
                    EarningsTimestampEnd = table.Column<DateTime>(nullable: false),
                    EarningsTimestampStart = table.Column<DateTime>(nullable: false),
                    FiftyDayAverage = table.Column<decimal>(nullable: false),
                    FiftyDayAverageChange = table.Column<decimal>(nullable: false),
                    FiftyDayAverageChangePercent = table.Column<decimal>(nullable: false),
                    FiftyTwoWeekHigh = table.Column<decimal>(nullable: false),
                    FiftyTwoWeekHighChange = table.Column<decimal>(nullable: false),
                    FiftyTwoWeekHighChangePercent = table.Column<decimal>(nullable: false),
                    FiftyTwoWeekLow = table.Column<decimal>(nullable: false),
                    FiftyTwoWeekLowChange = table.Column<decimal>(nullable: false),
                    FiftyTwoWeekLowChangePercent = table.Column<decimal>(nullable: false),
                    RegularMarketChangePercent = table.Column<decimal>(nullable: false),
                    RegularMarketDayHigh = table.Column<decimal>(nullable: false),
                    RegularMarketDayLow = table.Column<decimal>(nullable: false),
                    RegularMarketOpen = table.Column<decimal>(nullable: false),
                    RegularMarketPreviousClose = table.Column<decimal>(nullable: false),
                    RegularMarketPrice = table.Column<decimal>(nullable: false),
                    RegularMarketVolume = table.Column<decimal>(nullable: false),
                    TwoHundredDayAverage = table.Column<decimal>(nullable: false),
                    TwoHundredDayAverageChange = table.Column<decimal>(nullable: false),
                    TwoHundredDayAverageChangePercent = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockHistories_StockTickers_Ticker",
                        column: x => x.Ticker,
                        principalTable: "StockTickers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockSplits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Ticker = table.Column<string>(nullable: true),
                    Factor = table.Column<short>(nullable: false),
                    SplitTimestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSplits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockSplits_StockTickers_Ticker",
                        column: x => x.Ticker,
                        principalTable: "StockTickers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Earnings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    EarningsDate = table.Column<DateTime>(nullable: false),
                    Ticker = table.Column<string>(nullable: true),
                    FromPortfolioId = table.Column<int>(nullable: false),
                    FromAccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Earnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Earnings_Accounts_FromAccountId",
                        column: x => x.FromAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Earnings_Portfolios_FromPortfolioId",
                        column: x => x.FromPortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Earnings_StockTickers_Ticker",
                        column: x => x.Ticker,
                        principalTable: "StockTickers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioStocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PortfolioId = table.Column<int>(nullable: false),
                    Ticker = table.Column<string>(nullable: true),
                    PurchaseTime = table.Column<DateTime>(nullable: false),
                    PurchaseQuantity = table.Column<short>(nullable: false),
                    PurchasePrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioStocks_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioStocks_StockTickers_Ticker",
                        column: x => x.Ticker,
                        principalTable: "StockTickers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Earnings_FromAccountId",
                table: "Earnings",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Earnings_FromPortfolioId",
                table: "Earnings",
                column: "FromPortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Earnings_Ticker",
                table: "Earnings",
                column: "Ticker");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_TickerFrom",
                table: "ExchangeRates",
                column: "TickerFrom");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_TickerTo",
                table: "ExchangeRates",
                column: "TickerTo");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_AccountId",
                table: "Portfolios",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioStocks_PortfolioId",
                table: "PortfolioStocks",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioStocks_Ticker",
                table: "PortfolioStocks",
                column: "Ticker");

            migrationBuilder.CreateIndex(
                name: "IX_StockHistories_Ticker",
                table: "StockHistories",
                column: "Ticker");

            migrationBuilder.CreateIndex(
                name: "IX_StockSplits_Ticker",
                table: "StockSplits",
                column: "Ticker");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Earnings");

            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "PortfolioStocks");

            migrationBuilder.DropTable(
                name: "StockHistories");

            migrationBuilder.DropTable(
                name: "StockSplits");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "StockTickers");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
