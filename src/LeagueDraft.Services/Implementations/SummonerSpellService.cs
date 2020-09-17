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
    public class SummonerSpellService : DataService, ISummonerSpellService
    {
        public SummonerSpellService(LeagueDraftDbContext context) : base(context)
        {
        }

        public async Task<List<SummonerSpell>> GetRandomSummonerSpellsAsync()
        {
            return await this.context.SummonerSpells
                .OrderBy(x => Guid.NewGuid())
                .Take(2).ToListAsync();
        }

        public async Task<List<SummonerSpell>> GetJunglerSummonerSpellsAsync()
        {
            var spells = new List<SummonerSpell>();

            var smite = await this.context.SummonerSpells.FirstOrDefaultAsync(x => x.Name.Equals("Smite"));

            var secondSummonerSpell = await this.context.SummonerSpells
                .Where(x => x.Name != "Smite")
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

            spells.Add(smite);
            spells.Add(secondSummonerSpell);

            return spells;
        }
    }
}
