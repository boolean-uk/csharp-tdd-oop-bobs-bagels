using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Bagel : Item
    {
        private string v1;
        private double v2;

        public Bagel(string name, float price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void GetItemCost()
        {
            throw new NotImplementedException();
        }
    }
}