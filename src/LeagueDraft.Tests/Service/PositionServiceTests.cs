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
    public class PositionServiceTests
    {
        [Fact]
        public async Task GetRandomPositionAsync_WithCorrectData_ShouldReturnRandomPosition()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var positionService = new PositionService(context);

            SeedTestPositions(context);

            var getRandomPosition = await positionService.GetRandomPositionAsync();

            Assert.True(getRandomPosition != null);
        }

        [Fact]
        public async Task GetRandomPositionAsync_WithIncorrectData_ShouldntReturnRandomPosition()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var positionService = new PositionService(context);

            var getRandomPosition = await positionService.GetRandomPositionAsync();

            Assert.True(getRandomPosition == null);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetPositionByIdAsync_WithCorrectData_ShouldReturnPositionById(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var positionService = new PositionService(context);

            SeedTestPositions(context);

            var position = await positionService.GetPositionByIdAsync(id);

            Assert.True(position.Id == id);
        }

        [Theory]
        [InlineData(25)]
        public async Task GetPositionByIdAsync_WithIncorrectData_ShouldntReturnPositionById(int id)
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var positionService = new PositionService(context);

            SeedTestPositions(context);

            var position = await positionService.GetPositionByIdAsync(id);

            Assert.True(position == null);
        }

        [Fact]
        public async Task GetAllPositionsAsync_WithCorrectData_ShouldReturnAllPositions()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var positionService = new PositionService(context);

            SeedTestPositions(context);

            var result = await positionService.GetAllPositionsAsync();

            Assert.True(result.Count() == 5);
        }

        [Fact]
        public async Task GetAllPositionsAsync_WithIncorrectData_ShouldntReturnAllPositions()
        {
            var options = new DbContextOptionsBuilder<LeagueDraftDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new LeagueDraftDbContext(options);

            var positionService = new PositionService(context);

            var result = await positionService.GetAllPositionsAsync();

            Assert.True(result.Count() == 0);
        }

        private List<Position> GetPositions()
        {
            var positions = new List<Position>();

            for (int i = 1; i <= 5; i++)
            {
                var position = new Position()
                {
                    Id = i,
                    Name = "testPosition" + i
                };

                positions.Add(position);
            }

            return positions;
        }

        private void SeedTestPositions(LeagueDraftDbContext context)
        {
            context.Positions.AddRange(GetPositions());
            context.SaveChanges();
        }
    }
}
