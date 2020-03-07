using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenguru_four_.Models.ViewModels
{
    public class CatalogViewModel : IndexViewModel
    {
        public int SortBy { get; set; }
        public string Search { get; set; }
        public int? CategoryId { get; set; }
    }
}