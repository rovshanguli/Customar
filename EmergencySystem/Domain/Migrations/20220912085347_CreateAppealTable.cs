using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    public partial class CreateAppealTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_CreatedByID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_CreatedForID",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "TicketTicketType");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CreatedByID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CreatedForID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "CreatedForID",
                table: "Tickets",
                newName: "Note");

            migrationBuilder.AddColumn<int>(
                name: "TicketTypeId",
                table: "Tickets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Appeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AudioUrl = table.Column<string>(type: "text", nullable: true),
                    VideoUrl = table.Column<string>(type: "text", nullable: true),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true),
                    TicketId = table.Column<int>(type: "integer", nullable: true),
                    CreatedByID = table.Column<string>(type: "text", nullable: true),
                    CreatedForID = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appeals_AspNetUsers_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appeals_AspNetUsers_CreatedForID",
                        column: x => x.CreatedForID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appeals_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_CreatedByID",
                table: "Appeals",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_CreatedForID",
                table: "Appeals",
                column: "CreatedForID");

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_TicketId",
                table: "Appeals",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId",
                principalTable: "TicketTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Appeals");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketTypeId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Tickets",
                newName: "CreatedForID");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "Tickets",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TicketTicketType",
                columns: table => new
                {
                    TicketTypeId = table.Column<int>(type: "integer", nullable: false),
                    TicketsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTicketType", x => new { x.TicketTypeId, x.TicketsId });
                    table.ForeignKey(
                        name: "FK_TicketTicketType_Tickets_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketTicketType_TicketTypes_TicketTypeId",
                        column: x => x.TicketTypeId,
                        principalTable: "TicketTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreatedByID",
                table: "Tickets",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreatedForID",
                table: "Tickets",
                column: "CreatedForID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTicketType_TicketsId",
                table: "TicketTicketType",
                column: "TicketsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_CreatedByID",
                table: "Tickets",
                column: "CreatedByID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_CreatedForID",
                table: "Tickets",
                column: "CreatedForID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
