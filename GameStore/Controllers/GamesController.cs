using System.IO;
using System.Web.Mvc;
using System.Web.Routing;
using GameStore.Data.Concrete;
using GameStore.Model;

namespace GameStore.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameRepository _gameRepository;

        public GamesController()
        {
            _gameRepository = new GameRepository(new GameStoreDbContext());
        }

        //
        // GET: /Games/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllGames()
        {
            var games = _gameRepository.GetAll();
            return Json(games, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? gameId)
        {
            ViewBag.GameId = gameId;
            return View();
        }

        public JsonResult GetById(int gameId)
        {
            var game = _gameRepository.GetById(gameId);//ToDo game type!!!!
            return Json(game, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Game game)
        {
           // _gameRepository.Update(game);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult Remove(int gameId)
        {
            _gameRepository.Remove(gameId);
            return Json(Url.Action("Index","Games"));
        }

        public ActionResult Download(int gameId)
        {
            //ToDo
            var stream = new StreamReader("theFilePath.bin");
            return File(stream.ReadToEnd(), "bin");
        }

    }
}
