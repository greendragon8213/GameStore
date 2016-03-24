using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using GameStore.Controllers;
using GameStore.Data.Abstract;
using GameStore.Data.Concrete;
using GameStore.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameStore.Tests
{
    [TestClass]
    public class GamesControllerTests
    {
        [TestMethod]
        public void GamesController_Index_ShouldReturnView()
        {
            // Arrange
            GamesController controller = new GamesController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GamesController_Details_ShouldReturnCorrectViewBag_WhenGameIdNotNull()
        {
            GamesController controller = new GamesController();

            ViewResult result = controller.Details(5) as ViewResult;

            Assert.AreEqual(5, result.ViewBag.GameId);
        }

        [TestMethod]
        public void GamesController_Details_ShouldReturnCorrectViewBag_WhenGameIdIsNull()
        {
            GamesController controller = new GamesController();

            ViewResult result = controller.Details(null) as ViewResult;

            Assert.AreEqual(null, result.ViewBag.GameId);
        }

        [TestMethod]
        public void GamesController_Update_UpdateForRepositoryIsCalledAndRedirectWorks()
        {
            // arrange
            var mock = new Mock<IGameRepository>();
            GamesController controller = new GamesController(mock.Object);
            var game = new Model.Game();

            // act
            RedirectToRouteResult result = controller.Update(game) as RedirectToRouteResult;

            // assert
            mock.Verify(a => a.Update(game), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void GameController_GetById_GetByIdForRepositoryIsCalledAndJsonResultIsCorrect()
        {
            var mock = new Mock<IGameRepository>();
            //context
            int gameId = 1;
            Game expectedGame = new Game(){Id = 1, Name = "name1", Key = "kkk1"};
            mock.Setup(m => m.GetById(gameId)).Returns(expectedGame);
            GamesController controller = new GamesController(mock.Object);

            //act
            JsonResult actual = controller.GetById(gameId) as JsonResult;

            //assert
            mock.Verify(a => a.GetById(gameId), Times.Once);
            Assert.AreEqual(expectedGame, actual.Data);
        }
    }
}
