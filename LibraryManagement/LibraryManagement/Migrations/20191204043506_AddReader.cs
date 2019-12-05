using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Migrations
{
    public partial class AddReader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Reader");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Reader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Reader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Reader",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Reader");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reader");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Reader",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
