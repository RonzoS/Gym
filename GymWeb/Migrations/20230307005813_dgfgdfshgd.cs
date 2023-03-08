using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymWeb.Migrations
{
    public partial class dgfgdfshgd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscle_Exercise_ExercisesId",
                table: "ExerciseMuscle");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscle_Muscle_MusclesId",
                table: "ExerciseMuscle");

            migrationBuilder.RenameColumn(
                name: "MusclesId",
                table: "ExerciseMuscle",
                newName: "MuscleId");

            migrationBuilder.RenameColumn(
                name: "ExercisesId",
                table: "ExerciseMuscle",
                newName: "ExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseMuscle_MusclesId",
                table: "ExerciseMuscle",
                newName: "IX_ExerciseMuscle_MuscleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscle_Exercise_ExerciseId",
                table: "ExerciseMuscle",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscle_Muscle_MuscleId",
                table: "ExerciseMuscle",
                column: "MuscleId",
                principalTable: "Muscle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscle_Exercise_ExerciseId",
                table: "ExerciseMuscle");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscle_Muscle_MuscleId",
                table: "ExerciseMuscle");

            migrationBuilder.RenameColumn(
                name: "MuscleId",
                table: "ExerciseMuscle",
                newName: "MusclesId");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "ExerciseMuscle",
                newName: "ExercisesId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseMuscle_MuscleId",
                table: "ExerciseMuscle",
                newName: "IX_ExerciseMuscle_MusclesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscle_Exercise_ExercisesId",
                table: "ExerciseMuscle",
                column: "ExercisesId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscle_Muscle_MusclesId",
                table: "ExerciseMuscle",
                column: "MusclesId",
                principalTable: "Muscle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
