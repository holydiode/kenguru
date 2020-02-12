using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kenguru_four_.Controllers
{
    public class HomeController : Controller
    {

        kenguru dataBase = new kenguru();
        public ActionResult Index()
        {
            List<goods> good = dataBase.goods.ToList();//.GetRange(0, 20);
            ViewBag.Goods = good;
            return View();
        }
        
        public ActionResult Goods(int id)
        {
            return View(dataBase.goods.Find(id));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}