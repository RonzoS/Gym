using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymWeb.Migrations
{
    public partial class workingManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTool_Exercise_ExercisesId",
                table: "ExerciseTool");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTool_Tool_ToolsId",
                table: "ExerciseTool");

            migrationBuilder.DropTable(
                name: "ExerciseSetRepeat");

            migrationBuilder.RenameColumn(
                name: "ToolsId",
                table: "ExerciseTool",
                newName: "ToolId");

            migrationBuilder.RenameColumn(
                name: "ExercisesId",
                table: "ExerciseTool",
                newName: "ExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseTool_ToolsId",
                table: "ExerciseTool",
                newName: "IX_ExerciseTool_ToolId");

            migrationBuilder.CreateTable(
                name: "RepeatExercise",
                columns: table => new
                {
                    ExerciseSetId = table.Column<int>(type: "int", nullable: false),
                    RepeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepeatExercise", x => new { x.ExerciseSetId, x.RepeatId });
                    table.ForeignKey(
                        name: "FK_RepeatExercise_ExerciseSet_ExerciseSetId",
                        column: x => x.ExerciseSetId,
                        principalTable: "ExerciseSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepeatExercise_Repeat_RepeatId",
                        column: x => x.RepeatId,
                        principalTable: "Repeat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepeatExercise_RepeatId",
                table: "RepeatExercise",
                column: "RepeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTool_Exercise_ExerciseId",
                table: "ExerciseTool",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTool_Tool_ToolId",
                table: "ExerciseTool",
                column: "ToolId",
                principalTable: "Tool",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTool_Exercise_ExerciseId",
                table: "ExerciseTool");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTool_Tool_ToolId",
                table: "ExerciseTool");

            migrationBuilder.DropTable(
                name: "RepeatExercise");

            migrationBuilder.RenameColumn(
                name: "ToolId",
                table: "ExerciseTool",
                newName: "ToolsId");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "ExerciseTool",
                newName: "ExercisesId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseTool_ToolId",
                table: "ExerciseTool",
                newName: "IX_ExerciseTool_ToolsId");

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
                name: "IX_ExerciseSetRepeat_RepeatId",
                table: "ExerciseSetRepeat",
                column: "RepeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTool_Exercise_ExercisesId",
                table: "ExerciseTool",
                column: "ExercisesId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTool_Tool_ToolsId",
                table: "ExerciseTool",
                column: "ToolsId",
                principalTable: "Tool",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
