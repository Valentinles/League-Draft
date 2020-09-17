using LeagueDraft.Data;
using LeagueDraft.Models;
using LeagueDraft.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueDraft.Services.Implementations
{
    public class ChampionService : DataService, IChampionService
    {
        public ChampionService(LeagueDraftDbContext context) : base(context)
        {
        }

        public async Task<Champion> GetRandomChampionAsync()
        {
            return await this.context.Champions
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();
        }

        public async Task<Champion> GetChampionByIdAsync(int id)
        {
            return await this.context.Champions
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Champion>> GetAllChampionsAsync()
        {
            return await this.context.Champions
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Champion>> GetFiveChampionsAsync()
        {
            return await this.context.Champions
                .OrderBy(x => Guid.NewGuid())
                .Take(5)
                .ToListAsync();
        }

    }
}
