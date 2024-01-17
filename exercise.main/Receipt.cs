using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        Basket _basket;
        DateTime _createdAt;
        Dictionary<string, ReceiptLine> list = new Dictionary<string, ReceiptLine>();

        public Receipt(Basket basket)
        {
            _basket = basket;
            _createdAt = DateTime.Now;
            FillList();
            Print();
        }
        private void FillList()
        {
            
            foreach(Item product in _basket.Inventory)
            {
                
                
                //If product already exists in list:
                if (list.ContainsKey(product.SKU))
                {
                    list[product.SKU].AddProduct(product.fillings);
                }
                
                //Product doesn't exists in list:
                else
                {
                    string name = product.Variant + " " + product.Name;
                    ReceiptLine receiptLine = new ReceiptLine(name, product.Price, product.fillings);
                    list.Add(product.SKU, receiptLine);
                }
                     
            }
            
        }

        private void Print()
        {
            Console.WriteLine($"~~~ Bob's Bagels ~~~ \n\n {_createdAt} \n\n ------------------------\n ");
            foreach (KeyValuePair<string, ReceiptLine> line in list)
            {
                Console.WriteLine(line.Value.Print());
            }
            Console.WriteLine($"\n------------------------\nTotal             €{_basket.TotalCost()} \n\n \t  Thank you \n   for your order! ");
        }
    }
}
