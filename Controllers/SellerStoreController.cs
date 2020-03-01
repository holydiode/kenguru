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
            var goods = db.goods.Where(x => (x.sellerID == sellerId)).ToList();

            goods.Sort((x, y) => y.seles - x.seles);        //сортируем товары по количеству продаж

            SellersGoodsViewModel sellersGoods = new SellersGoodsViewModel
            {
                allGoods = goods,
                Seller = seller,
                PageInfo = new Models.PageInfo
                {
                    PageNumber = page,
                    PageSize = 2,
                    TotalItems = goods.Count
                }
            };
            Helpers.GoodsPages.SetPage(sellersGoods, page);

            ViewBag.Title = ViewBag.InfoTitleLabel = "Витрина " + seller.name;
            TempData["IndexViewModel"] = sellersGoods;
            return View(sellersGoods);
        }
    }
}