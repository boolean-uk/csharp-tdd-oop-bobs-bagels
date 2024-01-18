using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class Inventory
    {
        public static Dictionary<SKU, Product> skuToProduct = new Dictionary<SKU, Product>
        {
            { SKU.BGLO, new Product("Bagel", 0.49d, "Onion") },
            { SKU.BGLP, new Product("Bagel", 0.39d, "Plain") },
            { SKU.BGLE, new Product("Bagel", 0.49d, "Everything") },
            { SKU.BGLS, new Product("Bagel", 0.49d, "Sesame") },
            { SKU.COFB, new Product("Coffee",0.99d,  "Black") },
            { SKU.COFW, new Product("Coffee",1.19d,  "White") },
            { SKU.COFC, new Product("Coffee",1.29d,  "Cappuccino") },
            { SKU.COFL, new Product("Coffee",1.29d,  "Latte") },
            { SKU.FILB, new Product("Filling", 0.12d, "Bacon") },
            { SKU.FILE, new Product("Filling", 0.12d, "Egg") },
            { SKU.FILC, new Product("Filling", 0.12d, "Cheese") },
            { SKU.FILX, new Product("Filling", 0.12d, "Cream Cheese") },
            { SKU.FILS, new Product("Filling", 0.12d, "Smoked Salmon") },
            { SKU.FILH, new Product("Filling", 0.12d, "Ham") }
        };

        public static Dictionary<SKU, Func<Product>> skuToProductFactory = new Dictionary<SKU, Func<Product>>
        {
            { SKU.BGLO, () => new Product("Bagel", 0.49d, "Onion") },
            { SKU.BGLP, () => new Product("Bagel", 0.39d, "Plain") },
            { SKU.BGLE, () => new Product("Bagel", 0.49d, "Everything") },
            { SKU.BGLS, () => new Product("Bagel", 0.49d, "Sesame") },
            { SKU.COFB, () => new Product("Coffee",0.99d,  "Black") },
            { SKU.COFW, () => new Product("Coffee",1.19d,  "White") },
            { SKU.COFC, () => new Product("Coffee",1.29d,  "Cappuccino") },
            { SKU.COFL, () => new Product("Coffee",1.29d,  "Latte") },
            { SKU.FILB, () => new Product("Filling", 0.12d, "Bacon") },
            { SKU.FILE, () => new Product("Filling", 0.12d, "Egg") },
            { SKU.FILC, () => new Product("Filling", 0.12d, "Cheese") },
            { SKU.FILX, () => new Product("Filling", 0.12d, "Cream Cheese") },
            { SKU.FILS, () => new Product("Filling", 0.12d, "Smoked Salmon") },
            { SKU.FILH, () => new Product("Filling", 0.12d, "Ham") }
        };
        public static Dictionary<string, SKU> variantToSku = new Dictionary<string, SKU>
        {
            { "Onion", SKU.BGLO },
            { "Plain", SKU.BGLP },
            { "Everything", SKU.BGLE },
            { "Sesame", SKU.BGLS },
            { "Black", SKU.COFB },
            { "White", SKU.COFW },
            { "Cappuccino", SKU.COFC },
            { "Latte", SKU.COFL },
            { "Bacon", SKU.FILB },
            { "Egg", SKU.FILE },
            { "Cheese", SKU.FILC },
            { "Cream Cheese", SKU.FILX },
            { "Smoked Salmon", SKU.FILS },
            { "Ham", SKU.FILH }
        };
    }

    public enum SKU
    {
        BGLO, // Bagel Onion
        BGLP, // Bagel Plain
        BGLE, // Bagel Everything
        BGLS, // Bagel Sesame
        COFB, // Coffee Black
        COFW, // Coffee White
        COFC, // Coffee Cappuccino
        COFL, // Coffee Latte
        FILB, // Filling Bacon
        FILE, // Filling Egg
        FILC, // Filling Cheese
        FILX, // Filling Cream Cheese
        FILS, // Filling Smoked Salmon
        FILH  // Filling Ham
    }
}
