using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenguru_four_.Models
{
    public class CartIndexViewModel
    {
        public Cart cart { get; set; }
        //ссылка, по которой "продолжают покупки"
        public String ReturnUrl { get; set; }
    }
}