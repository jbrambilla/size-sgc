using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Domain.Migrations
{
    public partial class OptionalCategoryInDemand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demands_Categories_CategoryId",
                table: "Demands");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Demands",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Demands_Categories_CategoryId",
                table: "Demands",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demands_Categories_CategoryId",
                table: "Demands");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Demands",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Demands_Categories_CategoryId",
                table: "Demands",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
