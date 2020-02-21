using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//корзина (продуктовая)
namespace Kenguru_four_.Models
{
    //сама корзина
    public class Cart
    {
        public List<CartLine> addedLines = new List<CartLine>();
        //добавление товара в корзину
        public void AddItem(Good god, int quantity)
        {
            //ищем, есть ли сейчас этот товар в корзине
            CartLine line = addedLines.Where(g => g.good.id == god.id).FirstOrDefault();
            if(line == null)
            {
                addedLines.Add(new CartLine
                { good = god, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        //удаление товара из корзины
        public void RemoveLine(Good god)
        {
            addedLines.RemoveAll(l => l.good.id == god.id);
        }
        //сумма всех товаров в корзине
        public decimal ComputeTotalValue()
        {
            return addedLines.Sum(e => (int)e.good.price * e.Quantity);
        }
        //очистить корзину
        public void Clear()
        {
            addedLines.Clear();
        }
        public IEnumerable<CartLine> Lines { get { return addedLines; } }
    }
    //определеят выбранный товар и его количество для каждой позиции в корзине
    public class CartLine
    {
        public Good good { get; set; }
        public int Quantity { get; set; }
    }
}