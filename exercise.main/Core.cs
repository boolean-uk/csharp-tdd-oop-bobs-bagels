using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    /*
    internal class Core
    {
    }
    */

    public class Store
    {
        public bool ChangeBasketSize(bool isManager)
        {
            throw new NotImplementedException();
        }

        public bool IsProductInInventory(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class Person
    {
        private Basket _basket;
        public Basket Basket { get { return _basket; } set { _basket = value;  } }

        private bool _isManager;
        public bool IsManager { get { return _isManager; } set { _isManager = value; } }

        public Person(Basket basket = null, bool isManager = false)
        {
            Basket = basket;
            IsManager = isManager;
        }

        public bool IsProductInInventory(string v)
        {
            throw new NotImplementedException();
        }

        public bool ChangeBasketSize()
        {
            throw new NotImplementedException();
        }
    }

    public class Basket
    {
        public bool AddProduct(string v)
        {
            throw new NotImplementedException();
        }

        public int CheckCurrentCapacity()
        {
            throw new NotImplementedException();
        }

        public double CheckTotalCost()
        {
            throw new NotImplementedException();
        }

        public bool IsProductInBasket(string v)
        {
            throw new NotImplementedException();
        }

        public bool RemoveProduct(string v)
        {
            throw new NotImplementedException();
        }

        public int TotalCapacity()
        {
            throw new NotImplementedException();
        }
    }

    //Abstract or Interface? Abstract... perchance
    public abstract class Product
    {
        private string _sku;
        public string SKU { get { return _sku; } set { _sku = value; } }
        public Product(string sKU)
        {
            SKU = sKU;
        }

        public virtual double CheckPriceOfProduct()
        {
            throw new NotImplementedException();
        }
    }

    public class Bagel : Product
    {
        public Bagel(string sKU) : base(sKU)
        {
            
        }
        public bool ChooseFilling(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class Coffee : Product
    {
        public Coffee(string sKU) : base(sKU)
        {
            
        }
    }

    public class Filling : Product
    {
        public Filling(string sKU) : base(sKU)
        {
            
        }
    }
}
