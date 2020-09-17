using LeagueDraft.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeagueDraft.Services.Interfaces
{
    public interface IItemService
    {
        Task<List<Item>> GetRandomBuildAsync();

        Task<List<Item>> GetRandomJungleBuildAsync();

        Task<List<Item>> GetRandomSupportBuildAsync();

        Task<List<Item>> GetRandomBuildForPositionAsync(int id);
    }
}
