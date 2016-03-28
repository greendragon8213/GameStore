using System.Collections.Generic;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using GameStore.Controllers;
using GameStore.Data.Abstract;
using GameStore.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameStore.Tests
{
    [TestClass]
    public class GamesControllerTests
    {
        #region Index testing
        [TestMethod]
        public void Index_ShouldAlwaysReturnView()
        {
            // Arrange
            var controller = new GamesController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion

        #region GetAllGames testing
        [TestMethod]
        public void GetAllGames_GetAllIsCalledAndAndJsonResultIsCorrect()
        {
            // Arrange
            var expectedGames = new List<GameDataModel>
            {
                new GameDataModel {Id = 1, Name = "BBB", Key = "k1"},
                new GameDataModel {Id = 2, Name = "ZZZ", Key = "k2"},
                new GameDataModel {Id = 3, Name = "AAA", Key = "k3"},
            };

            var mock = new Mock<IGameRepository>();
            mock.Setup(m => m.GetAll()).Returns(expectedGames);
            var controller = new GamesController(mock.Object);

            // Act
            var result = controller.GetAllGames() as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            mock.Verify(a => a.GetAll(), Times.Once);
            Assert.AreEqual(expectedGames, result.Data);
        }
        #endregion

        #region Details testing
        [TestMethod]
        public void Details_ShouldReturnCorrectViewBag_WhenGameIdNotNull()
        {
            // Arrange
            var controller = new GamesController();

            // Act
            var result = controller.Details(5) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.ViewBag.GameId);
        }

        [TestMethod]
        public void Details_ShouldReturnNullViewBag_WhenGameIdIsNull()
        {
            // Arrange
            var controller = new GamesController();

            // Act
            var result = controller.Details(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewBag.GameId);
        }
        #endregion

        #region Update testing
        [TestMethod]
        public void Update_InputIsValid_UpdateForRepositoryIsCalledAndRedirectWorks()
        {
            // Arrange
            var mock = new Mock<IGameRepository>();
            var controller = new GamesController(mock.Object);
            var game = new Model.Game();

            // Act
            var result = controller.Update(game) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            mock.Verify(a => a.Update(game), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Update_InputIsNotValid_UpdateForRepositoryIsCalledAndRedirectWorks()
        {
            // Arrange
            var mock = new Mock<IGameRepository>();
            var controller = new GamesController(mock.Object);
            Model.Game game = null;

            // Act
            var result = controller.Update(game) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            mock.Verify(a => a.Update(game), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        #endregion

        [TestMethod]
        public void Remove_RemoveForRepositoryIsCalledAndRedirectWorks()
        {
            //ToDo it doesn't works! bacause of Helpers in controller
            // Arrange
            var mock = new Mock<IGameRepository>();

            ////var request = new Mock<HttpRequestBase>();
            ////var context = new Mock<HttpContextBase>();
            ////context.SetupGet(x => x.Request).Returns(request.Object); //Set up request base for the httpcontext

            //context
            int gameId = 1;
            var expectedResult = new JsonResult();//Url.Action("Index", "Games"
            var controller = new GamesController(mock.Object);

            ////controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller); 

            // Act
            var result = controller.Remove(gameId) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            mock.Verify(a => a.Remove(gameId), Times.Once);
            //Assert.AreEqual(expectedResult, result.Data);
        }

        #region GetById testing
        [TestMethod]
        public void GetById_InputIsValid_GetByIdForRepositoryIsCalledAndJsonResultIsCorrect()
        {
            // Arrange
            var mock = new Mock<IGameRepository>();
            //context
            int gameId = 1;
            var expectedGame = new GameDataModel(){Id = 1, Name = "name1", Key = "kkk1"};
            mock.Setup(m => m.GetById(gameId)).Returns(expectedGame);
            var controller = new GamesController(mock.Object);

            // Act
            var result = controller.GetById(gameId) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            mock.Verify(a => a.GetById(gameId), Times.Once);
            Assert.AreEqual(expectedGame, result.Data);
        }

        [TestMethod]
        public void GetById_InputIsNotValid_GetByIdForRepositoryIsCalledAndJsonResultIsCorrect()
        {
            // Arrange
            var mock = new Mock<IGameRepository>();
            //context
            int gameId = -7;
            GameDataModel expectedGame = null;//new GameWebModel() { Id = 1, Name = "name1", Key = "kkk1" };
            mock.Setup(m => m.GetById(gameId)).Returns(expectedGame);
            var controller = new GamesController(mock.Object);

            // Act
            var result = controller.GetById(gameId) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            mock.Verify(a => a.GetById(gameId), Times.Once);
            Assert.AreEqual(expectedGame, result.Data);
        }
        #endregion
    }
}
