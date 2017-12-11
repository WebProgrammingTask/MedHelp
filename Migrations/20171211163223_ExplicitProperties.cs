using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MedHelp.Migrations
{
    public partial class ExplicitProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldType",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "Placeholder",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "RemainingProperties",
                table: "Fields");

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FieldId = table.Column<int>(nullable: true),
                    PropertyName = table.Column<string>(nullable: true),
                    PropertyValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Property_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "FieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Property_FieldId",
                table: "Property",
                column: "FieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.AddColumn<string>(
                name: "FieldType",
                table: "Fields",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Fields",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Fields",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Placeholder",
                table: "Fields",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemainingProperties",
                table: "Fields",
                nullable: true);
        }
    }
}
