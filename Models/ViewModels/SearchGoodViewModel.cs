using System;

namespace Kenguru_four_.Models
{
    //представление товара с коэффициентом его релевантности запросу
    public class SearchGoodViewModel 
    {
        public SearchGoodViewModel(Good good) { 
            this.good = good;
            words = good.title.Split(new char[] { ' ', '.', '/', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public Good good { get; set; }
    
        //переопределение метода сравнения по совпалению товара запросу
        //для того, чтобы можно было отсортировать 
     
        //количество соответствий товара поисковым запросам
        public int countMatches = 0;
        public static int sizeQuery;
        public string[] words;

    }
}