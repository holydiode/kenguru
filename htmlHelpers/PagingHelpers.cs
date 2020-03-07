using Kenguru_four_.Controllers;
using Kenguru_four_.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Kenguru_four_.htmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this AjaxHelper ajax,
         PageInfo pageInfo, Func<int,  string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder tag;

            int startNum = pageInfo.PageNumber >= 5 ? pageInfo.PageNumber - 4 : 1;
            int endNum = startNum + 7 <= pageInfo.TotalPages ? startNum + 7 : pageInfo.TotalPages;

            for (int i = startNum - 2; i <= endNum + 2; i++)
            {
                tag = new TagBuilder("a");
                if (i == startNum - 2)
                {
                    tag.MergeAttribute("href", pageUrl(1));
                    tag.AddCssClass("arrow");
                    tag.InnerHtml = "<<";
                }
                else if (i == startNum - 1)
                {
                    int num = pageInfo.PageNumber - 1;
                    if (num <= 0) num = 1;
                    tag.MergeAttribute("href", pageUrl(num));
                    tag.AddCssClass("arrow");
                    tag.InnerHtml = "<";
                }
                else if (i == endNum + 1)
                {
                    int num = pageInfo.PageNumber + 1;
                    if (num > pageInfo.TotalPages) num = pageInfo.TotalPages;
                    tag.MergeAttribute("href", pageUrl(num));
                    tag.InnerHtml = ">";
                    tag.AddCssClass("arrow");
                }
                else if (i == endNum + 2)
                {
                    tag.MergeAttribute("href", pageUrl(pageInfo.TotalPages));
                    tag.InnerHtml = ">>";
                    tag.AddCssClass("arrow");
                }
                else {
                    tag.MergeAttribute("href", pageUrl(i));
                    tag.InnerHtml = i.ToString();
                }
                // если текущая страница, то выделяем ее,
                // например, добавляя класс
                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn ajax-link btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
   
} 