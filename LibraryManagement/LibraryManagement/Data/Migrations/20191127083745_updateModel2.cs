using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Data.Migrations
{
    public partial class updateModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Producer_ProducerId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Process_Book_BookId",
                table: "Process");

            migrationBuilder.DropForeignKey(
                name: "FK_Process_Borrowed_BorrowedId",
                table: "Process");

            migrationBuilder.RenameColumn(
                name: "BorrowedId",
                table: "Process",
                newName: "BorrowedID");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Process",
                newName: "BookID");

            migrationBuilder.RenameColumn(
                name: "ProcessId",
                table: "Process",
                newName: "ProcessID");

            migrationBuilder.RenameIndex(
                name: "IX_Process_BorrowedId",
                table: "Process",
                newName: "IX_Process_BorrowedID");

            migrationBuilder.RenameIndex(
                name: "IX_Process_BookId",
                table: "Process",
                newName: "IX_Process_BookID");

            migrationBuilder.RenameColumn(
                name: "ProducerId",
                table: "Book",
                newName: "ProducerID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Book",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Book",
                newName: "AuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_Book_ProducerId",
                table: "Book",
                newName: "IX_Book_ProducerID");

            migrationBuilder.RenameIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                newName: "IX_Book_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                newName: "IX_Book_AuthorID");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryID",
                table: "Book",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Producer_ProducerID",
                table: "Book",
                column: "ProducerID",
                principalTable: "Producer",
                principalColumn: "ProducerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Book_BookID",
                table: "Process",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Borrowed_BorrowedID",
                table: "Process",
                column: "BorrowedID",
                principalTable: "Borrowed",
                principalColumn: "BorrowedID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryID",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Producer_ProducerID",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Process_Book_BookID",
                table: "Process");

            migrationBuilder.DropForeignKey(
                name: "FK_Process_Borrowed_BorrowedID",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "BorrowedID",
                table: "Process",
                newName: "BorrowedId");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "Process",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "ProcessID",
                table: "Process",
                newName: "ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_Process_BorrowedID",
                table: "Process",
                newName: "IX_Process_BorrowedId");

            migrationBuilder.RenameIndex(
                name: "IX_Process_BookID",
                table: "Process",
                newName: "IX_Process_BookId");

            migrationBuilder.RenameColumn(
                name: "ProducerID",
                table: "Book",
                newName: "ProducerId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Book",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Book",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_ProducerID",
                table: "Book",
                newName: "IX_Book_ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_CategoryID",
                table: "Book",
                newName: "IX_Book_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorID",
                table: "Book",
                newName: "IX_Book_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Producer_ProducerId",
                table: "Book",
                column: "ProducerId",
                principalTable: "Producer",
                principalColumn: "ProducerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Book_BookId",
                table: "Process",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Borrowed_BorrowedId",
                table: "Process",
                column: "BorrowedId",
                principalTable: "Borrowed",
                principalColumn: "BorrowedID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
