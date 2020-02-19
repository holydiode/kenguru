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
    }
}