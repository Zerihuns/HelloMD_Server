using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HelloMD.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastSeen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedAt", "FirstName", "LastName", "LastSeen", "Password", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 21, 11, 51, 28, 716, DateTimeKind.Local).AddTicks(2364), "Zerihun", "H.", new DateTime(2023, 1, 21, 11, 51, 28, 716, DateTimeKind.Local).AddTicks(2293), "test", new DateTime(2023, 1, 21, 11, 51, 28, 716, DateTimeKind.Local).AddTicks(2369), "zeru" },
                    { 2, new DateTime(2023, 1, 21, 11, 51, 28, 716, DateTimeKind.Local).AddTicks(2384), "loine", "K.", new DateTime(2023, 1, 21, 11, 51, 28, 716, DateTimeKind.Local).AddTicks(2380), "test", new DateTime(2023, 1, 21, 11, 51, 28, 716, DateTimeKind.Local).AddTicks(2387), "loli" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
