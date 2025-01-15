using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Products;

namespace exercise.main.Baskets
{
    public class DiscountRule
    {
        public readonly Dictionary<Type, int> ProductQuantities;
        public readonly double DiscountPrice;

        public static readonly Dictionary<Type, List<string>> TypeToSkus = new Dictionary<Type, List<string>>
        {
            { typeof(Bagel), new List<string> { "BGLE", "BGLO", "BGLP", "BGLS" } },
            { typeof(Coffee), new List<string> { "COFE", "COFW", "COFC", "COFL"} }
        };

        public DiscountRule(Dictionary<Type, int> productQuantities, double discountPrice)
        {
            ProductQuantities = productQuantities;
            DiscountPrice = discountPrice;         
        }
    }
}
