using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kenguru_four_.Controllers
{
    public class GoodController : Controller
    {
        // GET: Good
        public ActionResult Index(int id)
        {
            KenguruDB db = new KenguruDB();
            return View(db.goods.Find(id));
        }
    }
}