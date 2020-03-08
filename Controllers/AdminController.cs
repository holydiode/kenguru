using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kenguru_four_.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/auth/admin");
            }
            Admin admin = (Admin)Session["Admin"];
            if (admin.check() == false || admin.permitions == 0)
            {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/auth/admin");
            }

            if (admin.PermitionDecode.GrestinRight)
            {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/admin/orders");
            }

            return View();
        }


        public ActionResult Orders()
        {

            if (Session["Admin"] == null)
            {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/auth/admin");
            }

            Admin admin = (Admin)Session["Admin"];

            if (admin.check() == false || admin.PermitionDecode.GrestinRight == false)
            {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/auth/admin");
            }

            KenguruDB dataBase = new KenguruDB();

            ViewBag.Orders = dataBase.Orders.Where(t => t.status !=  (int)StatusOrder.NotPai && t.status != (int)StatusOrder.Complit).ToList();

            return View();
        }

        public ActionResult Seller()
        {

            if (Session["Admin"] == null)
            {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/auth/admin");
            }

            Admin admin = (Admin)Session["Admin"];

            if (admin.check() == false || admin.PermitionDecode.ObserverRight == false)
            {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/auth/admin");
            }

            KenguruDB dataBase = new KenguruDB();
            ViewBag.Sellers = dataBase.Sellers.ToList();


            return View();
        }


        public ActionResult Break()
        {
            return View();
        }

        public RedirectResult Exit()
        {
            Session["Admin"] = null;
            return Redirect(Request.Url.GetLeftPart(UriPartial.Authority));
        }

    }
}