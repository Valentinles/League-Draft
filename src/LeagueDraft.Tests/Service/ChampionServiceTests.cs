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
    public class ChampionServiceTests
    {
        [Fact]
        public async Task GetRandomChampionAsync_WithCorrectData_ShouldReturnRandomChampion()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var championService = new ChampionService(context);

            SeedTestChampions(context);

            var getRandomChampion = await championService.GetRandomChampionAsync();

            Assert.True(getRandomChampion != null);
        }

        [Fact]
        public async Task GetRandomChampionAsync_WithIncorrectData_ShouldntReturnRandomChampion()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var championService = new ChampionService(context);

            var getRandomChampion = await championService.GetRandomChampionAsync();

            Assert.True(getRandomChampion == null);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetChampionByIdAsync_WithCorrectData_ShouldReturnChampionById(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var championService = new ChampionService(context);

            SeedTestChampions(context);

            var champion = await championService.GetChampionByIdAsync(id);

            Assert.True(champion.Id == id);
        }

        [Theory]
        [InlineData(25)]
        public async Task GetChampionByIdAsync_WithIncorrectData_ShouldntReturnChampionById(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var championService = new ChampionService(context);

            SeedTestChampions(context);

            var champion = await championService.GetChampionByIdAsync(id);

            Assert.True(champion == null);
        }

        [Fact]
        public async Task GetAllChampionsAsync_WithCorrectData_ShouldReturnAllChampions()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var championService = new ChampionService(context);

            SeedTestChampions(context);

            var result = await championService.GetAllChampionsAsync();

            Assert.True(result.Count() == 5);
        }

        [Fact]
        public async Task GetAllChampionsAsync_WithIncorrectData_ShouldntReturnAllChampions()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var championService = new ChampionService(context);

            var result = await championService.GetAllChampionsAsync();

            Assert.True(result.Count() == 0);
        }

        [Fact]
        public async Task GetFiveChampionsAsync_WithCorrectData_ShouldReturnFiveChampions()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var championService = new ChampionService(context);

            SeedTestChampions(context);

            var result = await championService.GetFiveChampionsAsync();

            Assert.True(result.Count() == 5);
        }

        [Fact]
        public async Task GetFiveChampionsAsync_WithIncorrectData_ShouldntReturnFiveChampions()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var championService = new ChampionService(context);

            var result = await championService.GetFiveChampionsAsync();

            Assert.True(result.Count() == 0);
        }

        private List<Champion> GetChampions()
        {
            var champions = new List<Champion>();

            for (int i = 1; i <= 5; i++)
            {
                var champion = new Champion()
                {
                    Id = i,
                    Name = "testChampion" + i
                };

                champions.Add(champion);
            }

            return champions;
        }

        private void SeedTestChampions(LeagueDraftDbContext context)
        {
            context.Champions.AddRange(GetChampions());
            context.SaveChanges();
        }
    }
}
