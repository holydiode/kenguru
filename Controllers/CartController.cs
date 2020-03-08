using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kenguru_four_.Models;

namespace Kenguru_four_.Controllers
{
    public class CartController : Controller
    {
        KenguruDB dataBase = new KenguruDB();
        
        // GET: Cart
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                cart = cart,
                ReturnUrl = returnUrl
            });
        }

     [HttpPost]
        public RedirectToRouteResult AddToCart(Cart cart, int id, string returnUrl)
        {
            Good god = dataBase.goods.FirstOrDefault(g => g.id == id);
            if(god != null) {
                cart.AddItem(god, 1);
            }
            return RedirectToAction("index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            Good god = dataBase.goods.FirstOrDefault(g => g.id == id);
            if (god != null)
            {
                cart.RemoveLine(god);
            }
            return RedirectToAction("index", new { returnUrl });
        }
       
        //рисует на всех страницах инфу о корзине
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        //
        public ViewResult OrderDetails (Cart cart, OrderDetails ordDetails)
        {
            //обработка на пустую корзину
            if(cart == null || cart.Lines.Count() == 0)
                return View("~/Views/ErrorPageView.cshtml");

            if (ModelState.IsValid)
            {
                //преобразоваие товаров из корзины в заказы, отправка всего на бд и в кассу
                KenguruDB dB = new KenguruDB();
                foreach (var item in cart.Lines)
                {
                    //текущее время определяется до цикла, чтобы оно было одинаково для всех заказов
                    string curTime = DateTime.Now.ToString();
                    //поменять потом на нормальный
                    int curTrack = curTime.GetHashCode();
                    dB.Orders.Add(new Order
                    {
                        adress = ordDetails.Adresss,
                        count = item.Quantity,
                        email = ordDetails.email,
                        goodID = item.good.id,
                        phone = ordDetails.phone,
                        price = item.good.price,
                        status = (int?)StatusOrder.NotPai,
                        time = curTime,
                        track = curTrack.ToString(),
                    });

                    
                }
                dB.SaveChanges();


                return View("CompleteOrderView");
            }
            return View(new OrderDetails());

        }
    }
}