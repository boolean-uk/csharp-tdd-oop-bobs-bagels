using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Item
    {
        List<Filling> fillings = new List<Filling>();
        public Bagel(string type)
        {
            SKU = type;
            name = "Bagel";
            switch (type)
            {
                case "BGLO":
                    variant = "Onion";
                    price = 0.49f;
                    break;
                case "BGLP":
                    variant = "Plain";
                    price = 0.39f;
                    break;
                case "BGLE":
                    variant = "Everything";
                    price = 0.49f;
                    break;
                case "BGLS":
                    variant = "Sesame";
                    price = 0.49f;
                    break;
                default: 
                    variant = "";
                    price = 0.49f;
                    break;
            }

        }

        public override float TotalPrice()
        {
            float fillingPrice = 0;
            foreach (Filling item in fillings)
            {
                fillingPrice += item.Price;
            }
            return price + fillingPrice;
        }
        public override void AddFilling(string SKU)
        {
            Filling filling = new Filling(SKU);
            fillings.Add(filling);
        }
    }
}
