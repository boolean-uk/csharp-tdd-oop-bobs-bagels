using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket { 

        public List<Product> products { get; } = new List<Product>();
        private int capacity = 3;

        public bool Add(Product product)
        {
            if (products.Count >= capacity) return false;
            products.Add(product); 
            return true;
        }

        public bool Remove(Product product)
        {
            if ( !products.Contains(product) ) return false;
            products.Remove(product);
            return true;
        }

        public void ChangeCapacity(int v)
        {
            capacity = (v < 0 ? capacity : v);
        }

        public double TotalCost()
        {
            return products.Sum(x => x.GetPrice());
        }

        public string Prices()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Bagel:");
            Bagel bagel = new Bagel(BagelType.Everything);
            foreach (BagelType type in Enum.GetValues(typeof(BagelType)))
            {
                sb.AppendLine($"{type}: {bagel.bagelToInfo[type].price}");
            }

            sb.AppendLine("Coffee:");
            Coffee coffee = new Coffee(CoffeeType.Capuccino);
            foreach ( CoffeeType type in Enum.GetValues(typeof(CoffeeType)) )
            {
                sb.AppendLine($"{type}: {coffee.coffeToInfo[type].price}");
            }

            sb.AppendLine("Fillings:");
            foreach (FillingType type in Enum.GetValues(typeof(FillingType)))
            {
                sb.AppendLine($"{type}: {0.12d}");
            }
            return sb.ToString();
        }
    }
}
