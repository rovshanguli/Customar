using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    public partial class ChangeTicketId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appeals_Tickets_TicketId",
                table: "Appeals");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatuses_Tickets_TicketId",
                table: "TicketStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatusHistories_Tickets_TicketId",
                table: "TicketStatusHistories");

            migrationBuilder.DropIndex(
                name: "IX_TicketStatusHistories_TicketId",
                table: "TicketStatusHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Appeals_TicketId",
                table: "Appeals");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "TicketId1",
                table: "TicketStatusHistories",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TicketId",
                table: "TicketStatuses",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketId",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TicketId1",
                table: "Appeals",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatusHistories_TicketId1",
                table: "TicketStatusHistories",
                column: "TicketId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatuses_Tickets_TicketId",
                table: "TicketStatuses",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatusHistories_Tickets_TicketId1",
                table: "TicketStatusHistories",
                column: "TicketId1",
                principalTable: "Tickets",
                principalColumn: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appeals_Tickets_TicketId1",
                table: "Appeals");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatuses_Tickets_TicketId",
                table: "TicketStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatusHistories_Tickets_TicketId1",
                table: "TicketStatusHistories");

            migrationBuilder.DropIndex(
                name: "IX_TicketStatusHistories_TicketId1",
                table: "TicketStatusHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Appeals_TicketId1",
                table: "Appeals");

            migrationBuilder.DropColumn(
                name: "TicketId1",
                table: "TicketStatusHistories");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketId1",
                table: "Appeals");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "TicketStatuses",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatusHistories_TicketId",
                table: "TicketStatusHistories",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_TicketId",
                table: "Appeals",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_Tickets_TicketId",
                table: "Appeals",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatuses_Tickets_TicketId",
                table: "TicketStatuses",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatusHistories_Tickets_TicketId",
                table: "TicketStatusHistories",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
