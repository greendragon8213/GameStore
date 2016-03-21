using System.IO;
using System.Web.Mvc;
using System.Web.Routing;
using GameStore.Models;

namespace GameStore.Controllers
{
    public class GamesController : Controller
    {
        //
        // GET: /Games/

        public ActionResult Index()
        {
            //var allGames = Game.GetAll();
            return View();
        }

        public JsonResult GetAllGames()
        {
            var games = Game.GetAll();
            return Json(games, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? gameId)
        {
            ViewBag.GameId = gameId;
            return View();
        }

        public JsonResult GetById(int gameId)
        {
            var game = Game.GetById(gameId);
            return Json(game, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Game game)
        {
            Game.Update(game);
            return RedirectToAction("Index");
            //return RedirectToAction("Details", new {gameId = game.Id});
        }
        
        [HttpPost]
        public ActionResult Remove(int gameId)
        {
            Game.Remove(gameId);
            return RedirectToAction("Index");
        }

        public ActionResult Download(int gameId)
        {
            //ToDo
            var stream = new StreamReader("theFilePath.bin");
            return File(stream.ReadToEnd(), "bin");
        }

    }
}
