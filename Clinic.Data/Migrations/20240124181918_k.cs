using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Data.Migrations
{
    public partial class k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Babys_BabyId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_BabyId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "BabyId",
                table: "Appointments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BabyId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BabyId",
                table: "Appointments",
                column: "BabyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Babys_BabyId",
                table: "Appointments",
                column: "BabyId",
                principalTable: "Babys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
