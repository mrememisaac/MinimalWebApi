﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsApi.Data;

#nullable disable

namespace ProductsApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("ProductsApi.Entities.Picture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Base64String")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Pictures", (string)null);
                });

            modelBuilder.Entity("ProductsApi.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

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
                            Id = new Guid("bdd2c325-e768-4b80-950f-8810ec33b3ec"),
                            CreatedBy = "seeder",
                            DateCreated = new DateTimeOffset(new DateTime(2022, 5, 13, 18, 0, 29, 547, DateTimeKind.Unspecified).AddTicks(6879), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "Thinkpad Business Grade Laptop",
                            Name = "Thinkpad Lenovo",
                            Price = 214650
                        },
                        new
                        {
                            Id = new Guid("bdfc26f2-05c7-4375-9231-76d997db19e7"),
                            CreatedBy = "seeder",
                            DateCreated = new DateTimeOffset(new DateTime(2022, 5, 13, 18, 0, 29, 547, DateTimeKind.Unspecified).AddTicks(6914), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "MacBook Pro Laptop",
                            Name = "MacBook Pro",
                            Price = 523849
                        },
                        new
                        {
                            Id = new Guid("262e9283-ce3a-4cd5-b6a0-0459475da39c"),
                            CreatedBy = "seeder",
                            DateCreated = new DateTimeOffset(new DateTime(2022, 5, 13, 18, 0, 29, 547, DateTimeKind.Unspecified).AddTicks(6919), new TimeSpan(0, 1, 0, 0, 0)),
                            Description = "Small Business Server",
                            Name = "HP GL9 Tower Server",
                            Price = 492147
                        });
                });

            modelBuilder.Entity("ProductsApi.Entities.Picture", b =>
                {
                    b.HasOne("ProductsApi.Entities.Product", "Product")
                        .WithMany("PicturesCollection")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductsApi.Entities.Product", b =>
                {
                    b.Navigation("PicturesCollection");
                });
#pragma warning restore 612, 618
        }
    }
}
