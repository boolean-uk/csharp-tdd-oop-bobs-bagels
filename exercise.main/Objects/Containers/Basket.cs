using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Core;

namespace exercise.main.Objects.Containers
{
    public class Basket : PObject
    {
        List<Ware> _contentsInBasket = new List<Ware>();
        private static int _basketSizeLimit = 50;

        public int BasketSizeMax { get => _basketSizeLimit; }
        public int BasketSize { get => _contentsInBasket.Capacity; }

        public List<Ware> Contents { get => _contentsInBasket; set => _contentsInBasket = value; }

        public Basket()
        {
            _contentsInBasket.Capacity = _basketSizeLimit;
        }

        public bool AddProduct(Ware ware)
        {
            if (ware == null)
                return false;
            if (_contentsInBasket.Count() + 1 > _basketSizeLimit)
                return false;

            _contentsInBasket.Add(ware);
            return true;
        }
        public bool AddProduct(Ware ware, uint amount)
        {
            if (ware == null)
                return false;
            if (_contentsInBasket.Count() + amount > _basketSizeLimit)
                return false;

            for(int i = 0; i < amount; i++)
                _contentsInBasket.Add(ware);

            return true;
        }

        public double GetPriceTotal()
        {
            double sum = 0;

            foreach (var item in _contentsInBasket)
                sum += item.GetPrice();

            return sum;
        }

        public bool RemoveProduct(Ware ware)
        {
            if(ware == null || !_contentsInBasket.Contains(ware)) return false;
            
            _contentsInBasket.Remove(ware);
            return true;
        }

        protected internal bool AlterSize(int newSize)
        {
            if (newSize < 0 || newSize > _basketSizeLimit)
                return false;

            _basketSizeLimit = newSize;
            return true;
        }
    }
}
