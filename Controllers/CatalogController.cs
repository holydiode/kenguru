using Kenguru_four_.Models;
using Kenguru_four_.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Kenguru_four_.Controllers
{
    public class CatalogController : Controller
    {
        KenguruDB db = new KenguruDB();
        private IQueryable<Good> appropriateGoods = null;
        private int pageSize = 10;


        public ActionResult Index(int? categoryId = null, int page = 1, int sortBy = 0, string search = null)
        {
            appropriateGoods = db.goods;
            CatalogViewModel viewModel = new CatalogViewModel
            {
                PageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = 0 },
                SortBy = sortBy,
                Search = search,
                CategoryId = categoryId,
            };
            //обработка категории, если она запрашивается
            if (categoryId != null)
            {
                Category category = db.Categories.Find(categoryId);

                if (category == null)            //нет такой категории
                    return HttpNotFound();
                if (category.subCategories.Count != 0)          //у категории есть подкатегории, выводим их
                    return View("SubCategories", category);

                appropriateGoods = db.goods.Where(x => x.categoryID == categoryId); //запросим товары по категории
                ViewBag.Title = ViewBag.InfoTitleLabel = category.name;
            }
            if(search != null)
            {
                ViewBag.Title = ViewBag.InfoTitleLabel = "Результаты по запросу \"" + search + "\"";
            }

            //выберем набор для текущей страницы
            int startIndex = (page - 1) * pageSize;

            //если есть поисковый запрос
            if (sortBy == 0)
                appropriateGoods = Helpers.GoodsPages.SortGoods(appropriateGoods, search).AsQueryable();
            else
                appropriateGoods = Helpers.GoodsPages.SortGoods(appropriateGoods, sortBy);
            viewModel.ViewGoods = appropriateGoods.Skip(startIndex).Take(pageSize).ToList();

            viewModel.AppropriateGoods = appropriateGoods;
            viewModel.PageInfo.TotalItems = appropriateGoods.Count();

            TempData["IndexViewModel"] = viewModel;
            return View(viewModel);
        }
        public bool isEquals(string a, string b)
        {
            Regex rg, rgRev;
            rg = new Regex(@b, RegexOptions.IgnoreCase);
            rgRev = new Regex(@a, RegexOptions.IgnoreCase);
            if (rg.Match(a).Length > 1 || rgRev.Match(b).Length > 1)
                return true;
            return false;
        }




    }
}