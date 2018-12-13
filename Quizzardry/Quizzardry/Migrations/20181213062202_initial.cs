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
                    { 1, "Physicist Kenneth Bainbridge", "Actor Kenneth Branaugh", "Singer Kenneth \"Babyface\" Edmonds", "Who Cares", "Nobody!", "In REM's \"What's the Frequency, Kenneth\" who is the titular Kenneth?" },
                    { 2, "Quad City DJs", "C + C Music Factory", "The Baha Men", "Who Cares", "Haddaway", "The Euro-pop dance hit \"What is Love\" is probably still stuck in your head. Whose fault is that?" },
                    { 3, "The Ronnettes", "The Shirellas", "The Byrds", "Who Cares", "The Supremes", "Covered by Phil Collins in 1982, what group released \"You Can't Hurry Love\" in 1966?" },
                    { 4, "Leonard Nemoy", "James Doohan", "DeForest Kelley", "Who Cares", "George Takei", "Which Star Trek TOS cast member never appeared in an epsiode of Star Trek: TNG?" },
                    { 5, "The Space Needle", "The Statue of Liberty", "The Washington Monument", "Who Cares", "The Gateway Arch", "Which of the following structures is the tallest?" },
                    { 6, "Pong", "Space Invaders", "Asteroids", "Who Cares", "Computer Space", "What was the name of the first commercially released video game?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
