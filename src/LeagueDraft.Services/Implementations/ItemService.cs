using LeagueDraft.Common.Constants;
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
    public class ItemService : DataService, IItemService
    {
        public ItemService(LeagueDraftDbContext context) : base(context)
        {
        }

        public async Task<List<Item>> GetRandomBuildAsync()
        {
            var build = new List<Item>();

            var rndBoots = await this.context.Items
                .Where(x => x.Type == 0)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

            var rndItems = this.context.Items
                .Where(x => (x.Type != ItemType.Boots) && (x.Type != ItemType.Support) && (x.Type != ItemType.Jungle))
                .OrderBy(x => Guid.NewGuid())
                .Take(5);

            build.Add(rndBoots);
            build.AddRange(rndItems);

            return build;
        }

        public async Task<List<Item>> GetRandomJungleBuildAsync()
        {
            var build = new List<Item>();

            var rndBoots = await this.context.Items
                .Where(x => x.Type == 0)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

            var rndJungleItem = await this.context.Items
                .Where(x => x.Type == ItemType.Jungle)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

            var rndItems = this.context.Items
                .Where(x => (x.Type != ItemType.Boots) && (x.Type != ItemType.Support) && (x.Type != ItemType.Jungle))
                .OrderBy(x => Guid.NewGuid())
                .Take(4);

            build.Add(rndBoots);
            build.Add(rndJungleItem);
            build.AddRange(rndItems);

            return build;
        }

        public async Task<List<Item>> GetRandomSupportBuildAsync()
        {
            var build = new List<Item>();

            var rndBoots = await this.context.Items
                .Where(x => x.Type == 0)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

            var rndSupportItem = await this.context.Items
                .Where(x => x.Type == ItemType.Support)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

            var rndItems = this.context.Items
                .Where(x => (x.Type != ItemType.Boots) && (x.Type != ItemType.Support) && (x.Type != ItemType.Jungle))
                .OrderBy(x => Guid.NewGuid())
                .Take(4);

            build.Add(rndBoots);
            build.Add(rndSupportItem);
            build.AddRange(rndItems);

            return build;
        }

        public async Task<List<Item>> GetRandomBuildForPositionAsync(int id)
        {
            var position = await this.context.Positions.FirstOrDefaultAsync(x => x.Id == id);

            var build = new List<Item>();

            var rndBoots = await this.context.Items
                .Where(x => x.Type == 0)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();


            var rndItems = this.context.Items
                .Where(x => (x.Type != ItemType.Boots) && (x.Type != ItemType.Support) && (x.Type != ItemType.Jungle))
                .OrderBy(x => Guid.NewGuid())
                .Take(4);

            build.Add(rndBoots);

            if (PositionConstants.Jungle.Equals(position.Name))
            {
                var rndJungleItem = await this.context.Items
                .Where(x => x.Type == ItemType.Jungle)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

                build.Add(rndJungleItem);
            }
            else if (PositionConstants.Support.Equals(position.Name))
            {
                var rndSupportItem = await this.context.Items
                .Where(x => x.Type == ItemType.Support)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

                build.Add(rndSupportItem);
            }
            else
            {
                rndItems = this.context.Items
                .Where(x => (x.Type != ItemType.Boots) && (x.Type != ItemType.Support) && (x.Type != ItemType.Jungle))
                .OrderBy(x => Guid.NewGuid())
                .Take(5);
            }

            build.AddRange(rndItems);

            return build;
        }
    }
}
