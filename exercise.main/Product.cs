using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{

    public enum productType
    {
        BGLO,
        BGLP,
        BGLE,
        BGLS,
        COFB,
        COFW,
        COFC,
        COFL,
        FILB,
        FILE,
        FILC,
        FILX,
        FILS,
        FILH,
    }
    public class Product
    {
        private float cost;
        private string name;
        public Product(productType ptype)
        {
            switch (ptype)
            {
                case productType.BGLO:
                    this.cost = 0.49f;
                    this.name = "Onion Bagle";
                    break;
                case productType.BGLP:
                    this.cost = 0.39f;
                    this.name = "Plain Bagle";
                    break;
                case productType.BGLE:
                    this.cost = 0.49f;
                    this.name = "Everything Bagle";
                    break;
                case productType.BGLS:
                    this.cost = 0.49f; ;
                    this.name = "Sesame Bagle";
                    break;
                case productType.COFB:
                    this.cost = 0.99f;
                    this.name = "Black Coffe";
                    break;
                case productType.COFW:
                    this.cost = 1.19f;
                    this.name = "White Coffe";
                    break;
                case productType.COFC:
                    this.cost = 1.29f;
                    this.name = "Capuccino";
                    break;
                case productType.COFL:
                    this.cost = 1.29f;
                    this.name = "Latte";
                    break;
                case productType.FILB:
                    this.cost = 0.12f;
                    this.name = "Bacon";
                    break;
                case productType.FILE:
                    this.cost = 0.12f;
                    this.name = "Egg";
                    break;
                case productType.FILC:
                    this.cost = 0.12f;
                    this.name = "Cheese";
                    break;
                case productType.FILX:
                    this.cost = 0.12f;
                    this.name = "Cream Cheese";
                    break;
                case productType.FILS:
                    this.cost = 0.12f;
                    this.name = "Smoked Salmon";
                    break;
                case productType.FILH:
                    this.cost = 0.12f;
                    this.name = "Ham";
                    break;
                default:
                    throw new NotSupportedException("Incorrect input");
            }
        }
    }
}
