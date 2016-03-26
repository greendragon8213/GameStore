using System.Collections.Generic;
using System.Web.Mvc;
using GameStore.Controllers;
using GameStore.Data.Abstract;
using GameStore.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameStore.Tests
{
    [TestClass]
    public class CommentControllerTests
    {
        #region Comments testing
        [TestMethod]
        public void Comments_ValidGameId_ShouldReturnCorrectViewBag()
        {
            // Arrange
            var controller = new CommentController();
            int gameId = 5;

            // Act
            var result = controller.Comments(gameId) as PartialViewResult;

            // Assert   
            Assert.IsNotNull(result);
            Assert.AreEqual(gameId, result.ViewBag.GameId);
        }

        [TestMethod]
        public void Comments_InvalidGameId_ShouldReturnCorrectViewBag()
        {
            // Arrange
            var controller = new CommentController();
            int gameId = -33;

            // Act
            var result = controller.Comments(gameId) as PartialViewResult;

            // Assert   
            Assert.IsNotNull(result);
            Assert.AreEqual(gameId, result.ViewBag.GameId);
            //Assert.IsNull(result.ViewBag.GameId);
        }
        #endregion

        #region GetCommentsByGameId testing
        [TestMethod]
        public void GetCommentsByGameId_InputIsValid_GetByIdForRepositoryIsCalledAndJsonResultIsCorrect()
        {
            // Arrange
            var mock = new Mock<ICommentRepository>();
            //context
            int gameId = 44;
            List<Comment> expectedCommentList = new List<Comment>()
            {
                new Comment(){Body = "first comment", Id = 1, GameId = gameId, ParentCommentId = 102, Name = "testN"},
                new Comment(){Body = "second comment", Id = 2, GameId = gameId, ParentCommentId = null, Name = "testN"},
                new Comment(){Body = "my own comment", Id = 3, GameId = gameId, ParentCommentId = 102, Name = "testN"}
            };
            mock.Setup(m => m.GetCommentsByGameId(gameId)).Returns(expectedCommentList);
            var controller = new CommentController(mock.Object);

            // Act
            var result = controller.GetCommentsByGameId(gameId) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            mock.Verify(a => a.GetCommentsByGameId(gameId), Times.Once);
            Assert.AreEqual(expectedCommentList, result.Data);
        }

        [TestMethod]
        public void GetCommentsByGameId_InputIsNotValid_GetByIdForRepositoryIsCalledAndJsonResultIsNull()
        {
            // Arrange
            var mock = new Mock<ICommentRepository>();
            //context
            int gameId = -5;
            List<Comment> expectedCommentList = null;
            mock.Setup(m => m.GetCommentsByGameId(gameId)).Returns(expectedCommentList);
            var controller = new CommentController(mock.Object);

            // Act
            var result = controller.GetCommentsByGameId(gameId) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            mock.Verify(a => a.GetCommentsByGameId(gameId), Times.Once);
            Assert.IsNull(result.Data);
        }
        #endregion

        #region NewComment testing
        [TestMethod]
        public void NewComment_InputIsValid_AddForRepositoryIsCalledAndRedirectWorks()
        {
            // Arrange
            var mock = new Mock<ICommentRepository>();
            var controller = new CommentController(mock.Object);
            string expectedContent = "test Content";
            int expectedGameId = 7;
            int? expectedParentCommentId = 2;

            // Act
            var result = controller.NewComment(expectedContent, expectedGameId, expectedParentCommentId) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            mock.Verify(a => a.Add(expectedContent, expectedGameId, expectedParentCommentId), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void NewComment_InputIsValidAndParentCommentIdIsNull_AddForRepositoryIsCalledAndRedirectWorks()
        {
            // Arrange
            var mock = new Mock<ICommentRepository>();
            var controller = new CommentController(mock.Object);
            string expectedContent = "test Content";
            int expectedGameId = 7;
            int? expectedParentCommentId = null;

            // Act
            var result = controller.NewComment(expectedContent, expectedGameId, expectedParentCommentId) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            mock.Verify(a => a.Add(expectedContent, expectedGameId, expectedParentCommentId), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void NewComment_InputIsNotCorrect_AddForRepositoryIsCalledAndRedirectWorks()
        {
            //ToDo mb I need to change some logic in controller
            // Arrange
            var mock = new Mock<ICommentRepository>();
            var controller = new CommentController(mock.Object);
            string expectedContent = "";
            int expectedGameId = 7;
            int? expectedParentCommentId = null;

            // Act
            var result = controller.NewComment(expectedContent, expectedGameId, expectedParentCommentId) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            mock.Verify(a => a.Add(expectedContent, expectedGameId, expectedParentCommentId), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
#endregion

    }
}
