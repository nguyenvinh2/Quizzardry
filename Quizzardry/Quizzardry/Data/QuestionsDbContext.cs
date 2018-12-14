using Microsoft.EntityFrameworkCore;
using Quizzardry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzardry.Data
{
    public class QuestionsDbContext : DbContext
    {
        public QuestionsDbContext(DbContextOptions<QuestionsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Questions>().HasData(
                new Questions
                {
                    ID = 1,
                    Question = "In REM's \"What's the Frequency, Kenneth\" who is the titular Kenneth?",
                    Answer1 = "Physicist Kenneth Bainbridge",
                    Answer2 = "Actor Kenneth Branaugh",
                    Answer3 = "Singer Kenneth \"Babyface\" Edmonds",
                    Answer4 = "Nobody!",
                    CorrectAnswer = "d"
                },
                new Questions
                {
                    ID = 2,
                    Question = "The Euro-pop dance hit \"What is Love\" is probably still stuck in your head. Whose fault is that?",
                    Answer1 = "Quad City DJs",
                    Answer2 = "C + C Music Factory",
                    Answer3 = "Haddaway",
                    Answer4 = "The Baha Men",
                    CorrectAnswer = "c"
                },
                new Questions
                {
                    ID = 3,
                    Question = "Covered by Phil Collins in 1982, what group released \"You Can\'t Hurry Love\" in 1966?",
                    Answer1 = "The Ronnettes",
                    Answer2 = "The Supremes",
                    Answer3 = "The Byrds",
                    Answer4 = "The Shirellas",
                    CorrectAnswer = "b"
                },
                new Questions
                {
                    ID = 4,
                    Question = "Which Star Trek TOS cast member never appeared in an epsiode of Star Trek: TNG?",
                    Answer1 = "George Takei",
                    Answer2 = "James Doohan",
                    Answer3 = "DeForest Kelley",
                    Answer4 = "Leonard Nemoy",
                    CorrectAnswer = "a"
                },
                new Questions
                {
                    ID = 5,
                    Question = "Which of the following structures is the tallest?",
                    Answer1 = "The Space Needle",
                    Answer2 = "The Statue of Liberty",
                    Answer3 = "The Washington Monument",
                    Answer4 = "The Gateway Arch",
                    CorrectAnswer = "d"
                },
                new Questions
                {
                    ID = 6,
                    Question = "What was the name of the first commercially released video game?",
                    Answer1 = "Pong",
                    Answer2 = "Space Invaders",
                    Answer3 = "Computer Space",
                    Answer4 = "Asteroids",
                    CorrectAnswer = "c"
                },
                new Questions
                {
                    ID = 7,
                    Question = "How many broomsticks are flown in a full game of Quidditch?",
                    Answer1 = "Fourteen",
                    Answer2 = "Fifteen",
                    Answer3 = "Two hundred and sixty seven",
                    Answer4 = "Sixteen",
                    CorrectAnswer = "b"
                },
                new Questions
                {
                    ID = 8,
                    Question = "Which is not a password to get into Dumbledor's Office?",
                    Answer1 = "Liquorice Wand",
                    Answer2 = "Sherbert Lemon",
                    Answer3 = "Fizzing Whizzbee",
                    Answer4 = "Cockroach Cluster",
                    CorrectAnswer = "a"
                },
                new Questions
                {
                    ID = 9,
                    Question = "Which Hogwarts house is Terry Boot a member of?",
                    Answer1 = "Hufflepuff",
                    Answer2 = "Gryffindor",
                    Answer3 = "Slytherin",
                    Answer4 = "Ravenclaw",
                    CorrectAnswer = "d"
                },
                new Questions
                {
                    ID = 10,
                    Question = "Which Polyjuice Potion ingredient must be acquired at the full moon?",
                    Answer1 = "Fluxweed",
                    Answer2 = "Newt spleen",
                    Answer3 = "A bit of whoever you wish toturn into",
                    Answer4 = "Knotgrass",
                    CorrectAnswer = "a"
                },
                new Questions
                {
                    ID = 11,
                    Question = "What type of creature is an Ashwinder?",
                    Answer1 = "Bird",
                    Answer2 = "Serpent",
                    Answer3 = "Fish",
                    Answer4 = "Dog",
                    CorrectAnswer = "b"
                },
                new Questions
                {
                    ID = 12,
                    Question = "Which player holds the record for most consecutive games played in the MLB?",
                    Answer1 = "Lou Gehrig",
                    Answer2 = "Pete Rose",
                    Answer3 = "Cal Ripken Jr.",
                    Answer4 = "Stan Musial",
                    CorrectAnswer = "c"
                },
                new Questions
                {
                    ID = 13,
                    Question = "Which of these teams has never won a championship?",
                    Answer1 = "Indiana Pacers",
                    Answer2 = "Mulwaukee Bucks",
                    Answer3 = "Houston Rockets",
                    Answer4 = "New York Knicks",
                    CorrectAnswer = "a"
                },
                new Questions
                {
                    ID = 14,
                    Question = "Which Big 4 team has the most championship wins with 27?",
                    Answer1 = "Montreal Canadiens",
                    Answer2 = "Green Bay Packers",
                    Answer3 = "Boston Celtics",
                    Answer4 = "New York Yankees",
                    CorrectAnswer = "d"
                },
                new Questions
                {
                    ID = 15,
                    Question = "Who was the first person inducted into the WWE Hall of Fame?",
                    Answer1 = "Hulk Hogan",
                    Answer2 = "Andre the Giant",
                    Answer3 = "Randy Savage",
                    Answer4 = "Vince McMahon",
                    CorrectAnswer = "b"
                },
                new Questions
                {
                    ID = 16,
                    Question = "Which conference includes the Duke Blue Devils?",
                    Answer1 = "Pack-12",
                    Answer2 = "SEC",
                    Answer3 = "Big 10",
                    Answer4 = "ACC",
                    CorrectAnswer = "d"
                },

                new Questions
                {
                    ID = 17,
                    Question = "What is the name of the story Bilbo wrote about his adventures?",
                    Answer1 = "The Hobbit by Bilbo Baggins",
                    Answer2 = "A Hobbits Tale by Bilbo Baggins",
                    Answer3 = "Into the West by Bilbo Baggins",
                    Answer4 = "The Silmarillion by Bilbo Baggins",
                    CorrectAnswer = "b"
                },
                new Questions
                {
                    ID = 18,
                    Question = "By what name do the Elves call Gandalf?",
                    Answer1 = "Gandalf the Grey",
                    Answer2 = "Mithrandir",
                    Answer3 = "The Grey Pilgrim",
                    Answer4 = "Incanus",
                    CorrectAnswer = "b"
                },
                new Questions
                {
                    ID = 19,
                    Question = "Who becomes king of Rohan after Theoden dies on Pelennor Fields?",
                    Answer1 = "Eowyn",
                    Answer2 = "Eaoden",
                    Answer3 = "Aragorn",
                    Answer4 = "Eomer",
                    CorrectAnswer = "d"
                },
                new Questions
                {
                    ID = 20,
                    Question = "How many wizards were there in Middle-Earth?",
                    Answer1 = "2",
                    Answer2 = "4",
                    Answer3 = "5",
                    Answer4 = "7",
                    CorrectAnswer = "c"
                },
                new Questions
                {
                    ID = 21,
                    Question = "What was Gandalf's name in the Silmarillion?",
                    Answer1 = "Curumo",
                    Answer2 = "Olorin",
                    Answer3 = "Alatar",
                    Answer4 = "Pallando",
                    CorrectAnswer = "b"
                },
                new Questions
                {
                    ID = 22,
                    Question = "When did Gandalf come to Middle-Earth?",
                    Answer1 = "1000 Third Age",
                    Answer2 = "He was always there",
                    Answer3 = "2000 Third Age",
                    Answer4 = "1600 Second Age",
                    CorrectAnswer = "a"
                },
                new Questions
                {
                    ID = 23,
                    Question = "Which Ring did Cirdan give to Gandalf?",
                    Answer1 = "Vilya, the Ring of Air",
                    Answer2 = "One Ring to Rule Them All",
                    Answer3 = "Nenya, the Ring of Water",
                    Answer4 = "Narya, the Ring of Fire",
                    CorrectAnswer = "d"
                },
                new Questions
                {
                    ID = 24,
                    Question = "In The Hobbit, how did Gandalf save the Dwarves and Bilbo from the trolls?",
                    Answer1 = "Made the Trolls go away to get water",
                    Answer2 = "Rushed in and killed all three trolls",
                    Answer3 = "Made his voice like the trolls' voices, and made them argue until they turned to stone",
                    Answer4 = "Called the wrath of the Valar on them",
                    CorrectAnswer = "c"
                },
                new Questions
                {
                    ID = 25,
                    Question = "When did Gandalf meet Aragorn?",
                    Answer1 = "2956 Third Age",
                    Answer2 = "2951 Third Age",
                    Answer3 = "3017 Third Age",
                    Answer4 = "2980 Third Age",
                    CorrectAnswer = "a"
                },
                new Questions
                {
                    ID = 26,
                    Question = "What is the difference between an object and a class?",
                    Answer1 = "An object is an instance of a class",
                    Answer2 = "A class is an instance of an object",
                    Answer3 = "How would I know?",
                    Answer4 = "Ojbects can be overridden while classes cannot",
                    CorrectAnswer = "a"
                },
                new Questions
                {
                    ID = 27,
                    Question = "What are the four OOP Principles?",
                    Answer1 = "Encapsultion, Abstraction, Polymorphism, Inheritance",
                    Answer2 = "Classes, Abstraction, Polymorphism, Inheritance",
                    Answer3 = "Classes, Objects, Polymorphism, Inheritance",
                    Answer4 = "There a only 3 OOP Principles",
                    CorrectAnswer = "a"
                },
                new Questions
                {
                    ID = 28,
                    Question = "What is Amanda's favorite Animal?",
                    Answer1 = "Komodo Dragons",
                    Answer2 = "Dogs",
                    Answer3 = "Snakes",
                    Answer4 = "Cats",
                    CorrectAnswer = "d"
                },
                new Questions
                {
                    ID = 29,
                    Question = "What is Amanda's favorite Animal?",
                    Answer1 = "Komodo Dragons",
                    Answer2 = "Dogs",
                    Answer3 = "Snakes",
                    Answer4 = "Cats",
                    CorrectAnswer = "d"
                },
                new Questions
                {
                    ID = 30,
                    Question = "What is the most valueable company right now?",
                    Answer1 = "Amazon",
                    Answer2 = "Alphabet",
                    Answer3 = "Microsoft",
                    Answer4 = "Apple",
                    CorrectAnswer = "c"
                }
                
            );
        }

        public DbSet<Questions> Questions { get; set; }
    }
}
