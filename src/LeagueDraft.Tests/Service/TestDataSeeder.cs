using LeagueDraft.Data;
using LeagueDraft.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueDraft.Tests.Service
{
    public class TestDataSeeder
    {
        private readonly LeagueDraftDbContext context;

        internal List<Champion> GetChampions()
        {
            var champions = new List<Champion>();

            for (int i = 1; i <= 5; i++)
            {
                var champion = new Champion()
                {
                    Name = "testChampion" + i
                };

                champions.Add(champion);
            }

            return champions;
        }

        internal void SeedTestChampions(LeagueDraftDbContext context)
        {
            context.Champions.AddRange(GetChampions());
            context.SaveChanges();
        }

        internal List<Item> GetItems()
        {
            var items = new List<Item>();

            for (int i = 1; i <= 6; i++)
            {
                var item = new Item()
                {
                    Name = "testItem" + i
                };

                items.Add(item);
            }

            return items;
        }

        void SeedTestItems(LeagueDraftDbContext context)
        {
            context.Items.AddRange(GetItems());
            context.SaveChanges();
        }
    }
}
