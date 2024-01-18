using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Core;
using exercise.main.Objects.Containers;

namespace exercise.main.Objects.People
{
    public class Person : PObject
    {
        public Basket Basket = new Basket();
        protected List<Ware> _inventory = new List<Ware>();

        public double money = 200;


        public bool AddToBasket(Ware ware)
        {
            if (ware == null) return false;

            Basket.Contents.Add(ware);
            return true;
        }
        public bool AddToBasket(List<Ware> wares)
        {
            if (wares.Any(x => x == null))
                return false;

            foreach (Ware ware in wares)
            {
                Basket.Contents.Add(ware);
            }
            return true;
        }
        public bool RemoveFromBasket(Ware ware)
        {
            if (ware == null)
                return false;

            return Basket.Contents.Remove(ware);
        }


        public bool AddToInventory(Ware ware)
        {
            if (ware == null) return false;

            _inventory.Add(ware);
            return true;
        }
        public bool AddToInventory(List<Ware> wares)
        {
            if(wares.Any(x => x == null))
                return false;

            foreach(Ware ware in _inventory)
            {
                _inventory.Add(ware);
            }
            return true;
        }
        public bool RemoveFromInventory(Ware ware)
        {
            if (ware == null) 
                return false;

            return _inventory.Remove(ware);
        }
    }
}
