using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticHub.Domain.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
