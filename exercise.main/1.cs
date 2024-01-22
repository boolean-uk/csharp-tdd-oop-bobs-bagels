using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Products;

namespace exercise.main
{
    public class Basket
    {
        public Basket()
        {
            _productList = new List<InventoryProduct>();
            _capacity = 5;
        }
        

        private int _capacity;
        private List<InventoryProduct> _productList;
        public double TotalDiscount = 0;

        public bool AddProduct(InventoryProduct product)
        {
            
             if (_productList.Count >= _capacity)
               {
                   return false;

               }else {
                   _productList.Add(product);
                   return true;
               }
       
        }

        public bool RemoveProduct(int BasketID)
        {
//bool productIsInBasket = _productList(BasketID);
  //          if (productIsInBasket) { 
   //         _productList.Remove(BasketID);
                return true;
            }

  //          return false;
        }


        public double GetTotal()
        {
            addDiscounts();
            double sum=0;
            double sumFillings = 0;
            foreach (Product product in _productList.Values) { 
    //            sum += product.Price - product.discount;
     //           sumFillings += product.Fillings.Count * 0.12;
            }
            sum= Math.Round(sum, 2);

            return sum;
        }
        public void addDiscounts()
        {
            Dictionary<int, Product> bagels = new Dictionary<int, Product>();
            Dictionary<int, Product> coffees = new Dictionary<int, Product>();
            Dictionary<int, Product> plainBagels = new Dictionary<int, Product>();
            
            foreach (int key in _productList.Keys)
            {
                if ((_productList[key].Name == "Bagel"))
                {
                    bagels.Add(key, _productList[key]);

                }
                else if (_productList[key].SKU != "BGLP")
                {
                    plainBagels.Add(key, _productList[key]);
                }
                else if ((_productList[key].SKU != "COFB"))
                {
                    coffees.Add(key, _productList[key]);
                }

                if (bagels.Count % 12 == 0)
                {
                    foreach (int keyid in bagels.Keys)
                    {
       //                 ProductList[keyid].discount = ProductList[keyid].Price - 0.3325d;
        //                TotalDiscount += ProductList[keyid].discount;
                    }
                }
                else if (bagels.Count % 6 == 0)
                {
                    foreach (int keyid in bagels.Keys)
                    {
        //                ProductList[keyid].discount = 0.075;
        //                TotalDiscount += ProductList[keyid].discount;
                    }

                }
                else
                {
                    int modulusTwelve = bagels.Count % 12;
                    int modulusSix = modulusTwelve % 6;
                    int coffeCount = coffees.Values.Count;
                    
                    while(0 < coffeCount){
                        if(modulusSix > 0)
                        {
            //            ProductList[0].discount += 0.23d;
                        TotalDiscount += 0.23d;

                        }

                        modulusSix--;
                        coffeCount--;
                    }


                }

            }

        }
       
        public int changeCapacity(Person person, int newCapacity)
        {
            if (person.AdminLevel=="admin")
            {
                _capacity = newCapacity;
            }
            return _capacity;
        }


        public int Capacity { get => _capacity; }
        public List<InventoryProduct> ProductList { get => _productList; set => _productList; }



    }
}
