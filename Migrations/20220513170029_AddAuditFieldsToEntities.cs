using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Migrations
{
    public partial class AddAuditFieldsToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0fb88f76-e0ab-401c-9fb6-3699ec74f3fa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cebcd73-6050-4b7a-aa26-279e43b976b6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e4aa1379-b042-460f-98ad-431943450e20"));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Pictures",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Pictures",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "Description", "Name", "Price" },
                values: new object[] { new Guid("262e9283-ce3a-4cd5-b6a0-0459475da39c"), "seeder", new DateTimeOffset(new DateTime(2022, 5, 13, 18, 0, 29, 547, DateTimeKind.Unspecified).AddTicks(6919), new TimeSpan(0, 1, 0, 0, 0)), "Small Business Server", "HP GL9 Tower Server", 492147 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "Description", "Name", "Price" },
                values: new object[] { new Guid("bdd2c325-e768-4b80-950f-8810ec33b3ec"), "seeder", new DateTimeOffset(new DateTime(2022, 5, 13, 18, 0, 29, 547, DateTimeKind.Unspecified).AddTicks(6879), new TimeSpan(0, 1, 0, 0, 0)), "Thinkpad Business Grade Laptop", "Thinkpad Lenovo", 214650 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "Description", "Name", "Price" },
                values: new object[] { new Guid("bdfc26f2-05c7-4375-9231-76d997db19e7"), "seeder", new DateTimeOffset(new DateTime(2022, 5, 13, 18, 0, 29, 547, DateTimeKind.Unspecified).AddTicks(6914), new TimeSpan(0, 1, 0, 0, 0)), "MacBook Pro Laptop", "MacBook Pro", 523849 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("262e9283-ce3a-4cd5-b6a0-0459475da39c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bdd2c325-e768-4b80-950f-8810ec33b3ec"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bdfc26f2-05c7-4375-9231-76d997db19e7"));

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Pictures");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { new Guid("0fb88f76-e0ab-401c-9fb6-3699ec74f3fa"), "Small Business Server", "HP GL9 Tower Server", 492147 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { new Guid("7cebcd73-6050-4b7a-aa26-279e43b976b6"), "Thinkpad Business Grade Laptop", "Thinkpad Lenovo", 214650 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { new Guid("e4aa1379-b042-460f-98ad-431943450e20"), "MacBook Pro Laptop", "MacBook Pro", 523849 });
        }
    }
}
