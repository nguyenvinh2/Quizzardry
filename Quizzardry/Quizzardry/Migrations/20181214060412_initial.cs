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
                    { 28, "Komodo Dragons", "Dogs", "Snakes", "Cats", "d", "What is Amanda's favorite Animal?" },
                    { 27, "Encapsultion, Abstraction, Polymorphism, Inheritance", "Classes, Abstraction, Polymorphism, Inheritance", "Classes, Objects, Polymorphism, Inheritance", "There a only 3 OOP Principles", "a", "What are the four OOP Principles?" },
                    { 26, "An object is an instance of a class", "A class is an instance of an object", "How would I know?", "Ojbects can be overridden while classes cannot", "a", "What is the difference between an object and a class?" },
                    { 25, "2956 Third Age", "2951 Third Age", "3017 Third Age", "2980 Third Age", "a", "When did Gandalf meet Aragorn?" },
                    { 24, "Made the Trolls go away to get water", "Rushed in and killed all three trolls", "Made his voice like the trolls' voices, and made them argue until they turned to stone", "Called the wrath of the Valar on them", "c", "In The Hobbit, how did Gandalf save the Dwarves and Bilbo from the trolls?" },
                    { 23, "Vilya, the Ring of Air", "One Ring to Rule Them All", "Nenya, the Ring of Water", "Narya, the Ring of Fire", "d", "Which Ring did Cirdan give to Gandalf?" },
                    { 22, "1000 Third Age", "He was always there", "2000 Third Age", "1600 Second Age", "a", "When did Gandalf come to Middle-Earth?" },
                    { 21, "Curumo", "Olorin", "Alatar", "Pallando", "b", "What was Gandalf's name in the Silmarillion?" },
                    { 20, "2", "4", "5", "7", "c", "How many wizards were there in Middle-Earth?" },
                    { 19, "Eowyn", "Eaoden", "Aragorn", "Eomer", "d", "Who becomes king of Rohan after Theoden dies on Pelennor Fields?" },
                    { 18, "Gandalf the Grey", "Mithrandir", "The Grey Pilgrim", "Incanus", "b", "By what name do the Elves call Gandalf?" },
                    { 17, "The Hobbit by Bilbo Baggins", "A Hobbits Tale by Bilbo Baggins", "Into the West by Bilbo Baggins", "The Silmarillion by Bilbo Baggins", "b", "What is the name of the story Bilbo wrote about his adventures?" },
                    { 16, "Pack-12", "SEC", "Big 10", "ACC", "d", "Which conference includes the Duke Blue Devils?" },
                    { 15, "Hulk Hogan", "Andre the Giant", "Randy Savage", "Vince McMahon", "b", "Who was the first person inducted into the WWE Hall of Fame?" },
                    { 14, "Montreal Canadiens", "Green Bay Packers", "Boston Celtics", "New York Yankees", "d", "Which Big 4 team has the most championship wins with 27?" },
                    { 13, "Indiana Pacers", "Mulwaukee Bucks", "Houston Rockets", "New York Knicks", "a", "Which of these teams has never won a championship?" },
                    { 12, "Lou Gehrig", "Pete Rose", "Cal Ripken Jr.", "Stan Musial", "c", "Which player holds the record for most consecutive games played in the MLB?" },
                    { 11, "Bird", "Serpent", "Fish", "Dog", "b", "What type of creature is an Ashwinder?" },
                    { 10, "Fluxweed", "Newt spleen", "A bit of whoever you wish toturn into", "Knotgrass", "a", "Which Polyjuice Potion ingredient must be acquired at the full moon?" },
                    { 9, "Hufflepuff", "Gryffindor", "Slytherin", "Ravenclaw", "d", "Which Hogwarts house is Terry Boot a member of?" },
                    { 8, "Liquorice Wand", "Sherbert Lemon", "Fizzing Whizzbee", "Cockroach Cluster", "a", "Which is not a password to get into Dumbledor's Office?" },
                    { 7, "Fourteen", "Fifteen", "Two hundred and sixty seven", "Sixteen", "b", "How many broomsticks are flown in a full game of Quidditch?" },
                    { 6, "Pong", "Space Invaders", "Computer Space", "Asteroids", "c", "What was the name of the first commercially released video game?" },
                    { 5, "The Space Needle", "The Statue of Liberty", "The Washington Monument", "The Gateway Arch", "d", "Which of the following structures is the tallest?" },
                    { 4, "George Takei", "James Doohan", "DeForest Kelley", "Leonard Nemoy", "a", "Which Star Trek TOS cast member never appeared in an epsiode of Star Trek: TNG?" },
                    { 3, "The Ronnettes", "The Supremes", "The Byrds", "The Shirellas", "b", "Covered by Phil Collins in 1982, what group released \"You Can't Hurry Love\" in 1966?" },
                    { 2, "Quad City DJs", "C + C Music Factory", "Haddaway", "The Baha Men", "c", "The Euro-pop dance hit \"What is Love\" is probably still stuck in your head. Whose fault is that?" },
                    { 29, "Komodo Dragons", "Dogs", "Snakes", "Cats", "d", "What is Amanda's favorite Animal?" },
                    { 30, "Amazon", "Alphabet", "Microsoft", "Apple", "c", "What is the most valueable company right now?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
