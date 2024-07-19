using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SkillType_Services : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the existing CreatedBy column
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Services");

            // Recreate the CreatedBy column with the correct data type
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SkillTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTypes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillTypes");

            // Drop the CreatedBy column with int type
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Services");

            // Recreate the CreatedBy column with the old datetime type
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedBy",
                table: "Services",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()"); // You may set a default value or adjust as necessary
        }
    }
}
