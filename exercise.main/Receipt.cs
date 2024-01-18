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
        double discount = 0;

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
                if (list.ContainsKey(product.SKU + product.fillings.ToString()))
                {
                    list[product.SKU + product.fillings.ToString()].AddProduct();
                }
                
                //Product doesn't exists in list:
                else
                {
                    ReceiptLine receiptLine = new ReceiptLine(product);
                    list.Add(product.SKU + product.fillings.ToString(), receiptLine);
                }
                     
            }
            
        }

        private void Print()
        {
            Console.WriteLine($"~~~ Bob's Bagels ~~~ \n\n {_createdAt} \n\n ------------------------\n ");
            foreach (KeyValuePair<string, ReceiptLine> line in list)
            {
                Console.WriteLine(line.Value.Print());
                discount += line.Value.GetDiscount();
            }
            Console.WriteLine($"------------------------\nTotal             €{Math.Round(_basket.TotalCost() - discount, 2)}");
            if (discount > 0)
                Console.WriteLine($"You saved a total of €{discount} \n on this shop");
            Console.WriteLine($" \n \t  Thank you \n   for your order! ");
        }
    }
}
