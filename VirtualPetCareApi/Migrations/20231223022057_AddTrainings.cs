using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualPetCareApi.Migrations
{
    public partial class AddTrainings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Trainings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_PetId",
                table: "Trainings",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Pets_PetId",
                table: "Trainings",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Pets_PetId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_PetId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Trainings");
        }
    }
}
