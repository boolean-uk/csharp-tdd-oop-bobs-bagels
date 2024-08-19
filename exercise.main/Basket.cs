using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Product> _productList { get; set; } = new List<Product>();


        //adds item to list if there is room
        public bool Add(Product product)
        {
            Inventory inventory = new Inventory();

            //ugly but works
            if (_productList.Count < MaxCapacity && inventory.Products.Find(p => p.SKU == product.SKU).SKU == product.SKU) 
            {
                _productList.Add(product);
                return true;
            }

            //add max cap check
            return false;
        }

        //better add method for filling and stuff

        public decimal GetTotalCost()
        {
            decimal totalCost = 0M;

            foreach(Product Product in _productList)
            {
                totalCost += Product.Price;
            }

            return totalCost;      
        }

        public bool Remove(Product removableItem)
        {
            if (_productList.Contains(removableItem))
            {
                _productList.Remove(removableItem);
                return true;
            }

            return false;
        }

        public void PrintReceipt()
        {

            List<Product> uniqueProduct = _productList.Distinct().ToList();


            Console.WriteLine("    ~~~ Bob's Bagels ~~~    ");
            Console.WriteLine("");
            Console.WriteLine($"   {DateTime.Now}");
            Console.WriteLine($"");
            Console.WriteLine($"----------------------------");
            Console.WriteLine($"");

            int numOfItems = 0;
            decimal totalCost = 0;
            //Loop that prints items in basket
            foreach(Product p in uniqueProduct)
            {
                numOfItems = _productList.Where(prod => p.SKU == prod.SKU).Count();
                Console.WriteLine($"{p.Variant} {p.Name}\t{numOfItems}\t{p.Price * (numOfItems)}$");
                totalCost += p.Price;
            }

            Console.WriteLine($"");
            Console.WriteLine($"----------------------------");
            Console.WriteLine($"Total\t\t\t{totalCost}$");
            Console.WriteLine($"        Thank you        ");
            Console.WriteLine($"      for your order!      ");
            
        }

        public int MaxCapacity { get; set; } = 10;
        

        public List<Product> ProductList { get { return _productList; } }

        public int totalCost { get; set; }

    
    }
}
