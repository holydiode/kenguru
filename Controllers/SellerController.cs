using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kenguru_four_.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller
        public ActionResult Index()
        {
            if (Session["User"] == null) {
                return RedirectPermanent(Request.Url.GetLeftPart(UriPartial.Authority) + "/Auth/Enter");
            }
            
            if(!((User)Session["User"]).check())
            {
                return RedirectPermanent(Request.Url.GetLeftPart(UriPartial.Authority) + "/Auth/Enter");
            }

            return View();

        }

        public ActionResult Orders()
        {
            if( Session["User"] == null || ((User)Session["User"]).check() == false)
            {
                return RedirectPermanent(Request.Url.GetLeftPart(UriPartial.Authority) + "/Auth/Enter");
            }

            KenguruDB dataBase = new KenguruDB();

            List<Good> goods = dataBase.Sellers.Find(((User)Session["User"]).id).good.ToList();

            List<Order> orderses = dataBase.Orders.ToList();

            List<Order> orders = new List<Order>();

            foreach( Good good in goods)
            {
                if (good.orders != null)
                {
                    orders.AddRange(good.orders);
                }
            }

            ViewBag.Orders = orders;

            return View();
        }
    }
}