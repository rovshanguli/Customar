using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class ChangeTicketIdTypeInTicketStatusHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatusHistories_Tickets_TicketId1",
                table: "TicketStatusHistories");

            migrationBuilder.DropIndex(
                name: "IX_TicketStatusHistories_TicketId1",
                table: "TicketStatusHistories");

            migrationBuilder.DropColumn(
                name: "TicketId1",
                table: "TicketStatusHistories");

            migrationBuilder.AlterColumn<string>(
                name: "TicketId",
                table: "TicketStatusHistories",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatusHistories_TicketId",
                table: "TicketStatusHistories",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatusHistories_Tickets_TicketId",
                table: "TicketStatusHistories",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatusHistories_Tickets_TicketId",
                table: "TicketStatusHistories");

            migrationBuilder.DropIndex(
                name: "IX_TicketStatusHistories_TicketId",
                table: "TicketStatusHistories");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "TicketStatusHistories",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketId1",
                table: "TicketStatusHistories",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatusHistories_TicketId1",
                table: "TicketStatusHistories",
                column: "TicketId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatusHistories_Tickets_TicketId1",
                table: "TicketStatusHistories",
                column: "TicketId1",
                principalTable: "Tickets",
                principalColumn: "TicketId");
        }
    }
}
