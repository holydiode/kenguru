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
        kenguru dataBase = new kenguru();
        
        // GET: Cart
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
     
        public RedirectToRouteResult AddToCart(int godId, string returnUrl)
        {
            goods god = dataBase.goods.FirstOrDefault(g => g.id == godId);
            if(god != null) {
                GetCart().AddItem(god, 1);
            }
            return RedirectToAction("index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(int godId, string returnUrl)
        {
            goods god = dataBase.goods.FirstOrDefault(g => g.id == godId);
            if (god != null)
            {
                GetCart().RemoveLine(god);
            }
            return RedirectToAction("index", new { returnUrl });
        }
        //использует средства состояния сеанса
        public Cart GetCart()
        {
            //извлекаем объект из состояния сеанса, если мы положили его туда раньше
            Cart cart = (Cart)Session["Cart"];
            if(cart == null)
            {
                //добавляем оьбъект в состояние сеанса
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}