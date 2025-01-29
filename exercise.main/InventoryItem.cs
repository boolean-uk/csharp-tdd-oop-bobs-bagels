using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class InventoryItem : Item
    {
        public InventoryItem(string name, string type, double price, int quantity)
            : base(name, type, price, quantity) { }
    }
}