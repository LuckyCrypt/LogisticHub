﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticHub.Domain.Migrations
{
    /// <inheritdoc />
    public partial class updateAddPhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone",
                table: "Orders");
        }
    }
}
