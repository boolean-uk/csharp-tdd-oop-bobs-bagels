using System;
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


        private double GetSpecialOffer()
        {

            List<InventoryItem> tempBasket = new List<InventoryItem>();
            tempBasket.AddRange(_Basket);

            double totalwithDiscount = 0;


            foreach (var item in tempBasket)
            {
                BagelCount = tempBasket.Where(item => item.Name == "Bagel").Count();
                CoffeeCount = tempBasket.Where(item => item.Name == "Coffee").Count();
            }


            while (BagelCount >= 12)
            {
                totalwithDiscount += BobsInventory.TwelveBagelDiscount;

                for(int i = 0; i < 12; i++)
                {
                    InventoryItem removeBagel = tempBasket.First(item => item.Name == "Bagel");
                    tempBasket.Remove(removeBagel);
                }

                BagelCount -= 12;
                
            }

            while (BagelCount >= 6)
            {
                totalwithDiscount += BobsInventory.SixBagelDiscount;

                for (int i = 0; i < 6; i++)
                {
                    InventoryItem removeBagel = tempBasket.First(item => item.Name == "Bagel");
                    tempBasket.Remove(removeBagel);
                }

                BagelCount -= 6;
                
            }
            
            while(BagelCount >= 1 && CoffeeCount >= 1)
            {

                totalwithDiscount += BobsInventory.CoffeeAndBagel;

                InventoryItem removeBagel = tempBasket.First(item => item.Name == "Bagel");
                InventoryItem removeCoffee = tempBasket.First(item => item.Name == "Coffee");
                tempBasket.Remove(removeBagel);
                tempBasket.Remove(removeCoffee);
                BagelCount --;
                CoffeeCount --;
                
            }

            return totalwithDiscount + tempBasket.Sum(item => item.Price);
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


        public int BasketCapacity { get { return _capacity; } set { _capacity = value; } }

        public bool IsBasketFull { get { return _Basket.Count >= BasketCapacity ? true : false; } }

        public bool IsInBasket { get { return _Basket.Any(item => item.Variant == _variant); } }

        public bool IsInInventory { get { return BobsInventory._Bobsinventory.Any(item => item.Variant == _variant); } }

        public double TotalCost { get { return _Basket.Sum(item => item.Price); } }

        public string PrintReceipt { get { return AddToReceipt().ToString(); } }

        public double TotalCostWithDiscount { get { return GetSpecialOffer(); } }
    }
}
