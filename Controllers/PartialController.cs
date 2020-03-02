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
            Helpers.GoodsPages.SetPage(model, page);
            TempData["IndexViewModel"] = model;
            return PartialView(model);
        }
    }
}