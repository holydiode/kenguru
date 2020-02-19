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

        private int pageSize = 2;
        private static string currSearch = "";
        private static List<goods> currGoods = null;


        public ActionResult Index(int page = 1, string search = null)
        {
            if (currGoods == null)
                currGoods = dataBase.goods.ToList();
            if (search != null)
            {
                currGoods = dataBase.goods.ToList().Where(t => t.title.ToLower().Contains(search.Trim().ToLower())).ToList();
                currSearch = search;
            }

            Models.IndexViewModel ivm = null;
            Models.PageInfo pageInfo = new Models.PageInfo { PageNumber = page, PageSize = pageSize, 
                TotalItems = currGoods.Count(), Search = currSearch };
            
            int startInd = (page - 1) * pageSize;

            List<goods> good = currGoods;

            int count = (startInd + pageSize) < good.Count() ? pageSize : good.Count() - startInd;

            if (startInd <= good.Count)
            {
                good = good.GetRange(startInd, count);
                ivm = new Models.IndexViewModel { PageInfo = pageInfo, Goods = good };
            }

            return View(ivm);
        }
       
        public ActionResult Goods(int id)
        {
            return View(currGoods.Find((good)=>good.id == id));
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