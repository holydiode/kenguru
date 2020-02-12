using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kenguru_four_.Controllers
{
    public class HomeController : Controller
    {
        public int PageSize = 5;
        public int PageNumber = 2;
     
        kenguru dataBase = new kenguru();
        public ActionResult Index()
        {
            int startInd = (PageNumber - 1) * PageSize;
            if (startInd <= dataBase.goods.Count())
            {
                int count = (startInd + PageSize) < dataBase.goods.Count() ?  PageSize : dataBase.goods.Count() - startInd;
                List<goods> good = dataBase.goods.ToList().GetRange(startInd, count);
                ViewBag.Goods = good;
            }

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