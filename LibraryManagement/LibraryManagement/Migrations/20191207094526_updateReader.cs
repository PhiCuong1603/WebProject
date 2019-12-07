using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Migrations
{
    public partial class updateReader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Process",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReaderID",
                table: "Process",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Process_ReaderID",
                table: "Process",
                column: "ReaderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Reader_ReaderID",
                table: "Process",
                column: "ReaderID",
                principalTable: "Reader",
                principalColumn: "ReaderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process_Reader_ReaderID",
                table: "Process");

            migrationBuilder.DropIndex(
                name: "IX_Process_ReaderID",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "ReaderID",
                table: "Process");
        }
    }
}
