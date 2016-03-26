using System.IO;
using System.Linq;
using System.Web.Mvc;
using GameStore.Data.Abstract;
using GameStore.Data.Concrete;
using GameStore.Model;

namespace GameStore.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameRepository _gameRepository;

        // we have got the loosely coupled objects!
        public GamesController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

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
            var games = _gameRepository.GetAll();//it returns List<Entity.Game>!!
            return Json(games, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? gameId)
        {
            ViewBag.GameId = gameId;
            return View();
        }

        public JsonResult GetById(int gameId)
        {
            var game = _gameRepository.GetById(gameId);//it returns Entity.Game!!
            return Json(game, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Game game)
        {
           _gameRepository.Update(game);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public JsonResult Remove(int gameId)
        {
            _gameRepository.Remove(gameId);
            //return Json(gameId); - test works for Json like that (without Helpers)
            return Json(Url.Action("Index","Games"));
        }

        public ActionResult Download(int gameId)
        {
            //ToDo
            var stream = new StreamReader("theFilePath.bin");
            return File(stream.ReadToEnd(), "bin");
        }

        ////protected override void Dispose(bool disposing)
        ////{
        ////    repo.Dispose();
        ////    base.Dispose(disposing);
        ////}

    }
}
