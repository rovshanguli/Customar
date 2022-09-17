using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class RemoveTicketIdFromTicketStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatuses_Tickets_TicketId",
                table: "TicketStatuses");

            migrationBuilder.DropIndex(
                name: "IX_TicketStatuses_TicketId",
                table: "TicketStatuses");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "TicketStatuses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TicketId",
                table: "TicketStatuses",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatuses_TicketId",
                table: "TicketStatuses",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatuses_Tickets_TicketId",
                table: "TicketStatuses",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId");
        }
    }
}
