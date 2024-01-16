using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Item
    {
        protected float price;
        protected string name;
        protected string variant;
        protected string SKU;
        protected int id;
        public int ID { get { return id; } }
        public float Price { get { return price; } }
        public string Name { get { return name; } }


        public Item()
        {
            id = IDGenerator.GetID();
        }
        public virtual void AddFilling(string SKU)
        { }

        public virtual float TotalPrice()
        {
            return price;
        }
    }
}
