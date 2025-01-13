using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Discount;

namespace exercise.main
{

    public interface IStoreFront
    {
        
        Inventory inventory{ get; set; }
        DiscountManager discountManager{ get; set; }
        Basket basket { get; set; }
        void presentProducts();
        void presentDeals();
        void addToBasket(string skuu, int amount = 1);
        void removeFromBasket(string sku, int amount = 1);
        void showBasket();
        void run();
        void exit();
    }

    public class TerminalStoreFront : IStoreFront
    {
        public TerminalStoreFront(Inventory inventory, Basket basket, DiscountManager discountManager)
        {
            this.inventory = inventory;
            this.basket = basket;
            this.discountManager = discountManager;
            
        }
        public delegate void basketOpFunc(string sku, int amount);

        public Inventory inventory  {get; set;}
        public Basket    basket     { get; set; }
        public DiscountManager discountManager { get; set; }

        public void addToBasket(string sku, int amount = 1 )
        {
            basket.addProduct(sku, amount);
        }

        public void presentDeals()
        {
            Console.WriteLine("Deals: ---------------------------------");
            Console.Write(discountManager.stringify());
            Console.WriteLine("----------------------------------------\n");
        }

        public void presentProducts()
        {
            Console.WriteLine("Menu: ----------------------------------");
            Console.Write(inventory.stringify());
            Console.WriteLine("----------------------------------------");
        }

        public void removeFromBasket(string sku, int amount = 1)
        {
            basket.removeProduct(sku, amount);
        }

        public void showBasket()
        {
            Console.WriteLine("\nBasket: --------------------------------");
            Console.WriteLine(basket.stringify(discountManager));
            Console.WriteLine("----------------------------------------");
        }
        public void exit()
        {
            throw new NotImplementedException();
        }
        public void run()
        {

            basketOpFunc addTo = new basketOpFunc(addToBasket);
            basketOpFunc remFrom = new basketOpFunc(removeFromBasket);

            string exitCommand = "/q";
            string userInput = "";
            while (exitCommand != userInput)
            {
                presentDeals();
                presentProducts();
                if (basket.isNotEmpty())
                {
                    showBasket();
                }
                userInput = Console.ReadLine();
                Console.Clear();

                var args = userInput.Split(" ");
                if (args.Length > 0)
                {

                    CheckPrefromBasketOp(args, "/add", addTo);
                    CheckPrefromBasketOp(args, "/rem", remFrom);

                }
            }

        }
        void CheckPrefromBasketOp(string[] args, string commandWord,basketOpFunc f)
        {
            if (args[0].ToLower() == commandWord)
            {
                if (args.Length >= 3)
                {
                    int parsed = 0;
                    if (int.TryParse(args[2], out parsed))
                    {
                        f(args[1].ToUpper(), parsed);
                    }
                }
                else
                {
                    f(args[1].ToUpper(), 1);
                }
            }
        }
    }
    public class StoreFrontExecutor
    {
        IStoreFront storeFront;
        public StoreFrontExecutor(IStoreFront storeFront)
        {
            this.storeFront = storeFront;
        }

        public void run()
        {
            storeFront.run();
        }

    }

    public abstract class BaseProduct
    {
        protected string name;
        private string sku;
        protected float productPrice;
        protected List<BaseProduct> subProducts;
        //protected ProductType productType;
        //public BaseProduct(string SKU,string name, float defaultPrice, ProductType productType, List<BaseProduct>? subProducts = null)
        public BaseProduct(string SKU,string name, float defaultPrice, List<BaseProduct>? subProducts = null)
        {            
            this.sku = SKU;
            this.name = name;
            this.productPrice = defaultPrice;
            this.subProducts = subProducts ?? new List<BaseProduct>();
            //this.productType = productType;
        }
        public float CombinedPrice
        {
            get { return this.productPrice + subProducts.Sum(x => x.CombinedPrice); }
        }
        public float ProductPrice
        {
            get { return this.productPrice; }
        }
        public string ProductName
        {
            get { return this.name; }
        }

        public string SKU { get => sku;}
    }

    public class Product: BaseProduct
    {
        public Product(string SKU, string name, float defaultPrice,List<BaseProduct>? subProducts = null)
            : base(SKU, name, defaultPrice, subProducts)
        {
        }
    }




}
