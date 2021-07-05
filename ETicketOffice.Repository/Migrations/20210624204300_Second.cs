using Microsoft.EntityFrameworkCore.Migrations;

namespace ETicketOffice.Repository.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketsInOrder",
                table: "TicketsInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketsInCart",
                table: "TicketsInCart");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "TicketsInOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketsInOrder",
                table: "TicketsInOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketsInCart",
                table: "TicketsInCart",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsInOrder_TicketId",
                table: "TicketsInOrder",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsInCart_TicketId",
                table: "TicketsInCart",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketsInOrder",
                table: "TicketsInOrder");

            migrationBuilder.DropIndex(
                name: "IX_TicketsInOrder_TicketId",
                table: "TicketsInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketsInCart",
                table: "TicketsInCart");

            migrationBuilder.DropIndex(
                name: "IX_TicketsInCart_TicketId",
                table: "TicketsInCart");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "TicketsInOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketsInOrder",
                table: "TicketsInOrder",
                columns: new[] { "TicketId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketsInCart",
                table: "TicketsInCart",
                columns: new[] { "TicketId", "CartId" });
        }
    }
}
