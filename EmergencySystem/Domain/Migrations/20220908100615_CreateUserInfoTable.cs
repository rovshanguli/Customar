using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class CreateUserInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserDataFIN",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    FIN = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    Photo = table.Column<byte[]>(type: "bytea", nullable: true),
                    BloodType = table.Column<string>(type: "text", nullable: true),
                    Eyecolor = table.Column<string>(type: "text", nullable: true),
                    SosialStatus = table.Column<string>(type: "text", nullable: true),
                    Policedept = table.Column<string>(type: "text", nullable: true),
                    Series = table.Column<string>(type: "text", nullable: true),
                    Seria = table.Column<string>(type: "text", nullable: true),
                    IssueDate = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.FIN);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserDataFIN",
                table: "AspNetUsers",
                column: "UserDataFIN");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserData_UserDataFIN",
                table: "AspNetUsers",
                column: "UserDataFIN",
                principalTable: "UserData",
                principalColumn: "FIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserData_UserDataFIN",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserData");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserDataFIN",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserDataFIN",
                table: "AspNetUsers");
        }
    }
}
