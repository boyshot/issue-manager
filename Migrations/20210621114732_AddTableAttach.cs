using Microsoft.EntityFrameworkCore.Migrations;

namespace WebIssueManagementApp.Migrations
{
    public partial class AddTableAttach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Attachments",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Attachments");
        }
    }
}
