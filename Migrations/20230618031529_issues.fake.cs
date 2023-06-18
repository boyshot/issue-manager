using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebIssueManagementApp.Migrations
{
    public partial class issuesfake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Abstract", "DataBase", "DateBegin", "DateEnd", "IdUser", "Server", "Text", "UrlIssue" },
                values: new object[,]
                {
                    { 1, "Abstract 0", "DataBase 0", new DateTime(2023, 7, 18, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3607), null, 1, "Server 0", "Text 0", "UrlIssue 0" },
                    { 2, "Abstract 1", "DataBase 1", new DateTime(2023, 7, 19, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3700), null, 1, "Server 1", "Text 1", "UrlIssue 1" },
                    { 3, "Abstract 2", "DataBase 2", new DateTime(2023, 7, 20, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3706), null, 1, "Server 2", "Text 2", "UrlIssue 2" },
                    { 4, "Abstract 3", "DataBase 3", new DateTime(2023, 7, 21, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3710), null, 1, "Server 3", "Text 3", "UrlIssue 3" },
                    { 5, "Abstract 4", "DataBase 4", new DateTime(2023, 7, 22, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3714), null, 1, "Server 4", "Text 4", "UrlIssue 4" },
                    { 6, "Abstract 5", "DataBase 5", new DateTime(2023, 7, 23, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3722), null, 1, "Server 5", "Text 5", "UrlIssue 5" },
                    { 7, "Abstract 6", "DataBase 6", new DateTime(2023, 7, 24, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3726), null, 1, "Server 6", "Text 6", "UrlIssue 6" },
                    { 8, "Abstract 7", "DataBase 7", new DateTime(2023, 7, 25, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3730), null, 1, "Server 7", "Text 7", "UrlIssue 7" },
                    { 9, "Abstract 8", "DataBase 8", new DateTime(2023, 7, 26, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3734), null, 1, "Server 8", "Text 8", "UrlIssue 8" },
                    { 10, "Abstract 9", "DataBase 9", new DateTime(2023, 7, 27, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3739), null, 1, "Server 9", "Text 9", "UrlIssue 9" },
                    { 11, "Abstract 10", "DataBase 10", new DateTime(2023, 7, 28, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3744), null, 1, "Server 10", "Text 10", "UrlIssue 10" },
                    { 12, "Abstract 11", "DataBase 11", new DateTime(2023, 7, 29, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3749), null, 1, "Server 11", "Text 11", "UrlIssue 11" },
                    { 13, "Abstract 12", "DataBase 12", new DateTime(2023, 7, 30, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3753), null, 1, "Server 12", "Text 12", "UrlIssue 12" },
                    { 14, "Abstract 13", "DataBase 13", new DateTime(2023, 7, 31, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3757), null, 1, "Server 13", "Text 13", "UrlIssue 13" },
                    { 15, "Abstract 14", "DataBase 14", new DateTime(2023, 8, 1, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3761), null, 1, "Server 14", "Text 14", "UrlIssue 14" },
                    { 16, "Abstract 15", "DataBase 15", new DateTime(2023, 8, 2, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3766), null, 1, "Server 15", "Text 15", "UrlIssue 15" },
                    { 17, "Abstract 16", "DataBase 16", new DateTime(2023, 8, 3, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3770), null, 1, "Server 16", "Text 16", "UrlIssue 16" },
                    { 18, "Abstract 17", "DataBase 17", new DateTime(2023, 8, 4, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3776), null, 1, "Server 17", "Text 17", "UrlIssue 17" },
                    { 19, "Abstract 18", "DataBase 18", new DateTime(2023, 8, 5, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3780), null, 1, "Server 18", "Text 18", "UrlIssue 18" },
                    { 20, "Abstract 19", "DataBase 19", new DateTime(2023, 8, 6, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3785), null, 1, "Server 19", "Text 19", "UrlIssue 19" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name", "Password" },
                values: new object[] { "admin@issuemanager.com", "admin", "teste@123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name", "Password" },
                values: new object[] { "pauloandredarocha@gmail.com", "Paulo Rocha", "123456" });
        }
    }
}
