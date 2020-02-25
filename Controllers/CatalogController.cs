using Kenguru_four_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kenguru_four_.Controllers
{
    public class CatalogController : Controller
    {
        KenguruDB db = new KenguruDB();
        private List<Good> currGoods = null;

        private int pageSize = 10;

        public ActionResult Index(int? categoryId = null, int page = 1, int sortBy = 0, string search = null)
        {
            if (categoryId != null)
            {
                Category category = db.Categories.Find(categoryId);

                if (category == null)            //нет такой категории
                    return HttpNotFound();

                if (category.subCategories.Count != 0)          //у категории есть подкатегории, выводим их
                    return View("SubCategories", category);

                ViewBag.Title = ViewBag.InfoTitleLabel =  category.name;
            }

            if(search != null)
            {
                ViewBag.Title = search;
                ViewBag.InfoTitleLabel = "Результаты по запросу: " + search;
            }


            currGoods = db.goods.Where(x => (categoryId == null || x.categoryID == categoryId)
            && (search == null || isSearchable(x, search))).ToList();     //запросим товары по категории или по поиску или все

            int startIndex = (page - 1) * pageSize;
            int count = (startIndex + pageSize) < currGoods.Count ? pageSize : currGoods.Count - startIndex;

            IndexViewModel viewModel = new IndexViewModel           //это все мы отправим в представление
            {
                PageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = currGoods.Count },
                SortBy = sortBy,
                Search = search,
                Goods = currGoods.GetRange(startIndex, count),
                CategoryId = categoryId
            };
            
            viewModel.SortGoods();      //сортируем товары
            return View(viewModel);
        }

        private bool isSearchable(Good good, string search)
        {
            return true;
        }



    }
}