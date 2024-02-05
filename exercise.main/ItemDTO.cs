using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class ItemDto
    { 
        public string Sku { get; set; }
        public double Price { get; set; }

        public string Variant { get; set; }

        public string Name { get; set; }

        public ItemDto(string sku, double price, string variant, string name)
        {
            Sku = sku;
            Price = price;
            Variant = variant;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ItemDto other = (ItemDto)obj;
            return Sku == other.Sku && Price == other.Price && Variant == other.Variant;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Sku, Price, Variant);
        }
    }

}
