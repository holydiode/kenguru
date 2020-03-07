using Kenguru_four_.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kenguru_four_.Controllers
{
    public class SellerStoreController
        : Controller
    {
        // GET: SellersStore
        public ActionResult Index(int sellerId, int page = 1)
        {
            KenguruDB db = new KenguruDB();
            Seller seller = db.Sellers.Find(sellerId);
            var goods = db.goods.Where(x => (x.sellerID == sellerId)).OrderBy(x => x.seles);

            SellersGoodsViewModel sellersGoods = new SellersGoodsViewModel
            {
                Seller = seller,
                PageInfo = new PageInfo
                {
                    PageNumber = page,
                    PageSize = 2,
                    TotalItems = goods.Count()
                },
                 AppropriateGoods = goods
            };
            sellersGoods.ViewGoods = goods.Skip((page - 1) * 10).Take(10).ToList();
            ViewBag.Title = ViewBag.InfoTitleLabel = "Витрина " + seller.name;
            TempData["IndexViewModel"] = sellersGoods;
            return View(sellersGoods);
        }
    }
}