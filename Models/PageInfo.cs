using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenguru_four_.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages   // всего страниц
        {
            get
            {
                float res = (TotalItems) / PageSize;
                if (TotalItems % PageSize != 0)
                    res += 1;
                return (int)res;
            }
        }

    }
    public class IndexViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Good> Goods { get; set; }
        public int SortBy { get; set; }
        public string Search { get; set; }
        public int? CategoryId { get; set; }
        public void SortGoods()
        {
            switch (SortBy)
            {
                case 0: //сортировка по коефу
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
                    Goods.Sort((x, y) => (int)(x.seller.reiting - y.seller.reiting));
                    break;
                case 32:
                    Goods.Sort((x, y) => (int)(y.seller.reiting - x.seller.reiting));
                    break;
            }
        }

    }

    //представление товара с коэффициентом его ролевантности запросу
    public class ViewGood 
    {
        public ViewGood(Good god) { 
            good = god;
            words = good.title.Split(new char[] { ' ', '.', '/', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public Good good { get; set; }
    
        //переопределение метода сравнения по совпалению товара запросу
        //для того, чтобы можно было отсортировать 
     
        //количество соответсвий товара поисковым запросам
        public int countMatches = 0;
        public static int sizeQuer;
        public string[] words;
        
    }
}