﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quizzardry.Data;

namespace Quizzardry.Migrations
{
    [DbContext(typeof(QuestionsDbContext))]
    partial class QuestionsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Quizzardry.Models.Questions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer1")
                        .IsRequired();

                    b.Property<string>("Answer2")
                        .IsRequired();

                    b.Property<string>("Answer3")
                        .IsRequired();

                    b.Property<string>("Answer4")
                        .IsRequired();

                    b.Property<string>("CorrectAnswer")
                        .IsRequired();

                    b.Property<string>("Question")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Questions");

                    b.HasData(
                        new { ID = 1, Answer1 = "Physicist Kenneth Bainbridge", Answer2 = "Actor Kenneth Branaugh", Answer3 = "Singer Kenneth \"Babyface\" Edmonds", Answer4 = "Nobody!", CorrectAnswer = "d", Question = "In REM's \"What's the Frequency, Kenneth\" who is the titular Kenneth?" },
                        new { ID = 2, Answer1 = "Quad City DJs", Answer2 = "C + C Music Factory", Answer3 = "Haddaway", Answer4 = "The Baha Men", CorrectAnswer = "c", Question = "The Euro-pop dance hit \"What is Love\" is probably still stuck in your head. Whose fault is that?" },
                        new { ID = 3, Answer1 = "The Ronnettes", Answer2 = "The Supremes", Answer3 = "The Byrds", Answer4 = "The Shirellas", CorrectAnswer = "b", Question = "Covered by Phil Collins in 1982, what group released \"You Can't Hurry Love\" in 1966?" },
                        new { ID = 4, Answer1 = "George Takei", Answer2 = "James Doohan", Answer3 = "DeForest Kelley", Answer4 = "Leonard Nemoy", CorrectAnswer = "a", Question = "Which Star Trek TOS cast member never appeared in an epsiode of Star Trek: TNG?" },
                        new { ID = 5, Answer1 = "The Space Needle", Answer2 = "The Statue of Liberty", Answer3 = "The Washington Monument", Answer4 = "The Gateway Arch", CorrectAnswer = "d", Question = "Which of the following structures is the tallest?" },
                        new { ID = 6, Answer1 = "Pong", Answer2 = "Space Invaders", Answer3 = "Computer Space", Answer4 = "Asteroids", CorrectAnswer = "c", Question = "What was the name of the first commercially released video game?" },
                        new { ID = 7, Answer1 = "Fourteen", Answer2 = "Fifteen", Answer3 = "Two hundred and sixty seven", Answer4 = "Sixteen", CorrectAnswer = "b", Question = "How many broomsticks are flown in a full game of Quidditch?" },
                        new { ID = 8, Answer1 = "Liquorice Wand", Answer2 = "Sherbert Lemon", Answer3 = "Fizzing Whizzbee", Answer4 = "Cockroach Cluster", CorrectAnswer = "a", Question = "Which is not a password to get into Dumbledor's Office?" },
                        new { ID = 9, Answer1 = "Hufflepuff", Answer2 = "Gryffindor", Answer3 = "Slytherin", Answer4 = "Ravenclaw", CorrectAnswer = "d", Question = "Which Hogwarts house is Terry Boot a member of?" },
                        new { ID = 10, Answer1 = "Fluxweed", Answer2 = "Newt spleen", Answer3 = "A bit of whoever you wish toturn into", Answer4 = "Knotgrass", CorrectAnswer = "a", Question = "Which Polyjuice Potion ingredient must be acquired at the full moon?" },
                        new { ID = 11, Answer1 = "Bird", Answer2 = "Serpent", Answer3 = "Fish", Answer4 = "Dog", CorrectAnswer = "b", Question = "What type of creature is an Ashwinder?" },
                        new { ID = 12, Answer1 = "Lou Gehrig", Answer2 = "Pete Rose", Answer3 = "Cal Ripken Jr.", Answer4 = "Stan Musial", CorrectAnswer = "c", Question = "Which player holds the record for most consecutive games played in the MLB?" },
                        new { ID = 13, Answer1 = "Indiana Pacers", Answer2 = "Mulwaukee Bucks", Answer3 = "Houston Rockets", Answer4 = "New York Knicks", CorrectAnswer = "a", Question = "Which of these teams has never won a championship?" },
                        new { ID = 14, Answer1 = "Montreal Canadiens", Answer2 = "Green Bay Packers", Answer3 = "Boston Celtics", Answer4 = "New York Yankees", CorrectAnswer = "d", Question = "Which Big 4 team has the most championship wins with 27?" },
                        new { ID = 15, Answer1 = "Hulk Hogan", Answer2 = "Andre the Giant", Answer3 = "Randy Savage", Answer4 = "Vince McMahon", CorrectAnswer = "b", Question = "Who was the first person inducted into the WWE Hall of Fame?" },
                        new { ID = 16, Answer1 = "Pack-12", Answer2 = "SEC", Answer3 = "Big 10", Answer4 = "ACC", CorrectAnswer = "d", Question = "Which conference includes the Duke Blue Devils?" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
