using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Memories.Migrations
{
    public partial class SeedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Families",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Families_AddressId",
                table: "Families",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Families_Addresses_AddressId",
                table: "Families",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_Addresses_AddressId",
                table: "Families");

            migrationBuilder.DropIndex(
                name: "IX_Families_AddressId",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Families");
        }
    }
}
