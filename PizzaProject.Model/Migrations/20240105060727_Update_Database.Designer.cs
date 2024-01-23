﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaProject.Model.Context;

#nullable disable

namespace PizzaProject.Model.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    [Migration("20240105060727_Update_Database")]
    partial class Update_Database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PizzaProject.Model.Tables.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PizzaProject.Model.Tables.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("PizzaCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PizzaCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PizzaProject.Model.Tables.SubCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("PizzaProject.Model.Tables.Product", b =>
                {
                    b.HasOne("PizzaProject.Model.Tables.Category", "Category")
                        .WithMany("Categoriess")
                        .HasForeignKey("CategoryId");

                    b.HasOne("PizzaProject.Model.Tables.SubCategory", "PizzaCategory")
                        .WithMany("Pizzass")
                        .HasForeignKey("PizzaCategoryId");

                    b.Navigation("Category");

                    b.Navigation("PizzaCategory");
                });

            modelBuilder.Entity("PizzaProject.Model.Tables.SubCategory", b =>
                {
                    b.HasOne("PizzaProject.Model.Tables.Category", "Categories")
                        .WithMany("PizzaCategories")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("PizzaProject.Model.Tables.Category", b =>
                {
                    b.Navigation("Categoriess");

                    b.Navigation("PizzaCategories");
                });

            modelBuilder.Entity("PizzaProject.Model.Tables.SubCategory", b =>
                {
                    b.Navigation("Pizzass");
                });
#pragma warning restore 612, 618
        }
    }
}
