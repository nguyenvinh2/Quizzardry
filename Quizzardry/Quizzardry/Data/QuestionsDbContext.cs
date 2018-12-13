﻿using Microsoft.EntityFrameworkCore;
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
                }
            );
        }

        public DbSet<Questions> Questions { get; set; }
    }
}
