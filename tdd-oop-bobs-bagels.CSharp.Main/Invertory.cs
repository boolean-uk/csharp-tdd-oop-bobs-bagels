using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Invertory
    {
        public Dictionary<string, decimal> SKUList { get; set; } = new Dictionary<string, decimal>()
        {
            {"BGLO", 0.49M },
            {"BGLP", 0.39M },
            {"BGLS", 0.49M },
            {"BGLE", 0.49M },
            {"COFB", 0.99M },
            {"COFW", 1.19M },
            {"COFC", 1.29M },
            {"COFL", 1.29M },
            {"FILB", 0.12M },
            {"FILE", 0.12M },
            {"FILC", 0.12M },
            {"FILX", 0.12M },
            {"FILS", 0.12M },
            {"FILH", 0.12M }
        };

        public decimal GetPrice(string sku)
        {
            return SKUList.Where(x => x.Key == sku).FirstOrDefault().Value;
        }


        public void AddToShoppingCart(string item, decimal price)
        {
            SKUList.Add(item, price);
        }

       

        //public void AddToShoppingCart()
        //{
        //    //StringBuilder sb = new StringBuilder();
        //    foreach (var price in SKUList)
        //    {
        //        price.Add();
        //    }
        //    return sb;
        //}
    }
}
