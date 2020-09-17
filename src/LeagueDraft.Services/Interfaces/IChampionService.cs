using LeagueDraft.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeagueDraft.Services.Interfaces
{
    public interface IChampionService
    {
        Task<Champion> GetRandomChampionAsync();

        Task<Champion> GetChampionByIdAsync(int id);

        Task<IEnumerable<Champion>> GetAllChampionsAsync();

        Task<IEnumerable<Champion>> GetFiveChampionsAsync();
    }
}
