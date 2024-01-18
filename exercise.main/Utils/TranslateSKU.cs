using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Utils
{
    public static class TranslateSKU
    {
        private static Dictionary<string, Tuple<string, string>> _inventoryNames = new Dictionary<string, Tuple<string, string>>
        {
            { "BGLO", new Tuple<string, string>("Bagel", "Onion") },
            { "BGLP", new Tuple<string, string>("Bagel", "Plain") },
            { "BGLE", new Tuple<string, string>("Bagel", "Everything") },
            { "BGLS", new Tuple<string, string>("Bagel", "Sesame") },
            { "COFB", new Tuple<string, string>("Coffee", "Black") },
            { "COFW", new Tuple<string, string>("Coffee", "White") },
            { "COFC", new Tuple<string, string>("Coffee", "Capuccino") },
            { "COFL", new Tuple<string, string>("Coffee", "Latte") },
            { "FILB", new Tuple<string, string>("Filling", "Bacon") },
            { "FILE", new Tuple<string, string>("Filling", "Egg") },
            { "FILC", new Tuple<string, string>("Filling", "Cheese") },
            { "FILX", new Tuple<string, string>("Filling", "Cream Cheese") },
            { "FILS", new Tuple<string, string>("Filling", "Smoked Salmon") },
            { "FILH", new Tuple<string, string>("Filling", "Ham") },
        };

        /// <summary>
        /// Translate a provided SKU into the associated name and variant for the item. Name indicate category (i.e. Bagel) while variant indicate subcategory (i.e. Egg)
        /// </summary>
        /// <param name="SKU"> The SKU to translate into human readable format </param>
        /// <returns> Tuple<string, string> where value1 is the name and value2 is the variant. If null/invalid SKU a tuple of <"Invalid", "Invalid"> is returned. </returns>
        public static Tuple<string, string> GetNameAndVariantFromSKU(string SKU) 
        {
            return _inventoryNames.GetValueOrDefault(SKU, new Tuple<string, string>("Invalid", "Invalid"));
        }
    }
}
