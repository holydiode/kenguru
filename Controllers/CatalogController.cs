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
        private List<Good> currGoods = null;

        private int pageSize = 4;

        public ActionResult Index(int? categoryId = null, int page = 1, int sortBy = 1, string search = null)
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
           
            currGoods = db.goods.Where(x => categoryId == null || x.categoryID == categoryId).ToList();     //запросим товары по категории или все
            //обработка поискового запроса (если он есть)
            if (search != null)
            {
                string[] searchQuery = search.Split(new char[] { ' ', '.', '/', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);

                List<SearchGoodViewModel> curVGoods = new List<SearchGoodViewModel>();
                SearchGoodViewModel.sizeQuer = searchQuery.Count();
                foreach (var item in currGoods)
                {
                    curVGoods.Add(new SearchGoodViewModel(item));
                }
                ViewBag.Title = search;
                ViewBag.InfoTitleLabel = "Результаты по запросу: " + search;
                //массив поисковых запросов
                SearchGoodViewModel cur;
                for (int i = 0; i < curVGoods.Count; i++)
                {
                    cur = curVGoods.ElementAt(i);
                    foreach (var word in cur.words)
                    {
                        foreach (var itemSQ in searchQuery)
                        {
                            if (isEquals(word, itemSQ) == true)
                                cur.countMatches++;
                        }
                    }
                    if (cur.countMatches == 0)
                    {
                        curVGoods.Remove(cur);
                        i--;
                    }
                }

                curVGoods.Sort((x, y) => y.countMatches - x.countMatches);
                currGoods.Clear();
                foreach (var item in curVGoods)
                {
                    currGoods.Add(item.good);
                }
            }
            //сортируем товары
            CatalogViewModel viewModel = new CatalogViewModel           
            {
                PageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = currGoods.Count },
                SortBy = sortBy,
                Search = search,
                allGoods = currGoods,
                CategoryId = categoryId,
            };
            Helpers.GoodsPages.SetPage(viewModel, page);
            TempData["IndexViewModel"] = viewModel;
            return View(viewModel);
        }
        public bool isEquals(string a, string b)
        {
            Regex rg, rgRev;
            rg = new Regex(@b, RegexOptions.IgnoreCase);
            rgRev = new Regex(@a, RegexOptions.IgnoreCase);
            if(rg.Match(a).Length > 1 || rgRev.Match(b).Length > 1)
            return true;
            return false;
        }



    }
}