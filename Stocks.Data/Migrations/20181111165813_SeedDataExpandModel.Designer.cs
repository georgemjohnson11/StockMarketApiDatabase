﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Stocks.Data.Models;

namespace Stocks.Data.Migrations
{
    [DbContext(typeof(StockDbContext))]
    [Migration("20181111165813_SeedDataExpandModel")]
    partial class SeedDataExpandModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Stocks.Data.Models.Accounts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Stocks.Data.Models.CsvPipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<string>("LocalizationCulture");

                    b.Property<string>("ResourceKey");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Pipes");
                });

            modelBuilder.Entity("Stocks.Data.Models.Earnings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("EarningsDate");

                    b.Property<int>("FromAccountId");

                    b.Property<int>("FromPortfolioId");

                    b.Property<string>("Ticker");

                    b.HasKey("Id");

                    b.HasIndex("FromAccountId");

                    b.HasIndex("FromPortfolioId");

                    b.HasIndex("Ticker");

                    b.ToTable("Earnings");
                });

            modelBuilder.Entity("Stocks.Data.Models.ExchangeRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("RateTime");

                    b.Property<short>("Ratio");

                    b.Property<string>("TickerFrom");

                    b.Property<string>("TickerTo");

                    b.HasKey("Id");

                    b.HasIndex("TickerFrom");

                    b.HasIndex("TickerTo");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("Stocks.Data.Models.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<short>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("Stocks.Data.Models.PortfolioStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PortfolioId");

                    b.Property<decimal>("PurchasePrice");

                    b.Property<short>("PurchaseQuantity");

                    b.Property<DateTime>("PurchaseTime");

                    b.Property<string>("Ticker");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("Ticker");

                    b.ToTable("PortfolioStocks");
                });

            modelBuilder.Entity("Stocks.Data.Models.StockHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<decimal>("AdjustedClose");

                    b.Property<decimal>("Close");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Dividend");

                    b.Property<DateTime>("DividendDate");

                    b.Property<decimal>("High");

                    b.Property<bool>("IsCurrency");

                    b.Property<decimal>("Low");

                    b.Property<decimal>("Open");

                    b.Property<string>("Ticker");

                    b.Property<decimal>("Volume");

                    b.HasKey("Id");

                    b.HasIndex("Ticker");

                    b.ToTable("StockHistories");
                });

            modelBuilder.Entity("Stocks.Data.Models.StockSplits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AfterSplit");

                    b.Property<decimal>("BeforeSplit");

                    b.Property<DateTime>("SplitTimestamp");

                    b.Property<string>("Ticker");

                    b.HasKey("Id");

                    b.HasIndex("Ticker");

                    b.ToTable("StockSplits");
                });

            modelBuilder.Entity("Stocks.Data.Models.StockTicker", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ADR_TSO");

                    b.Property<bool>("Active");

                    b.Property<string>("Country");

                    b.Property<string>("ExchangeMarket");

                    b.Property<DateTime>("IPOYear");

                    b.Property<string>("Industry");

                    b.Property<bool>("IsCurrency");

                    b.Property<DateTime>("LastSale");

                    b.Property<decimal>("MarketCap");

                    b.Property<string>("Name");

                    b.Property<string>("Sector");

                    b.Property<DateTime>("UpdatedTime");

                    b.HasKey("Id");

                    b.ToTable("StockTickers");
                });

            modelBuilder.Entity("Stocks.Data.Models.Earnings", b =>
                {
                    b.HasOne("Stocks.Data.Models.Accounts", "AccountId")
                        .WithMany()
                        .HasForeignKey("FromAccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Stocks.Data.Models.Portfolio", "PortfolioId")
                        .WithMany()
                        .HasForeignKey("FromPortfolioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Stocks.Data.Models.StockTicker", "StockTicker")
                        .WithMany()
                        .HasForeignKey("Ticker");
                });

            modelBuilder.Entity("Stocks.Data.Models.ExchangeRate", b =>
                {
                    b.HasOne("Stocks.Data.Models.StockTicker", "TickerToId")
                        .WithMany()
                        .HasForeignKey("TickerFrom");

                    b.HasOne("Stocks.Data.Models.StockTicker", "TickerFromId")
                        .WithMany()
                        .HasForeignKey("TickerTo");
                });

            modelBuilder.Entity("Stocks.Data.Models.Portfolio", b =>
                {
                    b.HasOne("Stocks.Data.Models.Accounts", "Accounts")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Stocks.Data.Models.PortfolioStock", b =>
                {
                    b.HasOne("Stocks.Data.Models.Portfolio", "Porfolio")
                        .WithMany()
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Stocks.Data.Models.StockTicker", "StockTicker")
                        .WithMany()
                        .HasForeignKey("Ticker");
                });

            modelBuilder.Entity("Stocks.Data.Models.StockHistory", b =>
                {
                    b.HasOne("Stocks.Data.Models.StockTicker", "StockTicker")
                        .WithMany()
                        .HasForeignKey("Ticker");
                });

            modelBuilder.Entity("Stocks.Data.Models.StockSplits", b =>
                {
                    b.HasOne("Stocks.Data.Models.StockTicker", "StockTicker")
                        .WithMany()
                        .HasForeignKey("Ticker");
                });
#pragma warning restore 612, 618
        }
    }
}
