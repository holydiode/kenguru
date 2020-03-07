using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kenguru_four_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            KenguruDB db = new KenguruDB();
            return View(db);
        }

        public ActionResult CheckStateOrder()
        {
            return View();
        }
        public ActionResult FindStateOrder(string track)
        {
            KenguruDB db = new KenguruDB();
            var order = db.Orders.Where(x => x.track == track).ToList();
            if (order.Count == 0) 
                return  Content("Заказ с данным трек-номером не найден");
            return View("~/Views/Partial/OrderInfo.cshtml", order);
        }
    }
}