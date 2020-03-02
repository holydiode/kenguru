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
        public string FindStateOrder(string track)
        {
            KenguruDB db = new KenguruDB();
            var order = db.Orders.Where(x => x.track == track).ToList();
            if (order.Count == 0)
                return "Не найдено";
            switch (order[0].status)
            {
                case (int)StatusOrder.Weit:
                    return "Товар ожидает отправки";
                case (int)StatusOrder.Sent:
                    return "Товар ожидает доставки";
                case (int)StatusOrder.Complit:
                    return "Товар доставлен";
                default:
                    return "А хрен знает";
            }
        }
    }
}