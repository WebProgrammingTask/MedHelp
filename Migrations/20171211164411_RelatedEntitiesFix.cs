using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MedHelp.Migrations
{
    public partial class RelatedEntitiesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Fields_FieldId",
                table: "Property");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Property",
                table: "Property");

            migrationBuilder.RenameTable(
                name: "Property",
                newName: "Properties");

            migrationBuilder.RenameIndex(
                name: "IX_Property_FieldId",
                table: "Properties",
                newName: "IX_Properties_FieldId");

            migrationBuilder.AlterColumn<int>(
                name: "FieldId",
                table: "Properties",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Fields_FieldId",
                table: "Properties",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "FieldId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Fields_FieldId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.RenameTable(
                name: "Properties",
                newName: "Property");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_FieldId",
                table: "Property",
                newName: "IX_Property_FieldId");

            migrationBuilder.AlterColumn<int>(
                name: "FieldId",
                table: "Property",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Property",
                table: "Property",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Fields_FieldId",
                table: "Property",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "FieldId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
