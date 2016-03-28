using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using AutoMapper;
using GameStore.BusinesLogic.BLModels;
using GameStore.BusinesLogic.Services.Interfaces;
using GameStore.Models;

namespace GameStore.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public GamesController()
        {
        }

        //
        // GET: /Games/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllGames()
        {
            var games =_gameService.GetAllGames();
            return Json(Mapper.Map<IEnumerable<GameWebModel>>(games), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? gameId)
        {
            ViewBag.GameId = gameId;
            return View();
        }

        public JsonResult GetById(int gameId)
        {
            var game = _gameService.GetById(gameId);
            return Json(Mapper.Map<GameWebModel>(game), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(GameWebModel game)
        {
            _gameService.Update(Mapper.Map<GameBLModel>(game));
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public JsonResult Remove(int gameId)
        {
            _gameService.Remove(gameId);
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
