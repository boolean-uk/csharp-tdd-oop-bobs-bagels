using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class BobsInventory
    {
        private Dictionary<SKUEnum, StockItem> _inventory = new Dictionary<SKUEnum, StockItem>
        {
            {SKUEnum.BGLO, new StockItem(SKUEnum.BGLO, 0.49, "Bagel",  "Onion")},
            {SKUEnum.BGLP, new StockItem(SKUEnum.BGLP, 0.39, "Bagel",  "Plain")},
            {SKUEnum.BGLE, new StockItem(SKUEnum.BGLE, 0.49, "Bagel",  "Everything")},
            {SKUEnum.BGLS, new StockItem(SKUEnum.BGLS, 0.49, "Bagel",  "Sesame")},
            {SKUEnum.COFB, new StockItem(SKUEnum.COFB, 0.99, "Coffee",  "Black")},
            {SKUEnum.COFW, new StockItem(SKUEnum.COFW, 1.19, "Coffee",  "White")},
            {SKUEnum.COFC, new StockItem(SKUEnum.COFC, 1.29, "Coffee",  "Capuccino")},
            {SKUEnum.COFL, new StockItem(SKUEnum.COFL, 1.29, "Coffee",  "Latte")},
            {SKUEnum.FILB, new StockItem(SKUEnum.FILB, 0.12, "Filling", "Bacon")},
            {SKUEnum.FILE, new StockItem(SKUEnum.FILE, 0.12, "Filling", "Egg")},
            {SKUEnum.FILC, new StockItem(SKUEnum.FILC, 0.12, "Filling", "Cheese")},
            {SKUEnum.FILX, new StockItem(SKUEnum.FILX, 0.12, "Filling", "Cream Cheese")},
            {SKUEnum.FILS, new StockItem(SKUEnum.FILS, 0.12, "Filling", "Smoked Salmon")},
            {SKUEnum.FILH, new StockItem(SKUEnum.FILH, 0.12, "Filling", "Ham")}
        };

        // NOTE: keep a dictionary that maps strings to their SKU value, for fastest lookup
        private Dictionary<string, SKUEnum> _variantToSKU = new Dictionary<string, SKUEnum>
        {
            { "Onion", SKUEnum.BGLO },
            { "Plain", SKUEnum.BGLP },
            { "Everything", SKUEnum.BGLE },
            { "Sesame", SKUEnum.BGLS },
            { "Black", SKUEnum.COFB },
            { "White", SKUEnum.COFW },
            { "Capuccino", SKUEnum.COFC },
            { "Latte", SKUEnum.COFL },
            { "Bacon", SKUEnum.FILB },
            { "Egg", SKUEnum.FILE },
            { "Cheese", SKUEnum.FILC },
            { "Cream Cheese", SKUEnum.FILX },
            { "Smoked Salmon", SKUEnum.FILS },
            { "Ham", SKUEnum.FILH }
        };


        public SKUEnum VariantToSKU(string variant)
        {
            return _variantToSKU.ContainsKey(variant) ? _variantToSKU[variant] : SKUEnum.NONE;
        }

        public StockItem GetStockItem(string variant)
        {
            return _inventory.Values.FirstOrDefault(i => i.Variant == variant);
        }

        public double GetCostOfSKU(SKUEnum sku)
        {
            return _inventory[sku].Price;
        }

        public Dictionary<SKUEnum, StockItem> Inventory { get => _inventory; }
    }
}