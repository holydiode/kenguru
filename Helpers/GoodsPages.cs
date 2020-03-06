using Kenguru_four_.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Kenguru_four_.Helpers
{
    public static class GoodsPages
    {
        public static IOrderedQueryable<Good> SortGoods (IQueryable<Good> Goods, int SortBy)
        {
            switch (SortBy)
            {
                case 1:
                    return Goods.OrderBy(x => x.title);
                case 2:
                    return Goods.OrderByDescending(x => x.title);
                case 11:
                    return Goods.OrderBy(x => x.price);
                case 12:
                    return Goods.OrderByDescending(x => x.price);
                case 21:
                    return Goods.OrderBy(x => x.seles);
                case 22:
                    return Goods.OrderByDescending(x => x.seles);
                case 31:
                    return Goods.OrderBy(x => x.seller.rating);
                case 32:
                    return Goods.OrderByDescending(x => x.seller.rating);
                default:
                    return null;
            }

        }
        public static List<Good> SortGoods(IQueryable<Good> Goods, string search)
        {
            return Goods.AsEnumerable().OrderByDescending(x => CalcCountMatches(x, search)).ToList();
        }
        private static int CalcCountMatches(Good good, string search)
        {
            string[] oneWords = good.title.Split(new char[] { ' ', '.', '/', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
            string[] twoWords = search.Split(new char[] { ' ', '.', '/', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
            return oneWords.Intersect(twoWords).Count();
        }
    }
}