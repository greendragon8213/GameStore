using System.Web.Mvc;
using AutoMapper;
using GameStore.BusinesLogic.BLModels;
using GameStore.BusinesLogic.Services.Interfaces;
using GameStore.Models;

namespace GameStore.Controllers.MVC_Task2
{
    public class BusketController : Controller
    {
        private readonly IOrderService _orderService;

        public BusketController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //
        // GET: /Busket/
        public ActionResult Index()
        {
            var order = (OrderWebModel)Session["Order"];
            if (order == null)
            {
                order = new OrderWebModel();
                Session["Order"] = order;
            }

            return View(order);
        }

        public ActionResult Buy()
        {
            var order = (OrderWebModel)Session["Order"];
            _orderService.Add(Mapper.Map<OrderBLModel>(order));

            Session["Order"] = null;

            return RedirectToAction("Games", "Game");
        }

    }
}
