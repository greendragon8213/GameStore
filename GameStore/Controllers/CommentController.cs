﻿using System.Web.Mvc;
using GameStore.Data.Abstract;
using GameStore.Data.Concrete;

namespace GameStore.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController()
        {
            _commentRepository = new CommentRepository(new GameStoreDbContext());
        }

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        //
        // GET: /Comment/
        public ActionResult Comments(int gameId)
        {
            ViewBag.GameId = gameId;
            return PartialView();
        }

        public JsonResult GetCommentsByGameId(int gameId)
        {
            var comments = _commentRepository.GetCommentsByGameId(gameId);
            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult NewComment(string content, int gameId, int? parentCommentId)
        {
            _commentRepository.Add(content, gameId, parentCommentId);
            return RedirectToAction("Index", "Games");
        }

    }
}
