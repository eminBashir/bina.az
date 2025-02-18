using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcments_User_UserId",
                table: "Announcments");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorits_User_UserId",
                table: "Favorits");

            migrationBuilder.DropIndex(
                name: "IX_Favorits_UserId",
                table: "Favorits");

            migrationBuilder.DropIndex(
                name: "IX_Announcments_UserId",
                table: "Announcments");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Favorits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Favorits",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Announcments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Announcments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Favorits_UserId1",
                table: "Favorits",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Announcments_UserId1",
                table: "Announcments",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcments_User_UserId1",
                table: "Announcments",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorits_User_UserId1",
                table: "Favorits",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcments_User_UserId1",
                table: "Announcments");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorits_User_UserId1",
                table: "Favorits");

            migrationBuilder.DropIndex(
                name: "IX_Favorits_UserId1",
                table: "Favorits");

            migrationBuilder.DropIndex(
                name: "IX_Announcments_UserId1",
                table: "Announcments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Favorits");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Announcments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Favorits",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Announcments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Favorits_UserId",
                table: "Favorits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcments_UserId",
                table: "Announcments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcments_User_UserId",
                table: "Announcments",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorits_User_UserId",
                table: "Favorits",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
