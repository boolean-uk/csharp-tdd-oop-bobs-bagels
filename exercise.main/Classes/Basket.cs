using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Classes.Products;

namespace exercise.main.Classes
{
    public class Basket
    {
        private List<Product> Products;
        private int Capacity;

        public Basket()
        {
            Products = new List<Product>();
            Capacity = 5;
        }

        public void AddProduct()
        {

        }

        public void RemoveProduct()
        {

        }

        public void Clear()
        {
            Console.WriteLine($"Cleared {Products.Count} bagels from basket!");
            Products.Clear();
        }

        public bool IsFull()
        {
            Console.WriteLine("Basket it full!");
            return Products.Count >= Capacity;
        }

        public List<Product> GetProducts() { return Products; }

        public void ChangeCapacity(int newCapacity) { Capacity = newCapacity; }
    }
}
