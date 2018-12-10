using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizzardry.Migrations
{
    public partial class initialQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(nullable: false),
                    Answer1 = table.Column<string>(nullable: false),
                    Answer2 = table.Column<string>(nullable: false),
                    Answer3 = table.Column<string>(nullable: false),
                    CorrectAnswer = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "ID", "Answer1", "Answer2", "Answer3", "CorrectAnswer", "Question" },
                values: new object[] { 1, "REM", "Drake", "Busta Rhymes", "Taylor Swift", "Who is Neth's favorite artist?" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "ID", "Answer1", "Answer2", "Answer3", "CorrectAnswer", "Question" },
                values: new object[] { 2, "Suzy", "Amanda", "Kendra", "TRE", "Who is Vinh's favorite person?" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
