﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Stocks.Data;

namespace Stocks.Data.Migrations
{
    [DbContext(typeof(StockDbContext))]
    partial class StockDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Stocks.Data.Models.Earnings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("EarningsDate");

                    b.Property<int>("FromAccountId");

                    b.Property<int>("FromPortfolioId");

                    b.Property<string>("FromStockHistoryId");

                    b.HasKey("Id");

                    b.HasIndex("FromAccountId");

                    b.HasIndex("FromPortfolioId");

                    b.HasIndex("FromStockHistoryId");

                    b.ToTable("Earnings");
                });

            modelBuilder.Entity("Stocks.Data.Models.ExchangeRates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrencyFromId");

                    b.Property<string>("CurrencyToId");

                    b.Property<DateTime>("RateTime");

                    b.Property<short>("Ratio");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyFromId");

                    b.HasIndex("CurrencyToId");

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

                    b.Property<string>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("StockId");

                    b.ToTable("PortfolioStocks");
                });

            modelBuilder.Entity("Stocks.Data.Models.StockHistory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("Close");

                    b.Property<DateTime>("History");

                    b.Property<short>("Open");

                    b.Property<short>("Volume");

                    b.HasKey("Id");

                    b.ToTable("StockHistories");
                });

            modelBuilder.Entity("Stocks.Data.Models.StockSplits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("Factor");

                    b.Property<DateTime>("SplitTimestamp");

                    b.Property<string>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("StockSplits");
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

                    b.HasOne("Stocks.Data.Models.StockHistory", "StockHistoryId")
                        .WithMany()
                        .HasForeignKey("FromStockHistoryId");
                });

            modelBuilder.Entity("Stocks.Data.Models.ExchangeRates", b =>
                {
                    b.HasOne("Stocks.Data.Models.StockHistory", "StockFromId")
                        .WithMany()
                        .HasForeignKey("CurrencyFromId");

                    b.HasOne("Stocks.Data.Models.StockHistory", "StockToId")
                        .WithMany()
                        .HasForeignKey("CurrencyToId");
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

                    b.HasOne("Stocks.Data.Models.StockHistory", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId");
                });

            modelBuilder.Entity("Stocks.Data.Models.StockSplits", b =>
                {
                    b.HasOne("Stocks.Data.Models.StockHistory", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId");
                });
#pragma warning restore 612, 618
        }
    }
}
