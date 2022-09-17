using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class AddUserFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoTranslates_Infos_InfoId",
                table: "InfoTranslates");

            migrationBuilder.AlterColumn<int>(
                name: "InfoId",
                table: "InfoTranslates",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoTranslates_Infos_InfoId",
                table: "InfoTranslates",
                column: "InfoId",
                principalTable: "Infos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoTranslates_Infos_InfoId",
                table: "InfoTranslates");

            migrationBuilder.AlterColumn<int>(
                name: "InfoId",
                table: "InfoTranslates",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoTranslates_Infos_InfoId",
                table: "InfoTranslates",
                column: "InfoId",
                principalTable: "Infos",
                principalColumn: "Id");
        }
    }
}
