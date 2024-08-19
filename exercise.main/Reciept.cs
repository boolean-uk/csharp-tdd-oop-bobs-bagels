using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Reciept
    {
        private DateTime _currentDate;
        private TimeSpan _currentTime;
        public void print(List<Product> purchase)
        {
            _currentDate = DateTime.Now;
            _currentTime = TimeSpan.Zero;
            _currentDate.Add(_currentTime);
            printTop();

            printMid(purchase);
        }

        private void printTop()
        {
            Console.WriteLine($"~~~ Bob's Bagels ~~~\n\n{_currentDate}\n\n----------------------------\n\n");
        }

        private void printMid(List<Product> purchase)
        {
            List<Product> setOfItems = new List<Product> ();
            setOfItems.Add(purchase.FirstOrDefault(x => x.SKU.Contains("BGL")));
            setOfItems.Add(purchase.FirstOrDefault(x => x.SKU.Contains("COf")));
            setOfItems.Add(purchase.FirstOrDefault(x => x.SKU.Contains("FIL")));
            //foreach (var item in setOfItems)
            
                //Console.WriteLine(($"{item.name}    {purchase.FindAll(product => product.SKU == item.SKU).Count}    {item.price * purchase.FindAll(product => product.SKU == item.SKU).Count}"));
                setOfItems.ForEach(item => Console.WriteLine($"{item.name}    {purchase.FindAll(product => product.SKU == item.SKU).Count}    {item.price * purchase.FindAll(product => product.SKU == item.SKU).Count}"));
            
        }
    }
}
