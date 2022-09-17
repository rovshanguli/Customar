using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    public partial class AddPrimaryKeyToAppealTypeTranslate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioUrl",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Appeals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CreatedTicket",
                table: "Appeals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Lat",
                table: "Appeals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Long",
                table: "Appeals",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppealTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppealTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppealTypeTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LangCode = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AppealTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppealTypeTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppealTypeTranslates_AppealTypes_AppealTypeId",
                        column: x => x.AppealTypeId,
                        principalTable: "AppealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppealTypeTranslates_AppealTypeId",
                table: "AppealTypeTranslates",
                column: "AppealTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppealTypeTranslates");

            migrationBuilder.DropTable(
                name: "AppealTypes");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Appeals");

            migrationBuilder.DropColumn(
                name: "CreatedTicket",
                table: "Appeals");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Appeals");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "Appeals");

            migrationBuilder.AddColumn<string>(
                name: "AudioUrl",
                table: "Tickets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Tickets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Tickets",
                type: "text",
                nullable: true);
        }
    }
}
