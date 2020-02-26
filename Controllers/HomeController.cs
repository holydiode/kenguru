using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kenguru_four_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            KenguruDB db = new KenguruDB();
            db.goods.Add(new Good { title = "Носки без дырок", categoryID = 7, sellerID = -3, short_discribe = "", count = 2, description = "", price = 100, seles = 1 });
            db.goods.Add(new Good { title = "Носки с кошками", categoryID = 7, sellerID = -3, short_discribe = "", count = 2, description = "", price = 700, seles = 1 });
            db.goods.Add(new Good { title = "Носки с дырками и с кошками", categoryID = 7, sellerID = -3, short_discribe = "", count = 2, description = "", price = 350, seles = 1 });
            db.goods.Add(new Good { title = "Носки как носки может с дырками", categoryID = 7, sellerID = -3, short_discribe = "", count = 2, description = "", price = 400, seles = 1 });
            db.goods.Add(new Good { title = "Носки для богатых", categoryID = 7, sellerID = -3, short_discribe = "", count = 2, description = "", price = 3000, seles = 1 });
            db.SaveChanges();
            return View(db);
        }
    }
}