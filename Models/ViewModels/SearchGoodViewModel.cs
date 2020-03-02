using System;

namespace Kenguru_four_.Models
{
    //представление товара с коэффициентом его релевантности запросу
    public class SearchGoodViewModel 
    {
        public SearchGoodViewModel(Good god) { 
            good = god;
            words = good.title.Split(new char[] { ' ', '.', '/', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public Good good { get; set; }
    
        //переопределение метода сравнения по совпалению товара запросу
        //для того, чтобы можно было отсортировать 
     
        //количество соответсвий товара поисковым запросам
        public int countMatches = 0;
        public static int sizeQuer;
        public string[] words;

    }
}