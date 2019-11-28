using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Data.Migrations
{
    public partial class updateModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrowed_LibraryCard_CardID",
                table: "Borrowed");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrowed_Librarian_LibrarianID",
                table: "Borrowed");

            migrationBuilder.DropTable(
                name: "Librarian");

            migrationBuilder.DropTable(
                name: "LibraryCard");

            migrationBuilder.DropIndex(
                name: "IX_Borrowed_CardID",
                table: "Borrowed");

            migrationBuilder.DropIndex(
                name: "IX_Borrowed_LibrarianID",
                table: "Borrowed");

            migrationBuilder.DropColumn(
                name: "CardID",
                table: "Borrowed");

            migrationBuilder.DropColumn(
                name: "LibrarianID",
                table: "Borrowed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardID",
                table: "Borrowed",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LibrarianID",
                table: "Borrowed",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Librarian",
                columns: table => new
                {
                    LibrarianID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibrarianName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarian", x => x.LibrarianID);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCard",
                columns: table => new
                {
                    CardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCard", x => x.CardID);
                    table.ForeignKey(
                        name: "FK_LibraryCard_Reader_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Reader",
                        principalColumn: "ReaderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Borrowed_CardID",
                table: "Borrowed",
                column: "CardID");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowed_LibrarianID",
                table: "Borrowed",
                column: "LibrarianID");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCard_ReaderId",
                table: "LibraryCard",
                column: "ReaderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowed_LibraryCard_CardID",
                table: "Borrowed",
                column: "CardID",
                principalTable: "LibraryCard",
                principalColumn: "CardID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowed_Librarian_LibrarianID",
                table: "Borrowed",
                column: "LibrarianID",
                principalTable: "Librarian",
                principalColumn: "LibrarianID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
