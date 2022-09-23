using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class AddColorToTicketStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppealTypeTranslates_AppealTypes_AppealTypeId",
                table: "AppealTypeTranslates");

            migrationBuilder.DropColumn(
                name: "AppealId",
                table: "AppealTypeTranslates");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "TicketStatuses",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppealTypeId",
                table: "AppealTypeTranslates",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppealTypeTranslates_AppealTypes_AppealTypeId",
                table: "AppealTypeTranslates",
                column: "AppealTypeId",
                principalTable: "AppealTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppealTypeTranslates_AppealTypes_AppealTypeId",
                table: "AppealTypeTranslates");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "TicketStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "AppealTypeId",
                table: "AppealTypeTranslates",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "AppealId",
                table: "AppealTypeTranslates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AppealTypeTranslates_AppealTypes_AppealTypeId",
                table: "AppealTypeTranslates",
                column: "AppealTypeId",
                principalTable: "AppealTypes",
                principalColumn: "Id");
        }
    }
}
