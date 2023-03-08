using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymWeb.Migrations
{
    public partial class AddESummaryRepeatESetToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSet", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Repeat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstRepeats = table.Column<int>(type: "int", nullable: false),
                    FirstWeight = table.Column<float>(type: "real", nullable: false),
                    SecoundRepeats = table.Column<int>(type: "int", nullable: false),
                    SecoundWeight = table.Column<float>(type: "real", nullable: false),
                    ThirdRepeats = table.Column<int>(type: "int", nullable: false),
                    ThirdWeight = table.Column<float>(type: "real", nullable: false),
                    FourthRepeats = table.Column<int>(type: "int", nullable: false),
                    FourthWeight = table.Column<float>(type: "real", nullable: false),
                    ExerciseSetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repeat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repeat_ExerciseSet_ExerciseSetId",
                        column: x => x.ExerciseSetId,
                        principalTable: "ExerciseSet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseExerciseSet_ExercisesId",
                table: "ExerciseExerciseSet",
                column: "ExercisesId");

            migrationBuilder.CreateIndex(
                name: "IX_Repeat_ExerciseSetId",
                table: "Repeat",
                column: "ExerciseSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseExerciseSet");

            migrationBuilder.DropTable(
                name: "Repeat");

            migrationBuilder.DropTable(
                name: "ExerciseSet");
        }
    }
}
