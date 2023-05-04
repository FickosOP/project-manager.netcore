using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Migrations
{
    public partial class UpdateClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeamMemberId",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Time",
                table: "Reports",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LeadId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ClientId",
                table: "Reports",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ProjectId",
                table: "Reports",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_TeamMemberId",
                table: "Reports",
                column: "TeamMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LeadId",
                table: "Projects",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Clients_ClientId",
                table: "Projects",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_TeamMembers_LeadId",
                table: "Projects",
                column: "LeadId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Clients_ClientId",
                table: "Reports",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Projects_ProjectId",
                table: "Reports",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_TeamMembers_TeamMemberId",
                table: "Reports",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Clients_ClientId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_TeamMembers_LeadId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Clients_ClientId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Projects_ProjectId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_TeamMembers_TeamMemberId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ClientId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ProjectId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_TeamMemberId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ClientId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_LeadId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "TeamMemberId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LeadId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Clients");
        }
    }
}
