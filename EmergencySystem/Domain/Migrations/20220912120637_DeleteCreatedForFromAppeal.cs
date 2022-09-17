using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class DeleteCreatedForFromAppeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appeals_AspNetUsers_CreatedForID",
                table: "Appeals");

            migrationBuilder.DropIndex(
                name: "IX_Appeals_CreatedForID",
                table: "Appeals");

            migrationBuilder.DropColumn(
                name: "CreatedForID",
                table: "Appeals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedForID",
                table: "Appeals",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_CreatedForID",
                table: "Appeals",
                column: "CreatedForID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_AspNetUsers_CreatedForID",
                table: "Appeals",
                column: "CreatedForID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
