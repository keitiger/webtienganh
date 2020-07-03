using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHocTiengAnh.Migrations
{
    public partial class Kinit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "Answer1",
                table: "Exercises",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer2",
                table: "Exercises",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer3",
                table: "Exercises",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer1",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Answer2",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Answer3",
                table: "Exercises");

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ExerciseId",
                table: "Answers",
                column: "ExerciseId");
        }
    }
}
