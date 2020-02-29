using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenguru_four_
{
    public class GoodReport
    {
        public Good good { set; get;}
        public int sell{set; get;}
        public int orders{set; get;}

        public int money { set; get;}

        public GoodReport(Good good, int sell, int orders, int money)
        {
            this.good = good;
            this.sell = sell;
            this.orders = orders; 
            this.money = money;
        }

    }
}