using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MedHelp.Migrations
{
    public partial class ExplicitFormModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelJson",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "ModelJson",
                table: "LastOpenedDocuments");

            migrationBuilder.AddColumn<int>(
                name: "FormModelId",
                table: "Templates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FormModelId",
                table: "LastOpenedDocuments",
                nullable: false,
                defaultValue: 0);

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
                name: "FormModels",
                columns: table => new
                {
                    FormModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Anamnesis = table.Column<string>(nullable: true),
                    DoctorName = table.Column<string>(nullable: true),
                    PatientBirthday = table.Column<DateTime>(nullable: false),
                    PatientName = table.Column<string>(nullable: true),
                    Recommended = table.Column<string>(nullable: true),
                    Speciality = table.Column<string>(nullable: true),
                    VisitDay = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormModels", x => x.FormModelId);
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

            migrationBuilder.CreateTable(
                name: "MedicineFormModel",
                columns: table => new
                {
                    MedicineId = table.Column<int>(nullable: false),
                    FormModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineFormModel", x => new { x.MedicineId, x.FormModelId });
                    table.ForeignKey(
                        name: "FK_MedicineFormModel_FormModels_FormModelId",
                        column: x => x.FormModelId,
                        principalTable: "FormModels",
                        principalColumn: "FormModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineFormModel_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Templates_FormModelId",
                table: "Templates",
                column: "FormModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LastOpenedDocuments_FormModelId",
                table: "LastOpenedDocuments",
                column: "FormModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintFormModel_FormModelId",
                table: "ComplaintFormModel",
                column: "FormModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineFormModel_FormModelId",
                table: "MedicineFormModel",
                column: "FormModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_LastOpenedDocuments_FormModels_FormModelId",
                table: "LastOpenedDocuments",
                column: "FormModelId",
                principalTable: "FormModels",
                principalColumn: "FormModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_FormModels_FormModelId",
                table: "Templates",
                column: "FormModelId",
                principalTable: "FormModels",
                principalColumn: "FormModelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LastOpenedDocuments_FormModels_FormModelId",
                table: "LastOpenedDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_Templates_FormModels_FormModelId",
                table: "Templates");

            migrationBuilder.DropTable(
                name: "ComplaintFormModel");

            migrationBuilder.DropTable(
                name: "MedicineFormModel");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "FormModels");

            migrationBuilder.DropIndex(
                name: "IX_Templates_FormModelId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_LastOpenedDocuments_FormModelId",
                table: "LastOpenedDocuments");

            migrationBuilder.DropColumn(
                name: "FormModelId",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "FormModelId",
                table: "LastOpenedDocuments");

            migrationBuilder.AddColumn<string>(
                name: "ModelJson",
                table: "Templates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelJson",
                table: "LastOpenedDocuments",
                nullable: true);
        }
    }
}
