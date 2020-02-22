using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kenguru_four_.Controllers
{
    public class SearchController : Controller
    {
        public int pageSize = 10;
     
        KenguruDB dataBase = new KenguruDB();
        private static string currSearch = "";
        private static List<Good> currGoods = null;


        public ActionResult Index(int page = 1, string search = null, int sortBy = 1)
        {
            foreach(Good god in dataBase.goods)
            {
                god.categoryID = 1;
            }
            dataBase.SaveChanges();
            if (currGoods == null)
                currGoods = dataBase.goods.ToList();
            if (search != null)
            {
                currGoods = dataBase.goods.ToList().Where(t => t.title.ToLower().Contains(search.Trim().ToLower())).ToList();
                currSearch = search;
            }
            SortCurrGoods(sortBy);

            Models.IndexViewModel ivm = null;
            Models.PageInfo pageInfo = new Models.PageInfo { PageNumber = page, PageSize = pageSize, 
                TotalItems = currGoods.Count(), Search = currSearch, sortBy = sortBy };
            
            int startInd = (page - 1) * pageSize;

            List<Good> good = currGoods;

            int count = (startInd + pageSize) < good.Count() ? pageSize : good.Count() - startInd;

            if (startInd <= good.Count)
            {
                good = good.GetRange(startInd, count);
                ivm = new Models.IndexViewModel { PageInfo = pageInfo, Goods = good };
            }

            return View(ivm);
        }
       private void SortCurrGoods(int sortBy)
        {
            switch (sortBy)
            {
                case 1:
                    currGoods.Sort((x, y) => String.Compare(x.title, y.title));
                    break;
                case 2:
                    currGoods.Sort((x, y) => -String.Compare(x.title, y.title));
                    break;
                case 11:
                    currGoods.Sort((x, y) => (int)(x.price - y.price));
                    break;
                case 12:
                    currGoods.Sort((x, y) => (int)(y.price - x.price));
                    break;
                case 21:
                    currGoods.Sort((x, y) => (int)(x.seles - y.seles));
                    break;
                case 22:
                    currGoods.Sort((x, y) => (int)(y.seles - x.seles));
                    break;
                case 31:
                    currGoods.Sort((x, y) => (int)(x.seller.reiting - y.seller.reiting));
                    break;
                case 32:
                    currGoods.Sort((x, y) => (int)(y.seller.reiting - x.seller.reiting));
                    break;
            }
        }
    }
}