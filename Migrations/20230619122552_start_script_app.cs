using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebIssueManagementApp.Migrations
{
    public partial class start_script_app : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataBase = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Server = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    UrlIssue = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Text = table.Column<string>(type: "varchar(max)", nullable: true),
                    Abstract = table.Column<string>(type: "varchar(100)", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issues_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdIssue = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ContentType = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Issues_IdIssue",
                        column: x => x.IdIssue,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "admin@issuemanager.com", "admin", "teste@123" });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Abstract", "DataBase", "DateBegin", "DateEnd", "IdUser", "Server", "Text", "UrlIssue" },
                values: new object[,]
                {
                    { 1, "Abstract 0", "DataBase 0", new DateTime(2023, 7, 19, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5083), null, 1, "Server 0", "Text 0", "UrlIssue 0" },
                    { 2, "Abstract 1", "DataBase 1", new DateTime(2023, 7, 20, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5157), null, 1, "Server 1", "Text 1", "UrlIssue 1" },
                    { 3, "Abstract 2", "DataBase 2", new DateTime(2023, 7, 21, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5162), null, 1, "Server 2", "Text 2", "UrlIssue 2" },
                    { 4, "Abstract 3", "DataBase 3", new DateTime(2023, 7, 22, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5166), null, 1, "Server 3", "Text 3", "UrlIssue 3" },
                    { 5, "Abstract 4", "DataBase 4", new DateTime(2023, 7, 23, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5171), null, 1, "Server 4", "Text 4", "UrlIssue 4" },
                    { 6, "Abstract 5", "DataBase 5", new DateTime(2023, 7, 24, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5177), null, 1, "Server 5", "Text 5", "UrlIssue 5" },
                    { 7, "Abstract 6", "DataBase 6", new DateTime(2023, 7, 25, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5181), null, 1, "Server 6", "Text 6", "UrlIssue 6" },
                    { 8, "Abstract 7", "DataBase 7", new DateTime(2023, 7, 26, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5185), null, 1, "Server 7", "Text 7", "UrlIssue 7" },
                    { 9, "Abstract 8", "DataBase 8", new DateTime(2023, 7, 27, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5189), null, 1, "Server 8", "Text 8", "UrlIssue 8" },
                    { 10, "Abstract 9", "DataBase 9", new DateTime(2023, 7, 28, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5194), null, 1, "Server 9", "Text 9", "UrlIssue 9" },
                    { 11, "Abstract 10", "DataBase 10", new DateTime(2023, 7, 29, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5199), null, 1, "Server 10", "Text 10", "UrlIssue 10" },
                    { 12, "Abstract 11", "DataBase 11", new DateTime(2023, 7, 30, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5203), null, 1, "Server 11", "Text 11", "UrlIssue 11" },
                    { 13, "Abstract 12", "DataBase 12", new DateTime(2023, 7, 31, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5207), null, 1, "Server 12", "Text 12", "UrlIssue 12" },
                    { 14, "Abstract 13", "DataBase 13", new DateTime(2023, 8, 1, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5211), null, 1, "Server 13", "Text 13", "UrlIssue 13" },
                    { 15, "Abstract 14", "DataBase 14", new DateTime(2023, 8, 2, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5215), null, 1, "Server 14", "Text 14", "UrlIssue 14" },
                    { 16, "Abstract 15", "DataBase 15", new DateTime(2023, 8, 3, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5219), null, 1, "Server 15", "Text 15", "UrlIssue 15" },
                    { 17, "Abstract 16", "DataBase 16", new DateTime(2023, 8, 4, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5223), null, 1, "Server 16", "Text 16", "UrlIssue 16" },
                    { 18, "Abstract 17", "DataBase 17", new DateTime(2023, 8, 5, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5229), null, 1, "Server 17", "Text 17", "UrlIssue 17" },
                    { 19, "Abstract 18", "DataBase 18", new DateTime(2023, 8, 6, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5233), null, 1, "Server 18", "Text 18", "UrlIssue 18" },
                    { 20, "Abstract 19", "DataBase 19", new DateTime(2023, 8, 7, 9, 25, 52, 653, DateTimeKind.Local).AddTicks(5237), null, 1, "Server 19", "Text 19", "UrlIssue 19" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_IdIssue",
                table: "Attachments",
                column: "IdIssue");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IdUser",
                table: "Issues",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
