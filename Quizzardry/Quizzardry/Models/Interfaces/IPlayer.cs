using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzardry.Models.Interfaces
{
    interface IPlayer
    {
        // Get player data
        Task<Player> GetPlayer(Guid id);

        // Get all Player's By Room
        Task<IEnumerable<Player>> GetPlayersByRoom(string roomId);

        // Create a Player
        Task CreatePlayer(Player player);

        // Change a Player's Score
        Task UpdateScore(Player player, int score);

        // Update Player's Status
        Task UpdateStatus(Player player, bool toad);

        // Delete Player
        Task DeletePlayer(Player player);
    }
}
