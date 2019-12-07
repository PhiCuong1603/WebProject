using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Migrations
{
    public partial class updateReader2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process_Reader_ReaderID",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "ReaderEmail",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "ReaderName",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "ReaderPhoneNumber",
                table: "Process");

            migrationBuilder.AlterColumn<int>(
                name: "ReaderID",
                table: "Process",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Reader_ReaderID",
                table: "Process",
                column: "ReaderID",
                principalTable: "Reader",
                principalColumn: "ReaderID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process_Reader_ReaderID",
                table: "Process");

            migrationBuilder.AlterColumn<int>(
                name: "ReaderID",
                table: "Process",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Process",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReaderEmail",
                table: "Process",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReaderName",
                table: "Process",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReaderPhoneNumber",
                table: "Process",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Reader_ReaderID",
                table: "Process",
                column: "ReaderID",
                principalTable: "Reader",
                principalColumn: "ReaderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
