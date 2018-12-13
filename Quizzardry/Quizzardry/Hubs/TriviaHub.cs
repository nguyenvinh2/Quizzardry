using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzardry.Models;
using Newtonsoft.Json;
using Quizzardry.Models.Interfaces;
using Quizzardry.Hubs;
using Quizzardry.Data;

namespace Quizzardry.Hubs
{
    public class TriviaHub : Hub
    {
        private static StorageHub<Guid> _connections = new StorageHub<Guid>();
        private readonly QuestionsDbContext _context;
        public static List<Questions> Questions = new List<Questions>();
        public static int Round = 1;

        public TriviaHub(QuestionsDbContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendUser(string user, Guid id)
        {
            await OnConnected(user, id);
            List<Player> userList = _connections.GetList();
            await Clients.All.SendAsync("ReceiveUser", userList, Questions, Round);
        }

        public Task OnConnected(string user, Guid id)
        {
            bool exists = false;
            Dictionary<Guid, Player> userList = _connections.GetConnections();
            exists = userList.ContainsKey(id);
            if (!exists)
            {
                Player NewPlayer = new Player();
                NewPlayer.ID = id;
                NewPlayer.Name = user;
                NewPlayer.Score = 0;
                NewPlayer.HasVoted = false;
                NewPlayer.IsAdmin = _connections.Count == 0 ? true : false;
                _connections.Add(NewPlayer.ID, NewPlayer);
            }
            return base.OnConnectedAsync();
        }

        public void AddPoints(Guid userGuid, string answer)
        {
            Player foundPlayer = _connections.GetPlayer(userGuid);
            if (!foundPlayer.HasVoted && answer == "d")
            {
                foundPlayer.Score += 100;
            }
            foundPlayer.HasVoted = true;
        }

        public async Task SubmitAnswers()
        {
            List<Player> userList = _connections.GetList();
            foreach (Player player in userList)
            {
                player.HasVoted = false;
            }
            Round++;
            await Clients.All.SendAsync("ReceiveUser", userList, Questions, Round);
        }

        public async Task CreateQuestions(string user, Guid id)
        {
            await OnConnected(user, id);
            List<Player> userList = _connections.GetList();
            
            List<Questions> AllQuestions = _context.Questions.ToList();
            while (Questions.Count < 5)
            {
                Random random = new Random();
                int index = random.Next(0, AllQuestions.Count);
                if (!Questions.Contains(AllQuestions[index]))
                {
                    Questions.Add(AllQuestions[index]);
                }
            }
            await Clients.All.SendAsync("ReceiveUser", userList, Questions, Round);

        }

        public async Task Reset()
        {
            _connections = new StorageHub<Guid>();
            Round = 1;
            await Clients.All.SendAsync("BackHome");
        }
    }
}
