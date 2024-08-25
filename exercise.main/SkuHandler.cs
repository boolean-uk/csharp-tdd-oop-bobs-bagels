using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class SkuHandler
    {
        public static Dictionary<string, float> SkuDecoder(string sku)
        //decodes SKU into Name, Price. Adds Name Price into a dictionary and returns
        {
            Dictionary<string, float> value = new() { };

            string type = sku.Substring(0, 4);
            switch (type)
            {
                case "BGLO":
                    value.Add("Onion Bagel", 0.49f);
                    break;

                case "BGLP":
                    value.Add("Plain Bagel", 0.39f);
                    break;

                case "BGLE":
                    value.Add("Everything Bagel", 0.49f);
                    break;

                case "BGLS":
                    value.Add("Sesame Bagel ", 0.49f);
                    break;

                case "COFB":
                    value.Add("Black Coffee ", 0.99f);
                    break;

                case "COFW":
                    value.Add("White Coffee ", 1.19f);
                    break;

                case "COFC":
                    value.Add("Cappuccino", 1.29f);
                    break;

                case "COFL":
                    value.Add("Coffee Latte", 1.29f);
                    break;
            }
            if (sku.Length > 4)
            {
              
                //int test = (sku.Length) / 4;
                int amountOfFillings = ((sku.Length) / 4) - 1;
                string newName = value.Keys.ToArray()[0];
                float newPrice = value[newName];


                for (int i = 0; i < amountOfFillings; i++)
                {
                    char fillingType = sku[(7 + i * 4)];

                    switch (fillingType)
                    {
                        case 'B':
                            newName += "+ Bacon";
                            newPrice += 0.12f;
                            break;
                        case 'E':
                            newName += "+ Egg";
                            newPrice += 0.12f;
                            break;
                        case 'C':
                            newName += "+ Cheese";
                            newPrice += 0.12f;
                            break;
                        case 'X':
                            newName += "+ CreamCheese";
                            newPrice += 0.12f;
                            break;
                        case 'S':
                            newName += "+ Bacon";
                            newPrice += 0.12f;
                            break;
                        case 'H':
                            newName += "+ Bacon";
                            newPrice += 0.12f;
                            break;
                    }

                }
                float old = value[value.Keys.ToArray()[0]];
                value.Remove(value.Keys.ToArray()[0]);
                value[newName] = newPrice;
            }
            return value;
        }
    }
}
