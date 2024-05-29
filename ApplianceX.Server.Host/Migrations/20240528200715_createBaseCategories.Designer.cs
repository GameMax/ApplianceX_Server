﻿// <auto-generated />
using System;
using ApplianceX.Server.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApplianceX.Server.Host.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20240528200715_createBaseCategories")]
    partial class createBaseCategories
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApplianceX.Server.Database.Rozetka.Brand.BrandModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductBrand");
                });

            modelBuilder.Entity("ApplianceX.Server.Database.Rozetka.Category.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryUid")
                        .HasColumnType("text");

                    b.Property<string>("Cover")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("ApplianceX.Server.Database.Rozetka.Product.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("CommentsAmount")
                        .HasColumnType("integer");

                    b.Property<string>("Cover")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("Discount")
                        .HasColumnType("integer");

                    b.Property<string>("GroupName")
                        .HasColumnType("text");

                    b.Property<string>("GroupTitle")
                        .HasColumnType("text");

                    b.Property<string>("Href")
                        .HasColumnType("text");

                    b.Property<int?>("OldPrice")
                        .HasColumnType("integer");

                    b.Property<int?>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("ProductType")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductUid")
                        .HasColumnType("integer");

                    b.Property<string>("SellStatus")
                        .HasColumnType("text");

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SellerId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ApplianceX.Server.Database.Rozetka.Product.Statistic.ProductStatisticModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Delivery")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Relevance")
                        .HasColumnType("integer");

                    b.Property<int>("Service")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductStatistic");
                });

            modelBuilder.Entity("ApplianceX.Server.Database.Rozetka.Seller.SellerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountVotes")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<string>("Rank")
                        .HasColumnType("text");

                    b.Property<string>("Seller")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("ApplianceX.Server.Database.Rozetka.Product.ProductModel", b =>
                {
                    b.HasOne("ApplianceX.Server.Database.Rozetka.Brand.BrandModel", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplianceX.Server.Database.Rozetka.Category.CategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplianceX.Server.Database.Rozetka.Seller.SellerModel", "SellerModel")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("SellerModel");
                });

            modelBuilder.Entity("ApplianceX.Server.Database.Rozetka.Product.Statistic.ProductStatisticModel", b =>
                {
                    b.HasOne("ApplianceX.Server.Database.Rozetka.Product.ProductModel", "ProductModel")
                        .WithOne("Statistic")
                        .HasForeignKey("ApplianceX.Server.Database.Rozetka.Product.Statistic.ProductStatisticModel", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductModel");
                });

            modelBuilder.Entity("ApplianceX.Server.Database.Rozetka.Product.ProductModel", b =>
                {
                    b.Navigation("Statistic")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
