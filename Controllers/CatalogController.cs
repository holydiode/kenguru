using Kenguru_four_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Kenguru_four_.Controllers
{
    public class CatalogController : Controller
    {
        KenguruDB db = new KenguruDB();
        private List<Good> currGoods = null;

        private int pageSize = 10;

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

                List<ViewGood> curVGoods = new List<ViewGood>();
                ViewGood.sizeQuer = searchQuery.Count();
                foreach (var item in currGoods)
                {
                    curVGoods.Add(new ViewGood(item));
                }
                ViewBag.Title = search;
                ViewBag.InfoTitleLabel = "Результаты по запросу: " + search;
                //массив поисковых запросов
                ViewGood cur;
                for (int i = 0; i < curVGoods.Count; i++)
                {
                    cur = curVGoods.ElementAt(i);
                    foreach (var word in cur.words)
                    {
                        foreach (var itemSQ in searchQuery)
                        {
                            if (word == itemSQ)
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
            


            //индекс самого верхнего элемента, отображаемого на текущей странице
            int startIndex = (page - 1) * pageSize;
            //количество элементов на текущей странице
            int count = (startIndex + pageSize) < currGoods.Count ? pageSize : currGoods.Count - startIndex;
            //это все мы отправим в представление
            IndexViewModel viewModel = new IndexViewModel           
            {
                PageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = currGoods.Count },
                SortBy = sortBy,
                Search = search,
                Goods = currGoods.GetRange(startIndex, count),
                CategoryId = categoryId
            };
            //сортируем товары
            viewModel.SortGoods();      
            return View(viewModel);
        }




    }
}