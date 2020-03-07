using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenguru_four_.Models.ViewModels
{
    public class IndexViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Good> ViewGoods { get; set; }
        public IQueryable<Good> AppropriateGoods { get; set; }
    }
}