using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Item
    {
        private string name;
        private string type;
        private string nametype;
        private double price;
        private int quantity;
        private List<String> fillings;
        
        public Item(string name, string type, double price, int quantity) 
        {
            this.name = name;
            this.type = type;
            this.nametype = name + " " + type;
            this.price = price;
            this.quantity = quantity;
            this.fillings = new List<String>(); 
        }
        public Item(string name, string type, double price, int quantity, List<string> fillings)
        {
            this.name = name;
            this.type = type;
            this.nametype = name + " " + type;
            this.price = price;
            this.quantity = quantity;
            this.fillings = fillings;
        }

        public string GetName { get { return name; } }

        public string GetType { get { return type; } }

        public string GetNametype { get { return nametype; } }

        public double GetPrice { get { return price; } }

        public int Quantity { get { return quantity; } set { quantity = value; } }

        public List<string> GetFillings { get { return fillings; } }







    }
}