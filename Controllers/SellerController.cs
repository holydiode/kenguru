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
            if (Session["User"] == null || ((User)Session["User"]).check() == false) {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/auth/enter");

            }

            KenguruDB dataBase = new KenguruDB();

            ViewBag.User = dataBase.Sellers.Find(((User)Session["User"]).id);
            return View();
        }

        public ActionResult Property()
        {
            if (Session["User"] == null || ((User)Session["User"]).check() == false)
            {

                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/Auth/Enter");
            }
            return View();
        }


        public ActionResult Orders()
        {
            if( Session["User"] == null || ((User)Session["User"]).check() == false )
            {

                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/Auth/Enter");
            }

            KenguruDB dataBase = new KenguruDB();

            ViewBag.User = dataBase.Sellers.Find(((User)Session["User"]).id);

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

        public ActionResult OrderInfo(int IdOrder = -1)
        {
            if (Session["User"] == null || ((User)Session["User"]).check() == false)
            {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/auth/enter");
            }

            KenguruDB dataBase = new KenguruDB();

            Order order = dataBase.Orders.Find(IdOrder);

            if (order == null || order.good.sellerID != ((User)Session["User"]).id) {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/seller/orders");
            }

            ViewBag.Order = order;

            return View();
        }



        public RedirectResult Exit()
        {
            Session["User"] = null;
            Session.Abandon();
            return Redirect(Request.Url.GetLeftPart(UriPartial.Authority));
        }
    }
}