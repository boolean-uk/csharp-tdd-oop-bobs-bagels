using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class BasketItem : Item
    {
        public BasketItem(string name, string type, double price, int quantity)
            : base(name, type, price, quantity) { }

        public BasketItem(string name, string type, double price, int quantity, List<string> fillings)
            : base(name, type, price, quantity, fillings) { }
    }
}