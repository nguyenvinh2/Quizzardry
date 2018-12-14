using Microsoft.EntityFrameworkCore;
using Quizzardry.Data;
using Quizzardry.Models;
using Xunit;
using System;

namespace QuizzardryTest
{
    public class PlayerTest
    {
        /// <summary>
        /// Tests the getter for Player
        /// </summary>
        [Fact]
        public void GetPlayerTest()
        {
            Player newPlayer = new Player()
            {
                ID = "1",
                RoomID = "1",
                Name = "Farkus",
                Score = 500,
                Toad = true
            };

            Assert.True(newPlayer.Score == 500);
        }
        /// <summary>
        /// Test the getter for Question
        /// </summary>
        [Fact]
        public void GetQuestionTest()
        {
            Questions newQuestion = new Questions()
            {
                ID = 1,
                Question = "In REM's \"What's the Frequency, Kenneth\" who is the titular Kenneth?",
                Answer1 = "Physicist Kenneth Bainbridge",
                Answer2 = "Actor Kenneth Branaugh",
                Answer3 = "Singer Kenneth \"Babyface\" Edmonds",
                Answer4 = "Nobody!",
                CorrectAnswer = "d"
            };
            Assert.True(newQuestion.Answer4 == "Nobody!");
        }

        /// <summary>
        /// Test the setter for Question
        /// </summary>
        [Fact]
        public void SetQuestionTest()
        {
            Questions newQuestion = new Questions()
            {
                ID = 1,
                Question = "In REM's \"What's the Frequency, Kenneth\" who is the titular Kenneth?",
                Answer1 = "Physicist Kenneth Bainbridge",
                Answer2 = "Actor Kenneth Branaugh",
                Answer3 = "Singer Kenneth \"Babyface\" Edmonds",
                Answer4 = "Nobody!",
                CorrectAnswer = "d"
            };

            newQuestion.CorrectAnswer = "e";
            Assert.True(newQuestion.CorrectAnswer == "e");
        }

        /// <summary>
        /// Tests the setter for Player
        /// </summary>
        [Fact]
        public void SetPlayerTest()
        {
            Player newPlayer = new Player()
            {
                ID = "1",
                RoomID = "1",
                Name = "Farkus",
                Score = 500,
                Toad = true
            };

            newPlayer.Score = 350;

            Assert.True(newPlayer.Score == 350);
        }

        /// <summary>
        /// Tests creating a player
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task CreatePlayerTestAsync()
        {
            DbContextOptions<GamesDbContext> options = new DbContextOptionsBuilder<GamesDbContext>().UseInMemoryDatabase("CreatePlayer").Options;

            using (GamesDbContext context = new GamesDbContext(options))
            {
                Player newPlayer = new Player()
                {
                    ID = "1",
                    RoomID = "1",
                    Name = "Farkus",
                    Score = 500,
                    Toad = true
                };

                context.Add(newPlayer);
                await context.SaveChangesAsync();

                Player foundPlayer = await context.Players.FirstOrDefaultAsync(player => player.ID == "1");
                Assert.True(foundPlayer.Name == "Farkus");
            }
        }

        /// <summary>
        /// Tests updating a player
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task UpdatePlayerTestAsync()
        {
            DbContextOptions<GamesDbContext> options = new DbContextOptionsBuilder<GamesDbContext>().UseInMemoryDatabase("UpdatePlayer").Options;

            using (GamesDbContext context = new GamesDbContext(options))
            {
                Player newPlayer = new Player()
                {
                    ID = "1",
                    RoomID = "1",
                    Name = "Farkus",
                    Score = 500,
                    Toad = true
                };

                context.Add(newPlayer);
                await context.SaveChangesAsync();

                Player foundPlayer = await context.Players.FirstOrDefaultAsync(player => player.ID == "1");
                foundPlayer.Score = 250;

                context.Update(foundPlayer);
                Player updatedPlayer = await context.Players.FirstOrDefaultAsync(player => player.ID == "1");

                Assert.True(updatedPlayer.Score == 250);
            }
        }

        /// <summary>
        /// Tests delete a player
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task DeletePlayerTestAsync()
        {
            DbContextOptions<GamesDbContext> options = new DbContextOptionsBuilder<GamesDbContext>().UseInMemoryDatabase("DeletePlayer").Options;

            using (GamesDbContext context = new GamesDbContext(options))
            {
                Player newPlayer = new Player()
                {
                    ID = "1",
                    RoomID = "1",
                    Name = "Farkus",
                    Score = 500,
                    Toad = true
                };

                context.Add(newPlayer);
                await context.SaveChangesAsync();

                Player foundPlayer = await context.Players.FirstOrDefaultAsync(player => player.ID == "1");
                foundPlayer.Score = 250;

                context.Remove(foundPlayer);
                await context.SaveChangesAsync();
                Player deletedPlayer = await context.Players.FirstOrDefaultAsync(player => player.ID == "1");

                Assert.True(deletedPlayer == null);
            }
        }
    }
}
;