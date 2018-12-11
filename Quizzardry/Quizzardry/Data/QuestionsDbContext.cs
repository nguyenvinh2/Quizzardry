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
                    Question = "Who is Neth's favorite artist?",
                    Answer1 = "REM",
                    Answer2 = "Drake",
                    Answer3 = "Busta Rhymes",
                    CorrectAnswer = "Taylor Swift"
                },

                new Questions
                {
                    ID = 2,
                    Question = "Who is Vinh's favorite person?",
                    Answer1 = "Suzy",
                    Answer2 = "Amanda",
                    Answer3 = "Kendra",
                    CorrectAnswer = "TRE"
                }
            );
        }

        public DbSet<Questions> Questions { get; set; }
    }
}
