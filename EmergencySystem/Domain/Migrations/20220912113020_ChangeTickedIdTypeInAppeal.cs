using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class ChangeTickedIdTypeInAppeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appeals_Tickets_TicketId1",
                table: "Appeals");

            migrationBuilder.DropIndex(
                name: "IX_Appeals_TicketId1",
                table: "Appeals");

            migrationBuilder.DropColumn(
                name: "TicketId1",
                table: "Appeals");

            migrationBuilder.AlterColumn<string>(
                name: "TicketId",
                table: "Appeals",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_TicketId",
                table: "Appeals",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_Tickets_TicketId",
                table: "Appeals",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appeals_Tickets_TicketId",
                table: "Appeals");

            migrationBuilder.DropIndex(
                name: "IX_Appeals_TicketId",
                table: "Appeals");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "Appeals",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketId1",
                table: "Appeals",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_TicketId1",
                table: "Appeals",
                column: "TicketId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_Tickets_TicketId1",
                table: "Appeals",
                column: "TicketId1",
                principalTable: "Tickets",
                principalColumn: "TicketId");
        }
    }
}
