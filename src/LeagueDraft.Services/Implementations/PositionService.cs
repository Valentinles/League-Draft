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
    public class PositionService : DataService, IPositionService
    {
        public PositionService(LeagueDraftDbContext context) : base(context)
        {
        }

        public async Task<Position> GetRandomPositionAsync()
        {
            return await this.context.Positions
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();
        }

        public async Task<Position> GetPositionByIdAsync(int id)
        {
            return await this.context.Positions
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
            return await this.context.Positions.ToListAsync();
        }
    }
}
