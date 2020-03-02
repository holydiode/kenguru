using Kenguru_four_.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenguru_four_.Helpers
{
    public static class GoodsPages
    {
        public static void SetPage(IndexViewModel model, int page)
        {
            int pageSize = model.PageInfo.PageSize;
            var currGoods = model.allGoods;

            //индекс самого верхнего элемента, отображаемого на текущей странице
            int startIndex = (page - 1) * pageSize;
            //количество элементов на текущей странице
            int count = (startIndex + pageSize) < currGoods.Count ? pageSize : currGoods.Count - startIndex;

            model.PageInfo.PageNumber = page;
            model.ViewGoods = model.allGoods.GetRange(startIndex, count);
        }

        public static void SortGoods (List<Good> Goods, int SortBy)
        {
            switch (SortBy)
            {
                case 1:
                    Goods.Sort((x, y) => String.Compare(x.title, y.title));
                    break;
                case 2:
                    Goods.Sort((x, y) => -String.Compare(x.title, y.title));
                    break;
                case 11:
                    Goods.Sort((x, y) => (int)(x.price - y.price));
                    break;
                case 12:
                    Goods.Sort((x, y) => (int)(y.price - x.price));
                    break;
                case 21:
                    Goods.Sort((x, y) => (int)(x.seles - y.seles));
                    break;
                case 22:
                    Goods.Sort((x, y) => (int)(y.seles - x.seles));
                    break;
                case 31:
                    Goods.Sort((x, y) => (int)(x.seller.rating - y.seller.rating));
                    break;
                case 32:
                    Goods.Sort((x, y) => (int)(y.seller.rating - x.seller.rating));
                    break;
            }

        }
    }
}