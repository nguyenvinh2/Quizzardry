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
        private static StorageHub<string> _connections = new StorageHub<string>();
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

        public async Task SendUser(string user)
        {
            await OnConnected(user);
            List<Player> userList = _connections.GetList();
            await Clients.All.SendAsync("UserJoin", userList);
            await Clients.All.SendAsync("ReceiveUser", userList, Questions, Round);
        }


        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _connections.Remove(Context.ConnectionId);
            List<Player> userList = _connections.GetList();
            await Clients.All.SendAsync("ReceiveUser", userList, Questions, Round);
            await Clients.All.SendAsync("UserJoin", userList);
            await MakeAdmin();
        }

        public Task OnConnected(string user)
        {
            bool exists = false;
            Dictionary<string, Player> userList = _connections.GetConnections();
            exists = userList.ContainsKey(Context.ConnectionId);
            if (!exists)
            {
                Player NewPlayer = new Player();
                NewPlayer.ID = Context.ConnectionId;
                NewPlayer.Name = user;
                NewPlayer.Score = 0;
                NewPlayer.HasVoted = false;
                NewPlayer.IsAdmin = _connections.Count == 0 ? true : false;
                _connections.Add(NewPlayer.ID, NewPlayer);
            }
            return base.OnConnectedAsync();
        }

        public async void AddPoints(string answer, int round)
        {
            string feedback = "";
            Player foundPlayer = _connections.GetPlayer(Context.ConnectionId);
            if (!foundPlayer.HasVoted && answer == Questions[round - 1].CorrectAnswer)
            {
                foundPlayer.Score += 100;
                feedback = $"You got the answer right! Score: {foundPlayer.Score}";
            }
            else
            {
                feedback = $"You got the answer wrong.  Score: {foundPlayer.Score}";
            }
            foundPlayer.HasVoted = true;
            if (Round > 5)
            {
                await Clients.All.SendAsync("TallyPoints", Round, _connections.GetList(), feedback);
            }
            else
            {
                await Clients.Client(Context.ConnectionId).SendAsync("TallyPoints", Round, _connections.GetList(), feedback);
            }
        }


        public async Task SubmitAnswers()
        {
            List<Player> userList = _connections.GetList();
            foreach (Player player in userList)
            {
                player.HasVoted = false;
            }
            
            await Clients.All.SendAsync("Vote", Round);
            Round++;
            await Clients.All.SendAsync("ReceiveUser", userList, Questions, Round);
            await MakeAdmin();
        }

        public async Task CreateQuestions(string user)
        {
            await OnConnected(user);
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
            await Clients.All.SendAsync("UserJoin", userList);
            await Clients.All.SendAsync("ReceiveUser", userList, Questions, Round);
            await MakeAdmin();
        }

        public async Task Reset()
        {
            _connections = new StorageHub<string>();
            Questions = new List<Questions>();
            Round = 1;
            await Clients.All.SendAsync("BackHome");
        }

        public async Task MakeAdmin()
        {
            Dictionary<string, Player> userKey = _connections.GetConnections();
            List<Player> userList = _connections.GetList();
            await Clients.Client(userKey.Keys.First()).SendAsync("MakeAdmin", Questions, Round, userList);
        }
    }
}
