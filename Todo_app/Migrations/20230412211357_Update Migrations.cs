﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo_app.Migrations
{
    public partial class UpdateMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Todos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Todos");
        }
    }
}
