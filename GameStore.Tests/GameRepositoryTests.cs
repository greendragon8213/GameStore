using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GameStore.Data.Concrete;
using GameStore.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameStore.Tests
{
    [TestClass]
    public class GameRepositoryTests
    {
        [TestMethod]
        public void GameRepository_GetAll_ShouldReturnCorrectCollection_WhenContextNotEmpty()
        {
            //// Arrange
            var data = new List<Game>
            {
                new Game {Id = 1, Name = "BBB", Key = "k1"},
                new Game {Id = 2, Name = "ZZZ", Key = "k2" },
                new Game {Id = 3, Name = "AAA", Key = "k3" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Game>>();
            mockSet.As<IQueryable<Game>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Game>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Game>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Game>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            var mockContext = new Mock<GameStoreDbContext>();
            mockContext.Object.Games = mockSet.Object;
            mockContext.Object.Games.Add(new Game { Id = 1, Name = "BBB", Key = "k1" });
            mockContext.Object.Games.Add(new Game { Id = 2, Name = "ZZZ", Key = "k2" });
            mockContext.Object.Games.Add(new Game { Id = 3, Name = "AAA", Key = "k3" });
            //mockContext.Setup(c => c.Games).Returns(mockSet.Object);

            var service = new GameRepository(mockContext.Object);
            var result = service.GetAll().ToList();
            
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("AAA", result[0].Name);
            Assert.AreEqual("BBB", result[1].Name);
            Assert.AreEqual("ZZZ", result[2].Name);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(2, result[1].Id);
            Assert.AreEqual(3, result[2].Id);
            Assert.AreEqual("k1", result[0].Key);
            Assert.AreEqual("k2", result[1].Key);
            Assert.AreEqual("k3", result[2].Key);
        }
    }
}
