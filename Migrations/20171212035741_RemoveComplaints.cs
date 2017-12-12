using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MedHelp.Migrations
{
    public partial class RemoveComplaints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplaintFormModel");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.AddColumn<string>(
                name: "Complaints",
                table: "FormModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complaints",
                table: "FormModels");

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    ComplaintId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplaintDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.ComplaintId);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintFormModel",
                columns: table => new
                {
                    ComplaintId = table.Column<int>(nullable: false),
                    FormModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintFormModel", x => new { x.ComplaintId, x.FormModelId });
                    table.ForeignKey(
                        name: "FK_ComplaintFormModel_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "ComplaintId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplaintFormModel_FormModels_FormModelId",
                        column: x => x.FormModelId,
                        principalTable: "FormModels",
                        principalColumn: "FormModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintFormModel_FormModelId",
                table: "ComplaintFormModel",
                column: "FormModelId");
        }
    }
}
