using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizzardry.Migrations
{
    public partial class initial : Migration
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
                    Answer4 = table.Column<string>(nullable: false),
                    CorrectAnswer = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "ID", "Answer1", "Answer2", "Answer3", "Answer4", "CorrectAnswer", "Question" },
                values: new object[,]
                {
                    { 1, "Physicist Kenneth Bainbridge", "Actor Kenneth Branaugh", "Singer Kenneth \"Babyface\" Edmonds", "Nobody!", "d", "In REM's \"What's the Frequency, Kenneth\" who is the titular Kenneth?" },
                    { 2, "Quad City DJs", "C + C Music Factory", "Haddaway", "The Baha Men", "c", "The Euro-pop dance hit \"What is Love\" is probably still stuck in your head. Whose fault is that?" },
                    { 3, "The Ronnettes", "The Supremes", "The Byrds", "The Shirellas", "b", "Covered by Phil Collins in 1982, what group released \"You Can't Hurry Love\" in 1966?" },
                    { 4, "George Takei", "James Doohan", "DeForest Kelley", "Leonard Nemoy", "a", "Which Star Trek TOS cast member never appeared in an epsiode of Star Trek: TNG?" },
                    { 5, "The Space Needle", "The Statue of Liberty", "The Washington Monument", "The Gateway Arch", "d", "Which of the following structures is the tallest?" },
                    { 6, "Pong", "Space Invaders", "Computer Space", "Asteroids", "c", "What was the name of the first commercially released video game?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
