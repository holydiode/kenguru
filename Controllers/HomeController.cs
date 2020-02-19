using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Kenguru_four_.Controllers
{
    public class HomeController : Controller
    {
        public int pageSize = 50;
     
        kenguru dataBase = new kenguru();

        public ActionResult Index(int page = 1, string search = "")
        {

            Models.IndexViewModel ivm = null;
            Models.PageInfo pageInfo = new Models.PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = dataBase.goods.Count() };

            int startInd = (page - 1) * pageSize;
            List<goods> good = dataBase.goods.ToList();
            int count = (startInd + pageSize) < good.Count() ? pageSize : good.Count() - startInd;

            if (startInd <= good.Count)
            {
                ViewBag.Goods = good;
                ivm = new Models.IndexViewModel { PageInfo = pageInfo, Goods = good };
            }

            return View(ivm);
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