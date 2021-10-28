﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20211028014048_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ProductManagementAPI.Entities.Product", b =>
                {
                    b.Property<Guid>("SKU")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("SKU");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductManagementAPI.Entities.ProductAttributes", b =>
                {
                    b.Property<Guid>("ProductSKU")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("ProductSKU1")
                        .HasColumnType("uuid");

                    b.Property<List<string>>("attributeValues")
                        .HasColumnType("text[]");

                    b.HasKey("ProductSKU");

                    b.HasIndex("ProductSKU1");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("ProductManagementAPI.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("ProductManagementAPI.Entities.ProductAttributes", b =>
                {
                    b.HasOne("ProductManagementAPI.Entities.Product", null)
                        .WithMany("Attributes")
                        .HasForeignKey("ProductSKU1");
                });

            modelBuilder.Entity("ProductManagementAPI.Entities.Product", b =>
                {
                    b.Navigation("Attributes");
                });
#pragma warning restore 612, 618
        }
    }
}