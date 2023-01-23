using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HelloMD.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LastSeen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WriterID = table.Column<int>(type: "int", nullable: true),
                    ReceiverID = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplayFor = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Messages_Accounts_ReceiverID",
                        column: x => x.ReceiverID,
                        principalTable: "Accounts",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Accounts_WriterID",
                        column: x => x.WriterID,
                        principalTable: "Accounts",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Messages_Messages_ReplayFor",
                        column: x => x.ReplayFor,
                        principalTable: "Messages",
                        principalColumn: "MessageID");
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "UserID", "Active", "CreatedAt", "FirstName", "LastName", "LastSeen", "Password", "Status", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 1, 23, 4, 41, 36, 781, DateTimeKind.Local).AddTicks(2658), "Zerihun", "H.", new DateTime(2023, 1, 23, 4, 41, 36, 781, DateTimeKind.Local).AddTicks(2568), "test", 0, new DateTime(2023, 1, 23, 4, 41, 36, 781, DateTimeKind.Local).AddTicks(2663), "zeru" },
                    { 2, true, new DateTime(2023, 1, 23, 4, 41, 36, 781, DateTimeKind.Local).AddTicks(2674), "lonel", "Prime", new DateTime(2023, 1, 23, 4, 41, 36, 781, DateTimeKind.Local).AddTicks(2671), "test", 0, new DateTime(2023, 1, 23, 4, 41, 36, 781, DateTimeKind.Local).AddTicks(2678), "lonel" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageID", "Body", "CreatedAt", "ReceiverID", "ReplayFor", "Status", "UpdatedAt", "WriterID" },
                values: new object[,]
                {
                    { 1, "Hi Bro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "How Are you ?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "I am God", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, "Any News ?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverID",
                table: "Messages",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReplayFor",
                table: "Messages",
                column: "ReplayFor");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_WriterID",
                table: "Messages",
                column: "WriterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
