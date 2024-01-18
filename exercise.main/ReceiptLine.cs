using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    internal class ReceiptLine
    {
        private int num;
        private AllFillings combination;
        private Item _item;
        private double discount;
        public ReceiptLine(Item item)
        {
            _item = item;
            num = 1;
            combination = item.fillings;
        }

        public void AddProduct()
        {
            num++;
        }

        public string Print()
        {
            if (num == 0) return "";
            string result = PrintProduct() + "\n";
            foreach (Filling filling in combination.Fillings)
            {
                result += "\t +" +filling.Variant;
                result += "\n";
            }
            if (discount > 0)
            {
                result += $"\t\t\t\t\t  (-€{discount})";
            }
            return result;
        }

        public string PrintProduct()
        {
            string name = _item.Variant + " " + _item.Name;
            int letterAmount = name.Count();
            string whiteSpace = "";
            for (int i = letterAmount; i < 20; i++)
                whiteSpace += " ";
            string secondWhiteSpace = "";
            for (int i = num.ToString().Length; i < 4; i++)
                secondWhiteSpace += " ";
            return name + whiteSpace + num + secondWhiteSpace + "€" + (GetPrice());

        }

        /// <summary>
        /// Should return the reduced price by 6 or 12 bagels of the same type without any fillings
        /// </summary>
        /// <returns></returns>
        private float GetPrice()
        {
            return ((_item.Price + combination.TotalPrice()) * num) - (float)GetDiscount() ;
        }

        public double GetDiscount()
        {
            double result = 0;
            int amount = num;
            if (_item.Name == "Bagel" && _item.fillings.Fillings.Count == 0)
            {
                while (amount >= 12)
                {
                    result += 3.99f;
                    amount -= 12;
                }
                if (amount >= 6 && _item.SKU != "BGLP")
                {
                    result += 2.49f;
                    amount -= 6;
                }
                result += (amount * _item.Price);
                return discount = Math.Round((num * _item.Price) - result, 2);
         //       return Math.Round(result, 2);
            }
            return 0;

        }
        
    }
}
