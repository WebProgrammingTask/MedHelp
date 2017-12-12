using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MedHelp.Migrations
{
    public partial class ReferenceFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Templates_FormModelId",
                table: "Templates");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_FormModelId",
                table: "Templates",
                column: "FormModelId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Templates_FormModelId",
                table: "Templates");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_FormModelId",
                table: "Templates",
                column: "FormModelId");
        }
    }
}
