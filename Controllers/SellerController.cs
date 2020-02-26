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

            List<Order> orders = new List<Order>();

            foreach( Good good in goods)
            {
                if (good.orders != null)
                {
                    orders.AddRange(good.orders.Where(t => t.status != (int)StatusOrder.NotPai  &&  t.status != (int)StatusOrder.Cancel ));
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

            if (order == null || order.good.sellerID != ((User)Session["User"]).id || order.status == (int)StatusOrder.Cancel || order.status == (int)StatusOrder.NotPai) {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/seller/orders");
            }

            ViewBag.Order = order;

            return View();
        }

        //постаить защиту на одмина
        public RedirectResult OrdederStatusChange(int IdOrder = -1, int newStatus = (int)StatusOrder.Cancel)
        {
            if (Session["User"] == null || ((User)Session["User"]).check() == false)
            {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/auth/enter");
            }

            KenguruDB dataBase = new KenguruDB();
            Order order = dataBase.Orders.Find(IdOrder);

            if (order == null || order.good.sellerID != ((User)Session["User"]).id ||  !this.DefenceStatusChange( order.status ,newStatus) )
            {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/seller/orders");
            }

            order.status = newStatus;
            dataBase.SaveChanges();

            return Redirect(Url.Action(Url.Content("~/orderinfo"), new { IdOrder = order.id }));
        }

        private bool DefenceStatusChange(int? oldStatus, int newStatus)
        {
            if(oldStatus == (int)StatusOrder.Weit )
            {
                if (newStatus == (int)StatusOrder.Cancel)
                {
                    return (true);
                }
                if (newStatus == (int)StatusOrder.Sent)
                {
                    return (true);
                }
            }
            if(oldStatus == (int)StatusOrder.Sent)
            {
                if (newStatus == (int)StatusOrder.Weit)
                {
                    return (true);
                }
            }
            return false;
        }





        public RedirectResult Exit()
        {
            Session["User"] = null;
            Session.Abandon();
            return Redirect(Request.Url.GetLeftPart(UriPartial.Authority));
        }
    }
}