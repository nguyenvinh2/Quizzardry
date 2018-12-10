using Microsoft.EntityFrameworkCore;
using Quizzardry.Data;
using Quizzardry.Models;
using Xunit;

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
                ID = 1,
                RoomID = "1",
                Name = "Farkus",
                Score = 500,
                Toad = true
            };

            Assert.True(newPlayer.Score == 500);
        }

        /// <summary>
        /// Tests the setter for Player
        /// </summary>
        [Fact]
        public void SetPlayerTest()
        {
            Player newPlayer = new Player()
            {
                ID = 1,
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
                    ID = 1,
                    RoomID = "1",
                    Name = "Farkus",
                    Score = 500,
                    Toad = true
                };

                context.Add(newPlayer);
                await context.SaveChangesAsync();

                Player foundPlayer = await context.Players.FirstOrDefaultAsync(player => player.ID == 1);
                Assert.True(foundPlayer.Name == "Farkus");
            }
        }
    }
}
;