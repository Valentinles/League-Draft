using LeagueDraft.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeagueDraft.Services.Interfaces
{
    public interface ISummonerSpellService
    {
        Task<List<SummonerSpell>> GetRandomSummonerSpellsAsync();

        Task<List<SummonerSpell>> GetJunglerSummonerSpellsAsync();
    }
}
