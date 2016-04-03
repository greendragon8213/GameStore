using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using GameStore.BusinesLogic.BLModels;
using GameStore.BusinesLogic.Services.Interfaces;
using GameStore.Models;

namespace GameStore.Controllers.MVC_Task2
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly ICommentService _commentService;

        public GameController(IGameService gameService, ICommentService commentService)
        {
            _gameService = gameService;
            _commentService = commentService;
        }

        #region 1.New
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(GameWebModel game)
        {
            if (!ModelState.IsValid)
                return View(game);

            _gameService.Create(Mapper.Map<GameWebModel, GameBLModel>(game));

            return RedirectToAction("Games");
        }
        #endregion

        #region 2.Game
        [HttpGet]
        public ViewResult Game(int gameId)
        {
            var game = Mapper.Map<GameWebModel>(_gameService.GetById(gameId));

            return View(game);
        }
        #endregion

        #region 3.Comments
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ViewResult Comments(int gameId)
        {
            var comments = Mapper.Map<IEnumerable<CommentWebModel>>(_commentService.GetCommentsTreeByGameId(gameId));
            ViewBag.GameId = gameId;
            return View(comments);
        }

        [HttpGet]
        public ActionResult NewComment(int gameId, int? parentCommentId)
        {
            ViewBag.GameId = gameId;
            ViewBag.ParentCommentId = parentCommentId;
            return PartialView();
        }
        [HttpPost]
        public ActionResult NewComment(int gameId, CommentWebModel comment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.GameId = gameId;
                ViewBag.ParentCommentId = comment.ParentCommentId;
                return PartialView(comment);
            }

            _commentService.AddNewComment(comment.Body, gameId, comment.ParentCommentId, comment.Name);

            return RedirectToAction("Comments", new { gameId });
        }

        #endregion

        #region Games
        [HttpGet]
        public ActionResult Games()
        {
            var list = Mapper.Map<IEnumerable<GameWebModel>>(_gameService.GetAllGames());

            return View(list);
        }
        #endregion

        #region Update/Remove/Download
        [HttpPost]
        public ActionResult Update(GameWebModel game)
        {
            _gameService.Update(Mapper.Map<GameWebModel, GameBLModel>(game));

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult Remove(int gameId)
        {
            _gameService.Remove(gameId);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpGet]
        public ActionResult Download(int gameId)
        {
            //ToDo
            var stream = new StreamReader("theFilePath.bin");
            return File(stream.ReadToEnd(), "bin");
        }

        #endregion
    }
}
