using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LogisticHub.Domain.Migrations
{
    /// <inheritdoc />
    public partial class update_deleteUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "SenderSreet",
                table: "Orders",
                newName: "PickupSreet");

            migrationBuilder.RenameColumn(
                name: "SenderCity",
                table: "Orders",
                newName: "PickupCity");

            migrationBuilder.RenameColumn(
                name: "RecipientСity",
                table: "Orders",
                newName: "DeliveryStreet");

            migrationBuilder.RenameColumn(
                name: "RecipientStreet",
                table: "Orders",
                newName: "DeliveryCity");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PickupSreet",
                table: "Orders",
                newName: "SenderSreet");

            migrationBuilder.RenameColumn(
                name: "PickupCity",
                table: "Orders",
                newName: "SenderCity");

            migrationBuilder.RenameColumn(
                name: "DeliveryStreet",
                table: "Orders",
                newName: "RecipientСity");

            migrationBuilder.RenameColumn(
                name: "DeliveryCity",
                table: "Orders",
                newName: "RecipientStreet");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserID",
                table: "Orders",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
