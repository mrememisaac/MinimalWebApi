﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinimalWebApi.Data;

#nullable disable

namespace MinimalWebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220510235809_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("MinimalWebApi.Entities.Picture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Base64String")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Pictures", (string)null);
                });

            modelBuilder.Entity("MinimalWebApi.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("7cebcd73-6050-4b7a-aa26-279e43b976b6"),
                            Description = "Thinkpad Business Grade Laptop",
                            Name = "Thinkpad Lenovo",
                            Price = 214650
                        },
                        new
                        {
                            Id = new Guid("e4aa1379-b042-460f-98ad-431943450e20"),
                            Description = "MacBook Pro Laptop",
                            Name = "MacBook Pro",
                            Price = 523849
                        },
                        new
                        {
                            Id = new Guid("0fb88f76-e0ab-401c-9fb6-3699ec74f3fa"),
                            Description = "Small Business Server",
                            Name = "HP GL9 Tower Server",
                            Price = 492147
                        });
                });

            modelBuilder.Entity("MinimalWebApi.Entities.Picture", b =>
                {
                    b.HasOne("MinimalWebApi.Entities.Product", null)
                        .WithMany("PicturesCollection")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MinimalWebApi.Entities.Product", b =>
                {
                    b.Navigation("PicturesCollection");
                });
#pragma warning restore 612, 618
        }
    }
}