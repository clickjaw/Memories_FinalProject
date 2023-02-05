using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Memories.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_FamilyMembers_FamilyMemberId",
                table: "Families");

            migrationBuilder.AlterColumn<int>(
                name: "FamilyMemberId",
                table: "Families",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Families_FamilyMembers_FamilyMemberId",
                table: "Families",
                column: "FamilyMemberId",
                principalTable: "FamilyMembers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_FamilyMembers_FamilyMemberId",
                table: "Families");

            migrationBuilder.AlterColumn<int>(
                name: "FamilyMemberId",
                table: "Families",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Families_FamilyMembers_FamilyMemberId",
                table: "Families",
                column: "FamilyMemberId",
                principalTable: "FamilyMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
