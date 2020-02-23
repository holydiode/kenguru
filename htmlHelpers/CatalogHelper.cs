using Kenguru_four_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kenguru_four_.htmlHelpers
{
    public static class CatalogHelper
    {
        public static object NewValues(IndexViewModel model, int? categoryId = null, int? page = null, int? sortBy = null, string search = null)
        {
            if (page == null)
                page = model.PageInfo.PageNumber;
            if (categoryId == null)
                categoryId = model.CategoryId;
            if (search == null)
                search = model.Search;
            if (sortBy == null)
                sortBy = model.SortBy;
            return new { categoryId, page, sortBy, search };
        }
        public static string GetParametrName(int sortBy)
        {
            string result;
            switch (sortBy)
            {
                case 1:
                    result = "Наименование ▼";
                    break;
                case 2:
                    result = "Наименование ▲";
                    break;
                default:
                    result = "Наименование";
                    break;
            }
            return result;
        }
        public static string GetParametrPrice(int sortBy)
        {
            string result;
            switch (sortBy)
            {
                case 11:
                    result = "Стоимость ▼";
                    break;
                case 12:
                    result = "Стоимость ▲";
                    break;
                default:
                    result = "Стоимость";
                    break;
            }
            return result;
        }

        public static string GetParametrCount(int sortBy)
        {
            string result;
            switch (sortBy)
            {
                case 21:
                    result = "Количество товара ▼";
                    break;
                case 22:
                    result = "Количество товара ▲";
                    break;
                default:
                    result = "Количество товара";
                    break;
            }
            return result;
        }
        public static string GetParametrRating(int sortBy)
        {
            string result;
            switch (sortBy)
            {
                case 31:
                    result = "Рейтинг продавца ▼";
                    break;
                case 32:
                    result = "Рейтинг продавца ▲";
                    break;
                default:
                    result = "Рейтинг продавца";
                    break;
            }
            return result;
        }
    }
}