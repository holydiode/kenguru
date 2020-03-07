using Kenguru_four_.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kenguru_four_.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult GoodsPages(int page)
        {
            IndexViewModel model = (IndexViewModel)TempData["IndexViewModel"];
            model.ViewGoods = model.AppropriateGoods.Skip((page - 1) * 10).Take(10).ToList();
            model.PageInfo.PageNumber = page;
            TempData["IndexViewModel"] = model;
            return PartialView("~/Views/Partial/GoodsPages.cshtml",model);
        }
        public ActionResult SortGoodsPages(int sortBy)
        {
            IndexViewModel model = (IndexViewModel)TempData["IndexViewModel"];
            model.AppropriateGoods = Helpers.GoodsPages.SortGoods(model.AppropriateGoods, sortBy);
            TempData["IndexViewModel"] = model;
            return GoodsPages(1);
        }
    }
}