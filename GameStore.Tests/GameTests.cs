using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using GameStore.Data;
using GameStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameStore.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Game_GetAll_ShouldReturnCorrectCollection_WhenContextNotEmpty()
        {
            // Arrange
            var context = new Mock<GameStoreDataContext>();
            var game1 = new Games();
            var game2 = new Games();

            //context.Setup(x => x.Games).Returns(new DbSet<Games>());

            // Act
            var qqq = context.Object;

            // Arrange

        }
    }
}
