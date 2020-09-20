using LeagueDraft.Data;
using LeagueDraft.Models;
using LeagueDraft.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeagueDraft.Tests.Service
{
    public class SummonerSpellServiceTests
    {
        [Fact]
        public async Task GetRandomSummonerSpellsAsync_WithCorrectData_ShouldReturnRandomSummonerSpells()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var summonerSpellService = new SummonerSpellService(context);

            SeedTestSummonerSpells(context);

            var getRandomSummonerSpells = await summonerSpellService.GetRandomSummonerSpellsAsync();

            Assert.True(getRandomSummonerSpells.Count() == 2);
        }

        [Fact]
        public async Task GetRandomSummonerSpellsAsync_WithIncorrectData_ShouldntReturnRandomSummonerSpells()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var summonerSpellService = new SummonerSpellService(context);

            var getRandomSummonerSpells = await summonerSpellService.GetRandomSummonerSpellsAsync();

            Assert.True(getRandomSummonerSpells.Count() == 0);
        }

        [Fact]
        public async Task GetJunglerSummonerSpellsAsync_WithCorrectData_ShouldReturnSmiteAndOneRandomSummonerSpell()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var summonerSpellService = new SummonerSpellService(context);

            var smite = new SummonerSpell()
            {
                Id=10,
                Name = "Smite"
            };

            await context.SummonerSpells.AddAsync(smite);
            SeedTestSummonerSpells(context);

            var getJunglerSummonerSpells = await summonerSpellService.GetJunglerSummonerSpellsAsync();

            Assert.True(getJunglerSummonerSpells.Count() == 2 && getJunglerSummonerSpells.Contains(smite));
        }

        [Fact]
        public async Task GetJunglerSummonerSpellsAsync_WithInorrectData_ShouldntReturnSmite()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var summonerSpellService = new SummonerSpellService(context);

            var smite = new SummonerSpell()
            {
                Id = 10,
                Name = "Smite"
            };

            SeedTestSummonerSpells(context);

            var getJunglerSummonerSpells = await summonerSpellService.GetJunglerSummonerSpellsAsync();

            Assert.DoesNotContain(smite, getJunglerSummonerSpells);
        }

        private List<SummonerSpell> GetSummonerSpells()
        {
            var summonerSpells = new List<SummonerSpell>();

            for (int i = 1; i <= 5; i++)
            {
                var summonerSpell = new SummonerSpell()
                {
                    Id = i,
                    Name = "testSummonerSpell" + i
                };

                summonerSpells.Add(summonerSpell);
            }

            return summonerSpells;
        }

        private void SeedTestSummonerSpells(LeagueDraftDbContext context)
        {
            context.SummonerSpells.AddRange(GetSummonerSpells());
            context.SaveChanges();
        }
    }
}
