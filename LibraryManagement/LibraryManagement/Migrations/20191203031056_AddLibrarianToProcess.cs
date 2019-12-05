using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Migrations
{
    public partial class AddLibrarianToProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LibrarianID",
                table: "Process",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Process_LibrarianID",
                table: "Process",
                column: "LibrarianID");

            migrationBuilder.AddForeignKey(
                name: "FK_Process_AspNetUsers_LibrarianID",
                table: "Process",
                column: "LibrarianID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process_AspNetUsers_LibrarianID",
                table: "Process");

            migrationBuilder.DropIndex(
                name: "IX_Process_LibrarianID",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "LibrarianID",
                table: "Process");
        }
    }
}
