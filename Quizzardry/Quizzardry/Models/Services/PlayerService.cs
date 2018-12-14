using Microsoft.EntityFrameworkCore;
using Quizzardry.Data;
using Quizzardry.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzardry.Models.Services
{
    public class PlayerService : IPlayer
    {
        private GamesDbContext _context;

        public PlayerService(GamesDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Saves a new instance of player to the database
        /// </summary>
        /// <param name="player">The player to be added</param>
        /// <returns>Nothing, creates new player object in database</returns>
        public async Task CreatePlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Deletes a player from the database
        /// </summary>
        /// <param name="player">The player instance to remove</param>
        /// <returns>Nothing, removes a player from the database</returns>
        public async Task DeletePlayer(Player player)
        {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Gets a player object from the database
        /// </summary>
        /// <param name="id">The id of the player to get from the database</param>
        /// <returns>A player object</returns>
        public async Task<Player> GetPlayer(string id)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.ID == id);
        }
        /// <summary>
        /// Gets all player objects with the same room ID
        /// </summary>
        /// <param name="roomId">The Room ID to indicate if player should be added to list</param>
        /// <returns>A list of players in the room specified</returns>
        public async Task<IEnumerable<Player>> GetPlayersByRoom(string roomId)
        {
            return await _context.Players.Where(p => p.RoomID == roomId).ToListAsync();
        }
        /// <summary>
        /// Updates the score of one player
        /// </summary>
        /// <param name="player">The player instance that will have score changed</param>
        /// <param name="score">The amount to increment (or decrement) score</param>
        /// <returns>Nothing, updates player's score in database</returns>
        public async Task UpdateScore(Player player, int score)
        {
            player.Score += score;
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Updates a player's toad status
        /// </summary>
        /// <param name="player">The player instance that will have status changed</param>
        /// <param name="toad">What the player's toad status will be changed to</param>
        /// <returns>Nothing, updates players status in database</returns>
        public async Task UpdateStatus(Player player, bool toad)
        {
            player.Toad = toad;
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
        }
    }
}
