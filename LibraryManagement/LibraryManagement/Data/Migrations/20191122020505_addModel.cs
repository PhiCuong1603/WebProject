using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Data.Migrations
{
    public partial class addModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Librarian",
                columns: table => new
                {
                    LibrarianID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibrarianName = table.Column<string>(nullable: true),
                    Birth = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarian", x => x.LibrarianID);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    ProducerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducerName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.ProducerID);
                });

            migrationBuilder.CreateTable(
                name: "Reader",
                columns: table => new
                {
                    ReaderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReaderName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader", x => x.ReaderID);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(nullable: true),
                    BookImage = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    ProducerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Producer_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer",
                        principalColumn: "ProducerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCard",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Begin = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    ReaderId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Borrowed",
                columns: table => new
                {
                    BorrowedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowedDate = table.Column<DateTime>(nullable: false),
                    CardID = table.Column<int>(nullable: false),
                    LibrarianID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowed", x => x.BorrowedID);
                    table.ForeignKey(
                        name: "FK_Borrowed_LibraryCard_CardID",
                        column: x => x.CardID,
                        principalTable: "LibraryCard",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrowed_Librarian_LibrarianID",
                        column: x => x.LibrarianID,
                        principalTable: "Librarian",
                        principalColumn: "LibrarianID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    ProcessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowedId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Complete = table.Column<bool>(nullable: false),
                    CompleteDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.ProcessId);
                    table.ForeignKey(
                        name: "FK_Process_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Process_Borrowed_BorrowedId",
                        column: x => x.BorrowedId,
                        principalTable: "Borrowed",
                        principalColumn: "BorrowedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_ProducerId",
                table: "Book",
                column: "ProducerId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Process_BookId",
                table: "Process",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Process_BorrowedId",
                table: "Process",
                column: "BorrowedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Process");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Borrowed");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "LibraryCard");

            migrationBuilder.DropTable(
                name: "Librarian");

            migrationBuilder.DropTable(
                name: "Reader");
        }
    }
}
