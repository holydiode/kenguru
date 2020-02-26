﻿using Kenguru_four_.Models;
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


        public ActionResult Report(bool showAll = false, string radius =  "")
        {

            if (Session["User"] == null || ((User)Session["User"]).check() == false)
            {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/auth/enter");
            }

            DateTime TimeFrom;

            if ( string.Compare(radius, "") == 0)
            {
                TimeFrom = DateTime.Today;
            }
            else
            {
                TimeFrom = DateTime.Today;

            }

            TimeFrom = new DateTime(TimeFrom.Year, TimeFrom.Month, 01);
            DateTime TimeTo = new DateTime(TimeFrom.Year, TimeFrom.Month, 01);
            TimeTo = TimeTo.AddMonths(1);

            int CountOrders = 0;
            int CountCash = 0;
            int CountSelles = 0;

            KenguruDB dataBase = new KenguruDB();
            List <GoodReport> reports  = new List<GoodReport>();

            List<Good> goods = dataBase.Sellers.Find(((User)Session["User"]).id).good.ToList();

            foreach(Good good in goods)
            {
                DateTime boop;

                List<Order> orders = good.orders.Where(t => TimeFrom <=  (boop = Convert.ToDateTime(t.time)) && Convert.ToDateTime(t.time) < TimeTo).ToList();

                GoodReport goodReport = new GoodReport(good, 0, 0, 0);

                foreach(Order order in orders)
                {
                    goodReport.orders += 1;
                    goodReport.sell += (int)order.count;
                    goodReport.money += (int)order.price;
                }

                CountOrders += goodReport.orders;
                CountCash += goodReport.money;
                CountSelles += goodReport.sell;

                reports.Add(goodReport);

            }
            ViewBag.MainReport = new GoodReport(null, CountSelles, CountOrders, CountCash);
            ViewBag.AllReport = reports;
            return View();
        }


        public RedirectResult Exit()
        {
            Session["User"] = null;
            return Redirect(Request.Url.GetLeftPart(UriPartial.Authority));
        }

    }
}