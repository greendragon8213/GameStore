using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using GameStore.BusinesLogic.Services.Interfaces;
using GameStore.Models;

namespace GameStore.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController()
        {
        }

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        //
        // GET: /CommentWebModel/
        public ActionResult Comments(int gameId)
        {
            ViewBag.GameId = gameId;
            return PartialView();
        }

        public JsonResult GetCommentsByGameId(int gameId)
        {
            var comments = _commentService.GetCommentsTreeByGameId(gameId);
            return Json(Mapper.Map<IEnumerable<CommentWebModel>>(comments),
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult NewComment(string content, int gameId, int? parentCommentId)
        {
            _commentService.AddNewComment(content, gameId, parentCommentId);
            return RedirectToAction("Index", "Games");
        }

    }
}
