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
    public class ItemServiceTests
    {
        [Fact]
        public async Task GetRandomBuildAsync_WithCorrectData_ShouldReturnRandomBuildWithBoots()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);

            var getRandomBuild = await itemService.GetRandomBuildAsync();

            Assert.Contains(getRandomBuild, x => x.Type.Equals(ItemType.Boots));
        }

        [Fact]
        public async Task GetRandomBuildAsync_WithCorrectData_ShouldReturnRandomBuildWithSixItems()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);

            var getRandomBuild = await itemService.GetRandomBuildAsync();

            Assert.Equal(6, getRandomBuild.Count());
        }

        [Fact]
        public async Task GetRandomBuildAsync_WithIncorrectData_ShouldntReturnCompleteRandomBuild()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);


            var getRandomBuild = await itemService.GetRandomBuildAsync();

            Assert.True(getRandomBuild.Count() < 6);
        }

        [Fact]
        public async Task GetRandomJungleBuildAsync_WithCorrectData_ShouldReturnRandomJungleBuildWithBoots()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);

            var getRandomBuild = await itemService.GetRandomJungleBuildAsync();

            Assert.Contains(getRandomBuild, x => x.Type.Equals(ItemType.Boots));
        }

        [Fact]
        public async Task GetRandomJungleBuildAsync_WithCorrectData_ShouldReturnRandomJungleBuildWithJungleItem()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);

            var getRandomBuild = await itemService.GetRandomJungleBuildAsync();

            Assert.Contains(getRandomBuild, x => x.Type.Equals(ItemType.Jungle));
        }

        [Fact]
        public async Task GetRandomJungleBuildAsync_WithCorrectData_ShouldReturnRandomJungleBuildWithSixItems()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);

            var getRandomBuild = await itemService.GetRandomJungleBuildAsync();

            Assert.Equal(6, getRandomBuild.Count());
        }

        [Fact]
        public async Task GetRandomJungleBuildAsync_WithIncorrectData_ShouldntReturnCompleteRandomJungleBuild()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            var getRandomBuild = await itemService.GetRandomJungleBuildAsync();

            Assert.True(getRandomBuild.Count() < 6);
        }

        [Fact]
        public async Task GetRandomSupportBuildAsync_WithCorrectData_ShouldReturnRandomSupportBuildWithBoots()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);

            var getRandomBuild = await itemService.GetRandomSupportBuildAsync();

            Assert.Contains(getRandomBuild, x => x.Type.Equals(ItemType.Boots));
        }

        [Fact]
        public async Task GetRandomSupportBuildAsync_WithCorrectData_ShouldReturnRandomSupportBuildWithJSupportItem()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);

            var getRandomBuild = await itemService.GetRandomSupportBuildAsync();

            Assert.Contains(getRandomBuild, x => x.Type.Equals(ItemType.Support));
        }

        [Fact]
        public async Task GetRandomSupportBuildAsync_WithCorrectData_ShouldReturnRandomSupportBuildWithSixItems()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);

            var getRandomBuild = await itemService.GetRandomSupportBuildAsync();

            Assert.Equal(6, getRandomBuild.Count());
        }

        [Fact]
        public async Task GetRandomSupportBuildAsync_WithIncorrectData_ShouldntReturnCompleteRandomSupportBuild()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            var getRandomBuild = await itemService.GetRandomSupportBuildAsync();

            Assert.True(getRandomBuild.Count() < 6);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task GetRandomBuildForPositionAsync_WithCorrectData_ShouldReturnRandomBuildForTopOrMidOrBotPositonWithBoots(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);
            SeedTestPositions(context);

            var getRandomBuild = await itemService.GetRandomBuildForPositionAsync(id);

            Assert.Contains(getRandomBuild, x => x.Type.Equals(ItemType.Boots));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task GetRandomBuildForPositionAsync_WithCorrectData_ShouldReturnRandomBuildForTopOrMidOrBotPositon(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);
            SeedTestPositions(context);

            var getRandomBuild = await itemService.GetRandomBuildForPositionAsync(id);

            Assert.Equal(6, getRandomBuild.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task GetRandomBuildForPositionAsync_WithInorrectData_ShouldntReturnCompleteRandomBuildForTopOrMidOrBotPositon(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestPositions(context);

            var getRandomBuild = await itemService.GetRandomBuildForPositionAsync(id);

            Assert.True(getRandomBuild.Count() < 6);
        }

        [Theory]
        [InlineData(2)]
        public async Task GetRandomBuildForPositionAsync_WithCorrectData_ShouldReturnRandomBuildForJunglePositonWithBoots(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);
            SeedTestPositions(context);

            var getRandomBuild = await itemService.GetRandomBuildForPositionAsync(id);

            Assert.Contains(getRandomBuild, x => x.Type.Equals(ItemType.Boots));
        }

        [Theory]
        [InlineData(2)]
        public async Task GetRandomBuildForPositionAsync_WithCorrectData_ShouldReturnRandomBuildForJunglePositonWithJungleItem(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);
            SeedTestPositions(context);

            var getRandomBuild = await itemService.GetRandomBuildForPositionAsync(id);

            Assert.Contains(getRandomBuild, x => x.Type.Equals(ItemType.Jungle));
        }

        [Theory]
        [InlineData(2)]
        public async Task GetRandomBuildForPositionAsync_WithCorrectData_ShouldReturnRandomBuildForJunglePositonWithSixItems(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);
            SeedTestPositions(context);

            var getRandomBuild = await itemService.GetRandomBuildForPositionAsync(id);

            Assert.True(getRandomBuild.Count() == 6);
        }

        [Theory]
        [InlineData(2)]
        public async Task GetRandomBuildForPositionAsync_WithIncorrectData_ShouldntReturnCompleteRandomBuildForJunglePositon(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);
            SeedTestPositions(context);

            var getRandomBuild = await itemService.GetRandomBuildForPositionAsync(id);

            Assert.True(getRandomBuild.Count() == 6);
        }

        [Theory]
        [InlineData(5)]
        public async Task GetRandomBuildForPositionAsync_WithCorrectData_ShouldReturnRandomBuildForSupportPositonWithBoots(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);
            SeedTestPositions(context);

            var getRandomBuild = await itemService.GetRandomBuildForPositionAsync(id);

            Assert.Contains(getRandomBuild, x => x.Type.Equals(ItemType.Boots));
        }

        [Theory]
        [InlineData(5)]
        public async Task GetRandomBuildForPositionAsync_WithCorrectData_ShouldReturnRandomBuildForSupportPositonWithSupportItem(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);
            SeedTestPositions(context);

            var getRandomBuild = await itemService.GetRandomBuildForPositionAsync(id);

            Assert.Contains(getRandomBuild, x => x.Type.Equals(ItemType.Support));
        }

        [Theory]
        [InlineData(5)]
        public async Task GetRandomBuildForPositionAsync_WithCorrectData_ShouldReturnRandomBuildForSupportPositonWithSixItems(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);
            SeedTestPositions(context);

            var getRandomBuild = await itemService.GetRandomBuildForPositionAsync(id);

            Assert.True(getRandomBuild.Count() == 6);
        }

        [Theory]
        [InlineData(5)]
        public async Task GetRandomBuildForPositionAsync_WithIncorrectData_ShouldntReturnCompleteRandomBuildForSupportPositon(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var itemService = new ItemService(context);

            SeedTestItems(context);
            SeedTestPositions(context);

            var getRandomBuild = await itemService.GetRandomBuildForPositionAsync(id);

            Assert.True(getRandomBuild.Count() == 6);
        }

        private List<Item> GetTestItems()
        {
            return new List<Item>()
            {
                new Item
                {
                    Name="testBoots",
                    Type = ItemType.Boots
                },
                new Item
                {
                    Name="testJungleItem",
                    Type = ItemType.Jungle
                },
                new Item
                {
                    Name="testSupportItem",
                    Type = ItemType.Support
                },
                new Item
                {
                    Name="testItemOne",
                    Type = ItemType.Other
                },
                new Item
                {
                    Name="testItemTwo",
                    Type = ItemType.Other
                },
                new Item
                {
                    Name="testItemThree",
                    Type = ItemType.Other
                },
                new Item
                {
                    Name="testItemFour",
                    Type = ItemType.Other
                },
                new Item
                {
                    Name="testItemFive",
                    Type = ItemType.Other
                }
            };
        }

        private void SeedTestItems(LeagueDraftDbContext context)
        {
            context.Items.AddRange(GetTestItems());
            context.SaveChanges();
        }

        private List<Position> GetTestPositions()
        {
            return new List<Position>()
            {
                new Position
                {
                    Id=1,
                    Name="Top"
                },
                new Position
                {
                    Id=2,
                    Name="Jungle"
                },
                new Position
                {
                    Id=3,
                    Name="Mid"
                },
                new Position
                {
                    Id=4,
                    Name="Bottom"
                },
                new Position
                {
                    Id=5,
                    Name="Support"
                }
            };
        }
        private void SeedTestPositions(LeagueDraftDbContext context)
        {
            context.Positions.AddRange(GetTestPositions());
            context.SaveChanges();
        }
    }
}
