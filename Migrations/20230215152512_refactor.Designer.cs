﻿// <auto-generated />
using System;
using LearnASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearnASP.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230215152512_refactor")]
    partial class refactor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LearnASP.Models.Bill", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("buyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createdAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 2, 15, 15, 25, 12, 759, DateTimeKind.Utc).AddTicks(756));

                    b.Property<int>("status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<double>("totalPrice")
                        .HasColumnType("float");

                    b.Property<int>("totalQuantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("buyerId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("LearnASP.Models.BillDetail", b =>
                {
                    b.Property<Guid>("billId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("productId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("billId", "productId");

                    b.HasIndex("productId");

                    b.ToTable("BillDetail");
                });

            modelBuilder.Entity("LearnASP.Models.Category", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("LearnASP.Models.Product", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("categoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("LearnASP.Models.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LearnASP.Models.Bill", b =>
                {
                    b.HasOne("LearnASP.Models.User", "buyer")
                        .WithMany("bills")
                        .HasForeignKey("buyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("buyer");
                });

            modelBuilder.Entity("LearnASP.Models.BillDetail", b =>
                {
                    b.HasOne("LearnASP.Models.Bill", "bill")
                        .WithMany("billDetails")
                        .HasForeignKey("billId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnASP.Models.Product", "product")
                        .WithMany("billDetails")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bill");

                    b.Navigation("product");
                });

            modelBuilder.Entity("LearnASP.Models.Product", b =>
                {
                    b.HasOne("LearnASP.Models.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("LearnASP.Models.Bill", b =>
                {
                    b.Navigation("billDetails");
                });

            modelBuilder.Entity("LearnASP.Models.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("LearnASP.Models.Product", b =>
                {
                    b.Navigation("billDetails");
                });

            modelBuilder.Entity("LearnASP.Models.User", b =>
                {
                    b.Navigation("bills");
                });
#pragma warning restore 612, 618
        }
    }
}
