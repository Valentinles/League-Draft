using LeagueDraft.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeagueDraft.Services.Interfaces
{
    public interface IPositionService
    {
        Task<Position> GetRandomPositionAsync();

        Task<Position> GetPositionByIdAsync(int id);

        Task<IEnumerable<Position>> GetAllPositionsAsync();
    }
}
