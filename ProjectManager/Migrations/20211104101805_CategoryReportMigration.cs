using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Migrations
{
    public partial class CategoryReportMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Reports");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CategoryId",
                table: "Reports",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Category_CategoryId",
                table: "Reports",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Category_CategoryId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Reports_CategoryId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
