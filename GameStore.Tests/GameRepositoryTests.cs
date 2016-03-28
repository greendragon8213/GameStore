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
        #region GetAll testing
        [TestMethod]
        public void GetAll_ShouldReturnCorrectCollection_WhenContextNotEmpty()
        {
            // Arrange
            var data = new List<GameDataModel>
            {
                new GameDataModel {Id = 1, Name = "BBB", Key = "k1"},
                new GameDataModel {Id = 2, Name = "ZZZ", Key = "k2" },
                new GameDataModel {Id = 3, Name = "AAA", Key = "k3" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<GameDataModel>>();
            mockSet.As<IQueryable<GameDataModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<GameDataModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<GameDataModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<GameDataModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            var mockContext = new Mock<GameStoreDbContext>();
            mockContext.Setup(c => c.Set<GameDataModel>()).Returns(mockSet.Object);
            mockContext.Object.Games = mockSet.Object;
            mockContext.Object.Games.Add(new GameDataModel { Id = 1, Name = "BBB", Key = "k1" });
            mockContext.Object.Games.Add(new GameDataModel { Id = 2, Name = "ZZZ", Key = "k2" });
            mockContext.Object.Games.Add(new GameDataModel { Id = 3, Name = "AAA", Key = "k3" });
            
            //Act
            var service = new GameRepository(mockContext.Object);
            var result = service.GetAll().ToList();
            
            //Assert
            //Assert.AreEqual(data, result.ToList());
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("BBB", result[0].Name);
            Assert.AreEqual("ZZZ", result[1].Name);
            Assert.AreEqual("AAA", result[2].Name);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(2, result[1].Id);
            Assert.AreEqual(3, result[2].Id);
            Assert.AreEqual("k1", result[0].Key);
            Assert.AreEqual("k2", result[1].Key);
            Assert.AreEqual("k3", result[2].Key);
        }
        [TestMethod]
        public void GetAll_ShouldReturn0Games_WhenContextIsEmpty()
        {
            //ToDo
            // Arrange
            var data = new List<GameDataModel>
            {
            }.AsQueryable();

            var mockSet = new Mock<DbSet<GameDataModel>>();
            mockSet.As<IQueryable<GameDataModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<GameDataModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<GameDataModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<GameDataModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            var mockContext = new Mock<GameStoreDbContext>();
            mockContext.Setup(c => c.Set<GameDataModel>()).Returns(mockSet.Object);
            mockContext.Object.Games = mockSet.Object;
             
            //Act
            var service = new GameRepository(mockContext.Object);
            var result = service.GetAll().ToList();

            //Assert
            //Assert.IsNull(result);
            Assert.AreEqual(0, result.Count);
        }
        #endregion

        #region Remove testing
        [TestMethod]
        public void Remove_ShouldReturnCorrectCollection_WhenContextNotEmpty()
        {
            // Arrange
            var data = new List<GameDataModel>
            {
                new GameDataModel {Id = 1, Name = "BBB", Key = "k1"},
                new GameDataModel {Id = 2, Name = "ZZZ", Key = "k2" },
                new GameDataModel {Id = 3, Name = "AAA", Key = "k3" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<GameDataModel>>();
            mockSet.As<IQueryable<GameDataModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<GameDataModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<GameDataModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<GameDataModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            var mockContext = new Mock<GameStoreDbContext>();
            mockContext.Setup(c => c.Set<GameDataModel>()).Returns(mockSet.Object);
            mockContext.Object.Games = mockSet.Object;
            mockContext.Object.Games.Add(new GameDataModel { Id = 1, Name = "BBB", Key = "k1" });
            mockContext.Object.Games.Add(new GameDataModel { Id = 2, Name = "ZZZ", Key = "k2" });
            mockContext.Object.Games.Add(new GameDataModel { Id = 3, Name = "AAA", Key = "k3" });
            int gameIdToRemove = 2;

            //Act
            var service = new GameRepository(mockContext.Object);
            service.Remove(gameIdToRemove);
            var result = service.GetAll();

            //Assert
            //Assert.AreEqual(data, result.ToList());
            Assert.AreEqual(2, result.Count());
            ////Assert.AreEqual("BBB", result[0].Name);
            ////Assert.AreEqual("ZZZ", result[1].Name);
            ////Assert.AreEqual("AAA", result[2].Name);
            ////Assert.AreEqual(1, result[0].Id);
            ////Assert.AreEqual(2, result[1].Id);
            ////Assert.AreEqual(3, result[2].Id);
            ////Assert.AreEqual("k1", result[0].Key);
            ////Assert.AreEqual("k2", result[1].Key);
            ////Assert.AreEqual("k3", result[2].Key);
        }
        #endregion

    }
}
