﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_lab2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aktywnosc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    activity = table.Column<string>(type: "TEXT", nullable: false),
                    accessibility = table.Column<float>(type: "REAL", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    participants = table.Column<int>(type: "INTEGER", nullable: false),
                    price = table.Column<float>(type: "REAL", nullable: false),
                    link = table.Column<string>(type: "TEXT", nullable: false),
                    key = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aktywnosc", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aktywnosc");
        }
    }
}
