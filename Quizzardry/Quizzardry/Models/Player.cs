﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzardry.Models
{
    public class Player
    {
        public string ID { get; set; }
        public string RoomID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public bool Toad { get; set; }
        public bool HasVoted { get; set; }
        public bool IsAdmin { get; set; }
    }
}
