using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MedHelp.Migrations
{
    public partial class ModelAndSchemeForTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModelJson",
                table: "Templates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchemeJson",
                table: "Templates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelJson",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "SchemeJson",
                table: "Templates");
        }
    }
}
