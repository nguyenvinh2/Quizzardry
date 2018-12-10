using Microsoft.EntityFrameworkCore;
using Quizzardry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzardry.Data
{
    public class GamesDbContext : DbContext
    {
        public GamesDbContext(DbContextOptions<GamesDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
    }
}
