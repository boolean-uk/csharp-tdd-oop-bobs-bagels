using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling : Item, IComparable 
    {
        public Filling(string type)
        {
            _SKU = type;
            name = "Filling";
            price = 0.12f;
            switch (type)
            {
                case "FILB":
                    variant = "Bacon";
                    break;
                case "FILE":
                    variant = "Egg";
                    break;
                case "FILC":
                    variant = "Cheese";
                    break;
                case "FILX":
                    variant = "Cream Cheese";
                    break;
                case "FILS":
                    variant = "Smoked Salmon";
                    break;
                case "FILH":
                    variant = "Ham";
                    break;
                default: 
                    variant = "";
                    break;
            }
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            Filling otherFilling = obj as Filling;
            return _SKU.CompareTo(otherFilling._SKU);
        }
    }


}
