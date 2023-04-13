using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo_app.Migrations
{
    // Third migration (CompletedDate)
    public partial class ThirdMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedDate",
                table: "Todos",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedDate",
                table: "Todos");
        }
    }
}
