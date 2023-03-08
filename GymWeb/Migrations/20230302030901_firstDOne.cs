using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymWeb.Migrations
{
    public partial class firstDOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repeat_ExerciseSet_ExerciseSetId",
                table: "Repeat");

            migrationBuilder.DropTable(
                name: "ExerciseExerciseSet");

            migrationBuilder.DropIndex(
                name: "IX_Repeat_ExerciseSetId",
                table: "Repeat");

            migrationBuilder.DropColumn(
                name: "ExerciseSetId",
                table: "Repeat");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Repeat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "ExerciseSet",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ExerciseSetRepeat",
                columns: table => new
                {
                    ExerciseSetsId = table.Column<int>(type: "int", nullable: false),
                    RepeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSetRepeat", x => new { x.ExerciseSetsId, x.RepeatId });
                    table.ForeignKey(
                        name: "FK_ExerciseSetRepeat_ExerciseSet_ExerciseSetsId",
                        column: x => x.ExerciseSetsId,
                        principalTable: "ExerciseSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseSetRepeat_Repeat_RepeatId",
                        column: x => x.RepeatId,
                        principalTable: "Repeat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repeat_ExerciseId",
                table: "Repeat",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSetRepeat_RepeatId",
                table: "ExerciseSetRepeat",
                column: "RepeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repeat_Exercise_ExerciseId",
                table: "Repeat",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repeat_Exercise_ExerciseId",
                table: "Repeat");

            migrationBuilder.DropTable(
                name: "ExerciseSetRepeat");

            migrationBuilder.DropIndex(
                name: "IX_Repeat_ExerciseId",
                table: "Repeat");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Repeat");

            migrationBuilder.DropColumn(
                name: "Done",
                table: "ExerciseSet");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseSetId",
                table: "Repeat",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExerciseExerciseSet",
                columns: table => new
                {
                    ExerciseSetsId = table.Column<int>(type: "int", nullable: false),
                    ExercisesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseExerciseSet", x => new { x.ExerciseSetsId, x.ExercisesId });
                    table.ForeignKey(
                        name: "FK_ExerciseExerciseSet_Exercise_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseExerciseSet_ExerciseSet_ExerciseSetsId",
                        column: x => x.ExerciseSetsId,
                        principalTable: "ExerciseSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repeat_ExerciseSetId",
                table: "Repeat",
                column: "ExerciseSetId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseExerciseSet_ExercisesId",
                table: "ExerciseExerciseSet",
                column: "ExercisesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repeat_ExerciseSet_ExerciseSetId",
                table: "Repeat",
                column: "ExerciseSetId",
                principalTable: "ExerciseSet",
                principalColumn: "Id");
        }
    }
}
