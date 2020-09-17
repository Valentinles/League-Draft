using LeagueDraft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueDraft.Data
{
    public class LeagueDraftDbContext : DbContext
    {
        public LeagueDraftDbContext(DbContextOptions<LeagueDraftDbContext> options) : base(options)
        {

        }
        public DbSet<Champion> Champions { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<SummonerSpell> SummonerSpells { get; set; }
    }
}
