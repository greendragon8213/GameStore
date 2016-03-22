using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore.Models;
using Newtonsoft.Json;

namespace GameStore.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/

        public ActionResult Comments(int gameId)
        {
            ViewBag.GameId = gameId;
            return PartialView();
        }

        public JsonResult GetCommentsByGameId(int gameId)
        {
            var comments = Comment.GetCommentsByGameId(gameId);
            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult NewComment(string content, int gameId, int? parentCommentId)
        {
            Comment.Add(content, gameId, parentCommentId);
            return RedirectToAction("Index", "Games");
            //return RedirectToAction("Comments", new {gameId = gameId});
        }

    }
}
