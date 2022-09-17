using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class ChangeAppealModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppealTypeTranslates_AppealTypes_AppealTypeId",
                table: "AppealTypeTranslates");

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

            migrationBuilder.CreateTable(
                name: "AppealAppealType",
                columns: table => new
                {
                    AppealTypesId = table.Column<int>(type: "integer", nullable: false),
                    AppealsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppealAppealType", x => new { x.AppealTypesId, x.AppealsId });
                    table.ForeignKey(
                        name: "FK_AppealAppealType_Appeals_AppealsId",
                        column: x => x.AppealsId,
                        principalTable: "Appeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppealAppealType_AppealTypes_AppealTypesId",
                        column: x => x.AppealTypesId,
                        principalTable: "AppealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppealAppealType_AppealsId",
                table: "AppealAppealType",
                column: "AppealsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppealTypeTranslates_AppealTypes_AppealTypeId",
                table: "AppealTypeTranslates",
                column: "AppealTypeId",
                principalTable: "AppealTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppealTypeTranslates_AppealTypes_AppealTypeId",
                table: "AppealTypeTranslates");

            migrationBuilder.DropTable(
                name: "AppealAppealType");

            migrationBuilder.DropColumn(
                name: "AppealId",
                table: "AppealTypeTranslates");

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
    }
}
