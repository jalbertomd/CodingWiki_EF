﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddOneToOneRelation_Book_BookDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.AddColumn<int>(
                name: "Book_Id",
                table: "BooksDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BooksDetails_Book_Id",
                table: "BooksDetails",
                column: "Book_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksDetails_Books_Book_Id",
                table: "BooksDetails",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksDetails_Books_Book_Id",
                table: "BooksDetails");

            migrationBuilder.DropIndex(
                name: "IX_BooksDetails_Book_Id",
                table: "BooksDetails");

            migrationBuilder.DropColumn(
                name: "Book_Id",
                table: "BooksDetails");            
        }
    }
}