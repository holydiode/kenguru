using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenguru_four_.Models.ViewModels
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages   // всего страниц
        {
            get {
                float res = (TotalItems) / PageSize;
                if (TotalItems % PageSize != 0)
                    res += 1;
                return (int)res;
            }
        }

    }
}