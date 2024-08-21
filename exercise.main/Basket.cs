﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<InventoryItem> _Basket = new List<InventoryItem>();

        private BobsInventory BobsInventory = new BobsInventory();

        private StringBuilder _receipt = new StringBuilder();

        private int _capacity = 5;

        private string _variant;

        private int BagelCount;

        private int CoffeeCount;
        


        private StringBuilder AddToReceipt() 
        {
            _receipt.AppendLine("~~~ Bob's Bagels ~~~");
            _receipt.AppendLine();
            _receipt.AppendLine(DateTime.Now.ToString());
            _receipt.AppendLine();
            _receipt.AppendLine("--------------------------");
            _receipt.AppendLine();

            int amount = 0;

            foreach (var item in _Basket.Distinct()) 
            {
                amount = _Basket.Where(x => x.Variant == item.Variant).Count();
                _receipt.AppendLine($"{item.Variant} {item.Name}\t{amount} £ {amount * item.Price}");
                
            }

            _receipt.AppendLine();
            _receipt.AppendLine("--------------------------");

            _receipt.AppendLine($"Total             £ {TotalCost}");
            _receipt.AppendLine();
            _receipt.AppendLine();
            _receipt.AppendLine("Thank you for your order!");
            

            return _receipt;
            
        }
        

        public bool AddItem(string variant)
        {
            _variant = variant;

            if (!IsInInventory) 
            {
                return false;
            }

            if (!IsBasketFull && IsInInventory)
            {
                _Basket.Add(BobsInventory._Bobsinventory.First(item => item.Variant == variant));
                return true;
            }
            return false;

        }

        public bool RemoveItem(string variant)
        {
            _variant = variant;

            if (IsInBasket) 
            {
                _Basket.Remove(_Basket.First(item => item.Variant == variant));
                return true;
            }
            return false;
        }

        public bool ChangeCapacity(int capacity, bool isManager)
        {
            if (isManager) 
            { 
                _capacity = capacity;
                return true;
            }
            return false;
        }

        public double GetSpecialOffer()
        {

            foreach(var item in _Basket)
            {
                BagelCount = _Basket.Where(item => item.Name == "Bagel").Count();
                CoffeeCount = _Basket.Where(item => item.Name == "Coffee").Count();
            }

            if (BagelCount == 12)
            {
                return BobsInventory.TwelveBagelDiscount;
            }
            else if (BagelCount == 6)
            {
                return BobsInventory.SixBagelDiscount;
            }
            else if(BagelCount == CoffeeCount)
            {
                return BobsInventory.CoffeeAndBagel * BagelCount;
            }
            else return TotalCost;

            
            
        }

        public int BasketCapacity { get { return _capacity; } set { _capacity = value; } }

        public bool IsBasketFull { get { return _Basket.Count >= BasketCapacity ? true : false; } }

        public bool IsInBasket { get { return _Basket.Any(item => item.Variant == _variant); } }

        public bool IsInInventory { get { return BobsInventory._Bobsinventory.Any(item => item.Variant == _variant); } }

        public double TotalCost { get { return _Basket.Sum(item => item.Price); } }

        public string PrintReceipt { get { return AddToReceipt().ToString(); } }
    }
}
